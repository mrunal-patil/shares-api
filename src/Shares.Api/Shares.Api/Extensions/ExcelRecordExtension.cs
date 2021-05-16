using Shares.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using ShareEntity = Shares.Domain.Entities.Share;

namespace Shares.Api.Extensions
{
    public static class ExcelRecordExtension
    {
        public static IReadOnlyCollection<ShareEntity> ToDomainEntities(this IReadOnlyCollection<ExcelRecord> excelRecords)
        {
            var shares = new List<ShareEntity>();
            foreach (var grp in excelRecords.GroupBy(e => e.Isin))
            {
                var share = new ShareEntity(grp.First().ProductName, grp.Key);
                foreach (var excelRecord in grp)
                {
                    if (!DateTime.TryParse(excelRecord.TransactionDate, out var transactionDate))
                        throw new ArgumentException("Invalid date");

                    if (!int.TryParse(excelRecord.Quantity, out var transactionQuantity))
                        throw new ArgumentException("Invalid quantity");

                    if (!decimal.TryParse(excelRecord.TransactionCost, out var transactionCost))
                        throw new ArgumentException("Invalid transaction cost.");

                    share.AddTransaction(transactionDate, transactionQuantity, transactionCost);
                }

                shares.Add(share);
            }

            return shares;
        }
    }
}