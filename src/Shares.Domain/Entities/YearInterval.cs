using System;

namespace Shares.Domain.Entities
{
    public class YearInterval
    {
        public DateTime LowerLimit { get; }
        public DateTime UpperLimit { get; }

        public YearInterval(DateTime lowerLimit, DateTime upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
    }
}
