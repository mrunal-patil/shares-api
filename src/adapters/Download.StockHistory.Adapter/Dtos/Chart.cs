using Newtonsoft.Json;

namespace Download.StockHistory.Adapter.Dtos
{
    public class ChartResponse
    {
        public Chart Chart { get; set; }
    }

    public class Chart
    {
        [JsonProperty("result")]
        public Result[] Result { get; set; }
    }

    public class Result
    {
        [JsonProperty("timestamp")]
        public long[] Timestamps { get; set; }

        [JsonProperty("indicators")]
        public Indicator Indicator { get; set; } 
    }

    public class Indicator
    {
        [JsonProperty("quote")]
        public Quote[] Quotes { get; set; }
    }

    public class Quote
    {
        [JsonProperty("close")]
        public decimal?[] DailyClosingPrices { get; set; }
        [JsonProperty("low")]
        public decimal?[] DailyLowestPrices { get; set; }
    }
}
