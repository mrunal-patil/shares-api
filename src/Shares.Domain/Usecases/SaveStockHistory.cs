using Shares.Domain.Ports;
using System;
using System.Collections.Generic;
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

        public async Task<IReadOnlyCollection<Shares.Domain.Entities.StockHistory>> Invoke(DateTime startDate, DateTime endDate, string ticker)
        {
            // get data needed to be saved from yahoo-finance.
            var stockHistory = await _downloadStockHistory.GetByDateAndTicker(startDate, endDate, ticker);
            return stockHistory;

            // save the data retrieved from yahoo-finance.
        }
    }
}