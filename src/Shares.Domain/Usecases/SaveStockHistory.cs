using Shares.Domain.Ports;
using System;
using System.Threading.Tasks;

namespace Shares.Domain.Usecases
{
    public class SaveStockHistory
    {
        private readonly IDownloadStockHistory _downloadStockHistory;

        public SaveStockHistory(IDownloadStockHistory downloadStockHistory)
        {
            _downloadStockHistory = downloadStockHistory;
        }

        public async Task Invoke(DateTime startDate, DateTime endDate, string ticker)
        {
            // get data needed to be saved from yahoo-finance.
            var stockHistory = await _downloadStockHistory.GetByDateAndTicker(startDate, endDate, ticker);

            // save the data retrieved from yahoo-finance.
        }
    }
}