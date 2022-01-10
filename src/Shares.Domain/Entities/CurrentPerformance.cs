using System;

namespace Shares.Domain.Entities
{
    public class CurrentPerformance
    {
        public CurrentPerformance(
            string ticker,
            decimal todaysValue,
            decimal peakValue,
            decimal dropInCurrentCycleFromLowestPoint)
        {
            Ticker = ticker;
            TodaysValue = Math.Round(todaysValue, 2);
            PeakValue = Math.Round(peakValue, 2);
            DropInCurrentCycleFromLowestPoint = Math.Round(dropInCurrentCycleFromLowestPoint, 2);
        }

        public string Ticker { get; }
        public decimal TodaysValue { get; }
        public decimal PeakValue { get; }
        public decimal DropInCurrentCycleFromLowestPoint { get; }
        public decimal DropInCurrentCycleToday => Math.Round(1 - TodaysValue / PeakValue, 2);
    }
}
