using Shares.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shares.Domain.Entities;

namespace Shares.Domain.Usecases
{
    public class GetCycles
    {
        private readonly IDownloadStockHistory _downloadStockHistory;
        public GetCycles(IDownloadStockHistory downloadStockHistory)
        {
            _downloadStockHistory = downloadStockHistory;
        }

        public async Task<IReadOnlyCollection<Cycle>> Invoke(DateTime startDate, DateTime endDate, string ticker)
        {
            var stockHistory = await _downloadStockHistory.GetByDateAndTicker(startDate, endDate, ticker);
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

                var cycle = new Cycle(
                    orderedStockHistory.GetRange(i, orderedStockHistory.IndexOf(endOfCycle) - i + 1),
                    default,
                    default);

                cycles.Add(cycle);

                if (endOfCycle == null)
                    break;

                i = orderedStockHistory.IndexOf(endOfCycle);
            }

            return cycles;
        }
    }
}
