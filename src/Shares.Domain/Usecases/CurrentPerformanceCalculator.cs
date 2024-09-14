using Shares.Domain.Entities;
using Shares.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shares.Domain.Usecases
{
    public class CurrentPerformanceCalculator
    {
        private readonly IDownloadStockHistory _stockHistoryDownloader;

        public CurrentPerformanceCalculator(IDownloadStockHistory downloadStockHistory)
        {
            _stockHistoryDownloader = downloadStockHistory;
        }

        public async Task<IReadOnlyCollection<CurrentPerformance>> Invoke()
        {
            var startDate = new DateTime(1996, 01, 01);
            var endDate = DateTime.Today;
            var currentPerformances = new List<CurrentPerformance>();

            foreach (var ticker in Constants.CurrentPerformanceTickers)
            {
                var stockHistory = await _stockHistoryDownloader.GetByDateAndTicker(startDate, endDate, ticker);
                var orderedStockHistory = stockHistory.OrderByDescending(s => s.Date).ToList();

                var todaysValue = orderedStockHistory.First().ClosingPrice;
                var peakValue = orderedStockHistory.Max(x => x.ClosingPrice);
                var peak = orderedStockHistory.First(s => s.ClosingPrice == peakValue);

                var currentCycle = orderedStockHistory.Where(s => s.Date > peak.Date).ToList();
                if (currentCycle != null && currentCycle.Any())
                {
                    var drop = currentCycle.Min(s => s.ClosingPrice);
                    currentPerformances.Add(new CurrentPerformance(ticker, todaysValue, peakValue, drop));
                }
                else
                    currentPerformances.Add(new CurrentPerformance(ticker, todaysValue, peakValue, 0));
            }

            return currentPerformances;
        }
    }
}
