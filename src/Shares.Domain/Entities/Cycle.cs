using System.Collections.Generic;
using System.Linq;

namespace Shares.Domain.Entities
{
    public class Cycle
    {
        public IReadOnlyCollection<StockHistory> StockHistory { get; }
        public decimal LowestPoint => StockHistory.Select(s => s.LowestPrice).Min();
        public StockHistory LowestPointStockHistory => StockHistory.First(s => s.LowestPrice == LowestPoint);
        public decimal StartingPoint => StockHistory.First().ClosingPrice;
        public PercentageInterval PercentageInterval { get; }
        public YearInterval YearInterval { get; }

        public Cycle(
            IReadOnlyCollection<StockHistory> stockHistory,
            PercentageInterval percentageInterval,
            YearInterval yearInterval)
        {
            PercentageInterval = percentageInterval;
            YearInterval = yearInterval;

            StockHistory = stockHistory?.OrderBy(s => s.Date).ToArray();
        }
    }
}
