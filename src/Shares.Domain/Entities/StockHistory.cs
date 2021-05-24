using System;

namespace Shares.Domain.Entities
{
    public class StockHistory
    {
        public string Ticker { get; }
        public DateTime Date { get; }
        public decimal OpeningPrice { get; }
        public decimal ClosingPrice { get; }
        public decimal HighestPrice { get; }
        public decimal LowestPrice { get; }
        public int Volume { get; }
    }
}