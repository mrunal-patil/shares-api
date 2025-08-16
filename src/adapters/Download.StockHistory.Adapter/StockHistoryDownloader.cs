using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Download.StockHistory.Adapter.Dtos;
using Newtonsoft.Json;
using Shares.Domain.Ports;
using StockHistoryEntity = Shares.Domain.Entities.StockHistory;

namespace Download.StockHistory.Adapter
{
    public class StockHistoryDownloader : IDownloadStockHistory
    {
        private readonly HttpClient _httpClient;

        public StockHistoryDownloader(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<StockHistoryEntity>> GetByDateAndTicker(
            DateTime startDate,
            DateTime endDate,
            string ticker
        )
        {
            var url = GetUrl(startDate, endDate, ticker);

            _httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            var response = await _httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();

            var stockHistory = ConvertStockHistory(content, ticker);

            return stockHistory;
        }

        private string GetUrl(DateTime startDate, DateTime endDate, string ticker)
        {
            var period1 = new DateTimeOffset(startDate.ToLocalTime()).ToUnixTimeSeconds();
            var period2 = new DateTimeOffset(endDate.ToLocalTime()).ToUnixTimeSeconds();

            return "chart/" + ticker.ToUpper() +
                   $"?period1={period1}&period2={period2}&interval=1d";
        }

        private IReadOnlyCollection<StockHistoryEntity> ConvertStockHistory (string content, string ticker)
        {
            var stockHistoryEntities = new List<StockHistoryEntity>();
            var chartResponse = JsonConvert.DeserializeObject<ChartResponse>(content);

            var timeStamps = chartResponse.Chart.Result[0].Timestamps.Select(t => DateTimeOffset.FromUnixTimeSeconds(t)).ToList();
            var closingPrices = chartResponse.Chart.Result[0].Indicator.Quotes[0].DailyClosingPrices;
            var lowestDailyPrices = chartResponse.Chart.Result[0].Indicator.Quotes[0].DailyLowestPrices;

            for (int i = 0; i < timeStamps.Count; i++)
            {
                if (closingPrices[i] == null || lowestDailyPrices[i] == null)
                    continue;

                stockHistoryEntities.Add(
                    new StockHistoryEntity(
                        ticker, timeStamps[i].Date,
                        closingPrices[i].Value,
                        lowestDailyPrices[i].Value
                    )
                );
            }

            return stockHistoryEntities;
        }
    }
}
