using Shares.Domain.Entities;
using System.Collections.Generic;

namespace Shares.Domain.Services
{
    public interface ICreateCycles
    {
        IReadOnlyCollection<Cycle> Create(
            IReadOnlyCollection<StockHistory> stockHistory,
            PercentageInterval percentageInterval,
            YearInterval yearInterval);
    }
}
