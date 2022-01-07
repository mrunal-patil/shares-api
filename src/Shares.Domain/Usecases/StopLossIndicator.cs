using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shares.Domain.Entities;
using Shares.Domain.Ports;
using Shares.Domain.Services;

namespace Shares.Domain.Usecases
{
    public class StopLossIndicator
    {
        private readonly ICreateStopLossCycles _stopLossCyclesCreator;
        private readonly IDownloadStockHistory _stockHistoryDownloader;

        public StopLossIndicator(
            ICreateStopLossCycles stopLossCyclesCreator,
            IDownloadStockHistory stockHistoryDownloader)
        {
            _stopLossCyclesCreator = stopLossCyclesCreator;
            _stockHistoryDownloader = stockHistoryDownloader;
        }

        public async Task<Matrix> Invoke()
        {
            var matrix = new Matrix();
            foreach (var ticker in Constants.Tickers)
            {
                List<Cycle> cycles = new List<Cycle>();
                foreach (var yearInterval in Constants.YearIntervals)
                {
                    var stockHistory = await _stockHistoryDownloader.GetByDateAndTicker(
                        yearInterval.LowerLimit,
                        yearInterval.UpperLimit,
                        ticker);

                    foreach (var percentageInterval in Constants.PercentageIntervalsForStopLoss)
                    {
                        cycles.AddRange(_stopLossCyclesCreator.Create(stockHistory, percentageInterval, yearInterval));
                    }
                }

                var valuesToCreateRow = GetValuesForRow(cycles);
                matrix.AddRow(valuesToCreateRow);
            }

            return matrix;
        }

        private List<decimal> GetValuesForRow(List<Cycle> cycles)
        {
            return cycles
                .GroupBy(c => c.PercentageInterval.LowerLimit)
                .OrderBy(g => g.Key)
                .SelectMany(g => g
                    .GroupBy(x => x.YearInterval.UpperLimit)
                    .OrderByDescending(x => x.Key)
                    .Select(x => x.Count(c => c.StockHistory != null))
                    .Select(Convert.ToDecimal)
                ).ToList();
        }
    }
}
