using System.Collections.Generic;
using System.Linq;

namespace Shares.Domain.Entities
{
    public class Cycle
    {
        public IReadOnlyCollection<StockHistory> StockHistory { get; }
        public decimal LowestPoint => StockHistory.Select(s => s.ClosingPrice).Min();

        public Cycle(IReadOnlyCollection<StockHistory> stockHistory)
        {
            StockHistory = stockHistory.OrderBy(s => s.Date).ToArray();
        }
    }
}
