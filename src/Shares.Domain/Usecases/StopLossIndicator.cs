using Shares.Domain.Entities;
using Shares.Domain.Ports;
using Shares.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shares.Domain.Usecases
{
    public class StopLossIndicator
    {
        private readonly ICreateStopLossCycles _cyclesCreator;
        private readonly IDownloadStockHistory _stockHistoryDownloader;
        private List<Cycle> _subCycles;

        public StopLossIndicator(
            ICreateStopLossCycles cyclesCreator,
            IDownloadStockHistory stockHistoryDownloader)
        {
            _cyclesCreator = cyclesCreator;
            _stockHistoryDownloader = stockHistoryDownloader;
            _subCycles = new List<Cycle>();
        }

        public async Task<Matrix> Invoke()
        {
            var matrix = new Matrix();
            foreach (var ticker in Constants.CurrentPerformanceTickers)
            {
                matrix.Tickers.Add(ticker);
                foreach (var yearInterval in Constants.YearIntervals)
                {
                    var stockHistory = new List<StockHistory>();
                    try
                    {
                        stockHistory = (await _stockHistoryDownloader.GetByDateAndTicker(
                            yearInterval.LowerLimit,
                            yearInterval.UpperLimit,
                            ticker)).ToList();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Doesn't have data for the time interval");
                    }

                    foreach (var percentageIntervalForStopLoss in Constants.PercentageIntervalsForStopLoss)
                    {
                        var cycles = _cyclesCreator.Create(stockHistory);

                        var count = _subCycles.Count;
                        foreach (var cycle in cycles)
                        {
                            CreateSubCycles(cycle, percentageIntervalForStopLoss, yearInterval);
                        }

                        if (_subCycles.Count == count)
                        {
                            _subCycles.Add(CreateCycle(default, percentageIntervalForStopLoss, yearInterval));
                        }
                    }
                }
                
                var valuesToCreateRow = GetValuesForRow(_subCycles);
                matrix.AddRow(valuesToCreateRow);

                _subCycles = new List<Cycle>();
            }

            return matrix;
        }

        private IReadOnlyCollection<StockHistory> CreateSubCycles(
            Cycle cycle,
            PercentageIntervalForStopLoss percentageInterval,
            YearInterval yearInterval)
        {
            if (cycle.StockHistory == default)
            {
                return Array.Empty<StockHistory>();
            }

            var remainingStockHistory = cycle.StockHistory;

            var firstDroppingStockRecord = remainingStockHistory.FirstOrDefault(s =>
                s.ClosingPrice <=
                CalculateDropInPercentage(cycle.StartingPoint, percentageInterval.FirstDroppingPoint));
            if (firstDroppingStockRecord == default)
            {
                return CreateSubCycles(CreateDefaultCycle(percentageInterval, yearInterval), percentageInterval,
                    yearInterval);
            }

            remainingStockHistory = remainingStockHistory.Where(s => s.Date > firstDroppingStockRecord.Date).ToList();

            var secondDroppingStockRecord = remainingStockHistory.FirstOrDefault(s =>
                s.ClosingPrice <
                CalculateDropInPercentage(cycle.StartingPoint, percentageInterval.SecondDroppingPoint));
            if (secondDroppingStockRecord == default)
            {
                return CreateSubCycles(CreateDefaultCycle(percentageInterval, yearInterval), percentageInterval,
                    yearInterval);
            }

            remainingStockHistory = remainingStockHistory.Where(s => s.Date > secondDroppingStockRecord.Date).ToList();

            var finalDroppingStockRecord = remainingStockHistory.FirstOrDefault(s =>
                s.ClosingPrice >=
                CalculateDropInPercentage(cycle.StartingPoint, percentageInterval.FirstDroppingPoint));
            if (finalDroppingStockRecord == default)
            {
                return CreateSubCycles(CreateDefaultCycle(percentageInterval, yearInterval), percentageInterval,
                    yearInterval);
            }

            remainingStockHistory = remainingStockHistory.Where(s => s.Date > finalDroppingStockRecord.Date).ToList();

            _subCycles.Add(CreateCycle(
                cycle.StockHistory.Where(s =>
                    s.Date >= firstDroppingStockRecord.Date && s.Date <= finalDroppingStockRecord.Date).ToList(),
                percentageInterval, yearInterval));

            return CreateSubCycles(
                CreateCycle(remainingStockHistory, percentageInterval, yearInterval),
                percentageInterval,
                yearInterval);
        }

        private Cycle CreateDefaultCycle(
            PercentageIntervalForStopLoss percentageInterval,
            YearInterval yearInterval) => CreateCycle(default, percentageInterval, yearInterval);

        private Cycle CreateCycle(IReadOnlyCollection<StockHistory> stockHistory,
            PercentageIntervalForStopLoss percentageInterval,
            YearInterval yearInterval) => new Cycle(
            stockHistory,
            new PercentageInterval(percentageInterval.SecondDroppingPoint, percentageInterval.FirstDroppingPoint),
            yearInterval
        );

        private decimal CalculateDropInPercentage(decimal startingPoint, decimal lowestPoint) =>
            startingPoint - startingPoint * lowestPoint / 100;

        private List<decimal?> GetValuesForRow(List<Cycle> cycles)
        {
            return cycles
                .GroupBy(c => c.PercentageInterval.LowerLimit)
                .OrderBy(g => g.Key)
                .SelectMany(g => g
                    .GroupBy(x => x.YearInterval.UpperLimit)
                    .OrderByDescending(x => x.Key)
                    .Select(x => (decimal?)x.Count(c => c.StockHistory != null))
                ).ToList();
        }
    }
}