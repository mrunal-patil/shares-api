using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shares.Api.Dtos;
using ProfitEntity = Shares.Domain.Entities.Profit;
using ShareEntity = Shares.Domain.Entities.Share;

namespace Shares.Api.Extensions
{
    public static class ShareExtensions
    {
        public static Share ToDto(this ShareEntity share, IReadOnlyCollection<ProfitEntity> profitPerTransaction) =>
            new Share
            {
                Isin = share.Isin,
                Name = share.Name,
                ProfitPerTransaction = profitPerTransaction.Select(p => new Profit
                {
                    ProfitPerYear = p.ValueOverYear,
                    ProfitPercentagePerYear = p.PercentageOverYear
                }).ToList()
            };
    }


}
