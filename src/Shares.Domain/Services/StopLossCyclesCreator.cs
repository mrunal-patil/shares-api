using Shares.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shares.Domain.Services
{
    public class StopLossCyclesCreator : ICreateStopLossCycles
    {
        public IReadOnlyCollection<Cycle> Create(IReadOnlyCollection<StockHistory> stockHistory)
        {
            try
            {
                var cycles = new List<Cycle>();

                var orderedStockHistory = stockHistory.OrderBy(s => s.Date).ToList();

                for (var i = 0; i < orderedStockHistory.Count - 1; i++)
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
                        default,
                        default);

                    cycles.Add(cycle);

                    i = orderedStockHistory.IndexOf(endOfCycle);
                }

                if (!cycles.Any())
                    cycles.Add(CreateCycle(default, default, default));

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
    }
}
