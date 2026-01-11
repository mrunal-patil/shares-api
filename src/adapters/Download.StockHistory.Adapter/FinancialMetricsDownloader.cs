using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Download.StockHistory.Adapter.Dtos;
using Newtonsoft.Json;
using Shares.Domain;
using Shares.Domain.Entities;
using Shares.Domain.Ports;

namespace Download.StockHistory.Adapter;

public class FinancialMetricsDownloader(HttpClient httpClient) : IDownloadFinancialMetrics
{
    public async Task<IReadOnlyCollection<FinancialMetrics>> GetAll()
    {
        var financialMetricsCollection = new List<FinancialMetrics>();
        foreach (var ticker in Constants.FinancialMetricsTickers)
        {
            Console.WriteLine($"Ticker: {ticker}");
            var response = await httpClient.GetAsync($"?symbol={ticker}&metric=all");
            var financialMetricsDto = JsonConvert.DeserializeObject<FinancialMetricsDto>(await response.Content.ReadAsStringAsync());
            financialMetricsCollection.Add(new FinancialMetrics
            {
                Ticker = ticker,
                EarningPerShareTTM = Math.Round(financialMetricsDto.Metric.EarningPerShareTTM, 2),
                PriceToEarningsTTM = Math.Round(financialMetricsDto.Metric.PriceToEarningsTTM, 2)
            });
            
            await Task.Delay(500);
        }
        
        return financialMetricsCollection;
    }
}