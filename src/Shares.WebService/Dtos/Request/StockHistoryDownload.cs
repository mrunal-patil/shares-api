using System;

namespace Shares.WebService.Dtos.Request
{
    public class StockHistoryDownload
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Ticker { get; set; }
    }
}
