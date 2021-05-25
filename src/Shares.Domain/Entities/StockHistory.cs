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

        public StockHistory(
            string ticker,
            DateTime date,
            decimal openingPrice,
            decimal closingPrice,
            decimal highestPrice,
            decimal lowestPrice,
            int volume
        )
        {
            Ticker = ticker;
            Date = date;
            OpeningPrice = openingPrice;
            ClosingPrice = closingPrice;
            HighestPrice = highestPrice;
            LowestPrice = lowestPrice;
            Volume = volume;
        }
    }
}