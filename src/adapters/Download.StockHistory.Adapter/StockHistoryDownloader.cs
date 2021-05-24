using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Shares.Domain.Ports;

namespace Download.StockHistory.Adapter
{
    public class StockHistoryDownloader : IDownloadStockHistory
    {
        private readonly HttpClient _httpClient;

        public StockHistoryDownloader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<Shares.Domain.Entities.StockHistory>> GetByDateAndTicker(
            DateTime startDate,
            DateTime endDate,
            string ticker
        )
        {
            var url = GetUrl(startDate, endDate, ticker);
            var response = await _httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            return null;
        }

        private string GetUrl(DateTime startDate, DateTime endDate, string ticker)
        {
            var period1 = new DateTimeOffset(startDate.ToLocalTime()).ToUnixTimeSeconds();
            var period2 = new DateTimeOffset(endDate.ToLocalTime()).ToUnixTimeSeconds();

            return "download/" + ticker.ToUpper() +
                   $"?period1={period1}&period2={period2}&interval=1d&events=history";
        }
    }
}
