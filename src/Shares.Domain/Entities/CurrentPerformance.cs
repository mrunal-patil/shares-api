using System;

namespace Shares.Domain.Entities
{
    public class CurrentPerformance
    {
        public CurrentPerformance(
            string ticker,
            decimal todaysValue,
            decimal peakValue,
            decimal lowestValueInCurrentCycle)
        {
            Ticker = ticker;
            TodaysValue = Math.Round(todaysValue, 2);
            PeakValue = Math.Round(peakValue, 2);
            LowestValueInCurrentCycle = Math.Round(lowestValueInCurrentCycle, 2);
        }

        public string Ticker { get; }
        public decimal TodaysValue { get; }
        public decimal PeakValue { get; }
        public decimal LowestValueInCurrentCycle { get; }
        // public decimal DropInCurrentCycleToday => Math.Round(1 - TodaysValue / PeakValue, 2);
    }
}