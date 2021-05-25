using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shares.Domain.Entities;

namespace Shares.Domain.Ports
{
    public interface IDownloadStockHistory
    {
        Task<IReadOnlyCollection<StockHistory>> GetByDateAndTicker(DateTime startDate, DateTime endDate, string ticker);
    }
}