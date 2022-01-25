using Shares.Domain.Entities;
using System.Collections.Generic;

namespace Shares.Domain.Services
{
    public interface ICreateStopLossCycles
    {
        IReadOnlyCollection<Cycle> Create(IReadOnlyCollection<StockHistory> stockHistory);
    }
}
