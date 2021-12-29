using Shares.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shares.Domain.Entities;

namespace Shares.Domain.Usecases
{
    public class SaveStockHistory
    {
        private readonly IDownloadStockHistory _downloadStockHistory;

        public SaveStockHistory(IDownloadStockHistory downloadStockHistory)
        {
            _downloadStockHistory = downloadStockHistory;
        }

        public async Task<IReadOnlyCollection<StockHistory>> Invoke(DateTime startDate, DateTime endDate, string ticker)
        {
            var stockHistory = await _downloadStockHistory.GetByDateAndTicker(startDate, endDate, ticker);


            
            return stockHistory;
        }
    }
}