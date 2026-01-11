using Shares.Domain.Entities;
using Shares.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shares.Domain.Usecases
{
    public class AverageCalculator(IDownloadStockHistory downloadStockHistory)
    {
        public async Task<Matrix> Get(AveragedOver averagedOver)
        {
            var matrix = new Matrix();
            foreach (var ticker in Constants.StockAverageTickers)
            {
                matrix.Tickers.Add(ticker);
                var startDate = new DateTime(1996, 01, 01);
                var endDate = CalculateEndDate(startDate, averagedOver);

                var stockHistory = await downloadStockHistory.GetByDateAndTicker(startDate, DateTime.Today, ticker);

                var averages = new List<decimal?>();
                while (startDate <= DateTime.Today)
                {
                    var closingPrices = stockHistory.Where(s => s.Date >= startDate.Date && s.Date < endDate.Date)
                        .Select(s => s.ClosingPrice)
                        .ToList();

                    if (closingPrices.Count != 0)
                    {
                        var average = closingPrices.Average();
                        averages.Add(Math.Round(average, 2));
                    }
                    else averages.Add(null);

                    startDate = startDate.AddMonths(3);
                    endDate = endDate.AddMonths(3);
                }

                matrix.AddColumn(averages);
            }

            return matrix;
        }

        private DateTime CalculateEndDate(DateTime startDate, AveragedOver averagedOver)
        {
            return averagedOver switch
            {
                AveragedOver.OneQuarter => startDate.AddMonths(3),
                AveragedOver.TwoQuarters => startDate.AddMonths(6),
                AveragedOver.Year => startDate.AddYears(1),
                _ => throw new ArgumentOutOfRangeException(nameof(averagedOver), averagedOver, null)
            };
        }
    }
}
