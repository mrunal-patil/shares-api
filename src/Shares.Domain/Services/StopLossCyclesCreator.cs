using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shares.Domain.Entities;

namespace Shares.Domain.Services
{
    public class StopLossCyclesCreator : ICreateStopLossCycles
    {
        public StopLossCyclesCreator()
        {
        }

        public IReadOnlyCollection<Cycle> Create(
            IReadOnlyCollection<StockHistory> stockHistory,
            PercentageIntervalForStopLoss percentageInterval,
            YearInterval yearInterval)
        {
            try
            {
                var cycles = new List<Cycle>();

                var orderedStockHistory = stockHistory.OrderBy(s => s.Date).ToList();

                for (int i = 0; i < orderedStockHistory.Count - 1; i++)
                {
                    if (orderedStockHistory[i].ClosingPrice <= orderedStockHistory[i + 1].ClosingPrice)
                        continue;

                    var startCycle = orderedStockHistory[i];
                    var endOfCycle = orderedStockHistory
                        .Where(s => s.Date > startCycle.Date)
                        .FirstOrDefault(s => s.ClosingPrice >= startCycle.ClosingPrice);

                    if (endOfCycle == null)
                        break;

                    var cycle = CreateCycle(
                        orderedStockHistory.GetRange(i, orderedStockHistory.IndexOf(endOfCycle) - i + 1),
                        percentageInterval.FirstDropPercentageInterval,
                        yearInterval);

                    if(CalculateDropInPercentage(cycle.StartingPoint, cycle.LowestPoint) < percentageInterval.MinimumValueForSecondDrop)
                        continue;

                    foreach (var s in cycle.StockHistory)
                    {
                        var firstDropInPercentageInPercentage = CalculateDropInPercentage(cycle.StartingPoint, s.ClosingPrice);
                        if (IsDropWithinPercentageInterval(firstDropInPercentageInPercentage, percentageInterval.FirstDropPercentageInterval))
                        {
                            var remainingStockHistory = cycle.StockHistory.Where(x => x.Date > s.Date).ToList();

                            var riseThreshold = cycle.StartingPoint - cycle.StartingPoint * percentageInterval.MaximumRiseAfterFirstDrop / 100;
                            var stockHistoryAtThePointOfRise = remainingStockHistory.FirstOrDefault(x => x.ClosingPrice >= riseThreshold);
                            if (stockHistoryAtThePointOfRise != null)
                            {
                                remainingStockHistory = remainingStockHistory.Where(x => x.Date > stockHistoryAtThePointOfRise.Date).ToList();
                                var secondDropMinimumStockValue = 
                                    cycle.StartingPoint - cycle.StartingPoint * percentageInterval.MinimumValueForSecondDrop / 100;

                                if (remainingStockHistory.Any(x => x.ClosingPrice <= secondDropMinimumStockValue))
                                {
                                    cycles.Add(cycle);
                                    break;
                                }
                            }
                        }

                    }

                    i = orderedStockHistory.IndexOf(endOfCycle);
                }

                if (!cycles.Any())
                    cycles.Add(CreateCycle(default, percentageInterval.FirstDropPercentageInterval, yearInterval));

                return cycles;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private Cycle CreateCycle(
            IReadOnlyCollection<StockHistory> elementsInTheCycle,
            PercentageInterval percentageInterval,
            YearInterval yearInterval) =>
            new Cycle(elementsInTheCycle, percentageInterval, yearInterval);

        private decimal CalculateDropInPercentage(decimal startingPoint, decimal lowestPoint) =>
            (startingPoint - lowestPoint) * 100 / startingPoint;

        private bool IsDropWithinPercentageInterval(decimal dropInPercentage, PercentageInterval percentageInterval) =>
            dropInPercentage >= percentageInterval.LowerLimit &&
            dropInPercentage < percentageInterval.UpperLimit;
    }
}
