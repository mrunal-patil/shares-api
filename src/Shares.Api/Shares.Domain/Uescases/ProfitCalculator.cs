using Shares.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shares.Domain.Uescases
{
    public class ProfitCalculator
    {
        public IReadOnlyCollection<Profit> Get(Share share)
        {
            // group the transactions by date and create one data point per date.
            var profitPerTransaction = new List<Profit>();
            foreach (var transaction in share.Transactions)
            {
                var previousTransaction = share.Transactions.FirstOrDefault(t => t.Date < transaction.Date);
                if (previousTransaction == default)
                    continue;

                var lockingPeriod = transaction.Date.Subtract(previousTransaction.Date).Days;

                var lockedAmount = previousTransaction.TotalQuantity * previousTransaction.SharePrice;

                var changeInPriceOverLockedPeriodPercentage =
                    (transaction.SharePrice - previousTransaction.SharePrice) / previousTransaction.SharePrice;

                var changeInInvestmentOverLockedPeriod =
                    (transaction.SharePrice - previousTransaction.SharePrice) * previousTransaction.TotalQuantity;

                var profitOverYearPercentage = changeInPriceOverLockedPeriodPercentage / lockingPeriod * 365;
                var profitOverYear = changeInInvestmentOverLockedPeriod / lockingPeriod * 365;

                profitPerTransaction.Add(new Profit(profitOverYear, profitOverYearPercentage));
            }

            return profitPerTransaction;
        }
    }
}