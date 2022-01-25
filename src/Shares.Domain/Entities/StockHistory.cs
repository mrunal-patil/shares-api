using System;

namespace Shares.Domain.Entities
{
    public class StockHistory
    {
        public string Ticker { get; }
        public DateTime Date { get; }
        public decimal ClosingPrice { get; }
        public decimal LowestPrice { get; }

        public StockHistory(
            string ticker,
            DateTime date,
            decimal closingPrice,
            decimal lowestPrice
        )
        {
            Ticker = ticker;
            Date = date;
            ClosingPrice = closingPrice;
            LowestPrice = lowestPrice;
        }
    }
}