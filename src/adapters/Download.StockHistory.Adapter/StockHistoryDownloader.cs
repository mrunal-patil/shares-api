using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
            var stockHistoryRecords = content.Split("\n".ToCharArray());
            var stockHistory = new List<StockHistoryEntity>();

            foreach (var stockHistoryRecord in stockHistoryRecords.Where(s => s != stockHistoryRecords.First()))
            {
                var stockHistoryAsString = stockHistoryRecord.Split(",".ToCharArray());

                if (stockHistoryAsString.Contains("null") || stockHistoryAsString.Any(s => s == null))
                    continue;

                var numberStyle = System.Globalization.NumberStyles.Number;
                var culture = System.Globalization.CultureInfo.InvariantCulture;

                if (!DateTime.TryParse(stockHistoryAsString[0], out var date))
                    throw new ArgumentException($"Cannot convert {stockHistoryAsString[0]} into date.");

                //if (!decimal.TryParse(stockHistoryAsString[1], numberStyle, culture, out var openingPrice))
                //    throw new ArgumentException($"Cannot convert opening price {stockHistoryAsString[1]} into decimal.");

                //if (!decimal.TryParse(stockHistoryAsString[2], numberStyle, culture, out var highestPrice))
                //    throw new ArgumentException($"Cannot convert highest price {stockHistoryAsString[2]} into decimal.");

                if (!decimal.TryParse(stockHistoryAsString[3], numberStyle, culture, out var lowestPrice))
                    throw new ArgumentException($"Cannot convert lowest price {stockHistoryAsString[3]} into decimal.");

                if (!decimal.TryParse(stockHistoryAsString[4], numberStyle, culture, out var closingPrice))
                    throw new ArgumentException($"Cannot convert closing price {stockHistoryAsString[4]} into decimal.");

                //if (!int.TryParse(stockHistoryAsString[6], numberStyle, culture, out var volume))
                //    throw new ArgumentException($"Cannot convert volume {stockHistoryAsString[6]} into integer.");

                var stockHistoryItem = new StockHistoryEntity(
                    ticker,
                    date,
                    closingPrice,
                    lowestPrice
                );

                stockHistory.Add(stockHistoryItem);
            }

            return stockHistory;
        }
    }
}
