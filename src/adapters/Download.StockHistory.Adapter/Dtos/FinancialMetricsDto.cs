using Newtonsoft.Json;

namespace Download.StockHistory.Adapter.Dtos;

public class FinancialMetricsDto
{
    public Metric Metric { get; set; }
}

public class Metric
{
    [JsonProperty("epsTTM")]
    public decimal EarningPerShareTTM { get; set; }
    
    [JsonProperty("peTTM")]
    public decimal PriceToEarningsTTM { get; set; }
}