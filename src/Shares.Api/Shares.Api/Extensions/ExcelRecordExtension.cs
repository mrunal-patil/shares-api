using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Shares.Api.Dtos;
using Shares.Domain.Entities;

namespace Shares.Api.Extensions
{
    public static class ExcelRecordExtension
    {
        public static IReadOnlyCollection<Share> ToDomainEntities(this IReadOnlyCollection<ExcelRecord> excelRecords)
        {
            var shares = new List<Share>();
            foreach (var grp in excelRecords.GroupBy(e => e.Isin))
            {
                var transactions = new List<Transaction>();
                foreach (var excelRecord in grp)
                {
                    if (!DateTime.TryParse(excelRecord.TransactionDate, out var transactionDate))
                        throw new ArgumentException("Invalid date");

                    if(!int.TryParse(excelRecord.Quantity, out var transactionQuantity))
                        throw new ArgumentException("Invalid quantity");

                    if(!decimal.TryParse(excelRecord.TransactionCost, out var transactionCost))
                        throw new ArgumentException("Invalid transaction cost.");

                    transactions.Add(new Transaction(transactionDate, transactionQuantity, transactionCost));

                }

                shares.Add(new Share(grp.First().ProductName, grp.Key, transactions));
            }

            return shares;
        }
    }
}
