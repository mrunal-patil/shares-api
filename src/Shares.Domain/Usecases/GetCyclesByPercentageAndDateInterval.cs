using System;
using Shares.Domain.Entities;
using Shares.Domain.Ports;
using Shares.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shares.Domain.Usecases
{
    public class GetCyclesByPercentageAndDateInterval
    {
        private readonly ICreateCycles _cyclesCreator;
        private readonly IDownloadStockHistory _stockHistoryDownloader;
        
        public GetCyclesByPercentageAndDateInterval(
            ICreateCycles cyclesCreator,
            IDownloadStockHistory stockHistoryDownloader)
        {
            _cyclesCreator = cyclesCreator;
            _stockHistoryDownloader = stockHistoryDownloader;
        }

        public async Task<Matrix> Create()
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

                    foreach (var percentageInterval in Constants.PercentageIntervals)
                    {
                        cycles.AddRange(_cyclesCreator.Create(stockHistory, percentageInterval, yearInterval));
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
