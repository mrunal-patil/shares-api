using Shares.Domain.Entities;
using Shares.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shares.Domain.Usecases
{
    public class AverageCalculator
    {
        private readonly IDownloadStockHistory _stockHistoryDownloader;

        public AverageCalculator(IDownloadStockHistory downloadStockHistory)
        {
            _stockHistoryDownloader = downloadStockHistory;
        }

        public async Task<Matrix> Get()
        {
            var matrix = new Matrix();
            foreach (var ticker in Constants.Tickers)
            {
                var startDate = new DateTime(1996, 01, 01);

                var stockHistory = await _stockHistoryDownloader.GetByDateAndTicker(startDate, DateTime.Today, ticker);

                var averages = new List<decimal>();
                while (startDate <= DateTime.Today)
                {
                    var endDate = startDate.AddMonths(3);

                    var closingPrices = stockHistory.Where(s => s.Date >= startDate.Date && s.Date < endDate.Date)
                        .Select(s => s.ClosingPrice)
                        .ToList();

                    var average = 0.0m;
                    if (closingPrices.Any())
                        average = closingPrices.Average();

                    averages.Add(Math.Round(average, 2));

                    startDate = endDate;
                }

                matrix.AddColumn(averages);
            }

            return matrix;
        }
    }
}
