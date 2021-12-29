using Shares.Domain.Ports;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Shares.Domain.Usecases
{
    public class GetCycles
    {
        private readonly IDownloadStockHistory _downloadStockHistory;
        public GetCycles(IDownloadStockHistory downloadStockHistory)
        {
            _downloadStockHistory = downloadStockHistory;
        }

        public async Task<int> Invoke(DateTime startDate, DateTime endDate, string ticker)
        {
            var stockHistory = await _downloadStockHistory.GetByDateAndTicker(startDate, endDate, ticker);

            var orderedStockHistory = stockHistory.OrderBy(s => s.Date).ToList();

            var numberOfCycles = 0;
            for (int i = 0; i < orderedStockHistory.Count - 1; i++)
            {
                if (orderedStockHistory[i].ClosingPrice <= orderedStockHistory[i + 1].ClosingPrice)
                {
                    continue;
                }

                var startCycle = orderedStockHistory[i];
                var endOfCycle = orderedStockHistory
                    .Where(s => s.Date > startCycle.Date)
                    .FirstOrDefault(s => s.ClosingPrice >= startCycle.ClosingPrice);

                if (endOfCycle == null)
                {
                    break;
                }

                //var elementsWithinTheCycle = orderedStockHistory.GetRange(i, orderedStockHistory.IndexOf(endOfCycle));

                i = orderedStockHistory.IndexOf(endOfCycle);

                numberOfCycles++;
            }

            return numberOfCycles;
        }
    }
}
