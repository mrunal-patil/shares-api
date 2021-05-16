using System;

namespace Shares.Domain.Entities
{
    public class Profit
    {
        public decimal PercentageOverYear { get; }
        public decimal ValueOverYear { get; }

        public Profit(decimal valueOverYear, decimal percentageOverYear)
        {
            ValueOverYear = Math.Round(valueOverYear, 2);
            PercentageOverYear = Math.Round(percentageOverYear, 4);
        }
    }
}
