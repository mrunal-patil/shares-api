using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExcelDataReader;
using Shares.Api.Dtos;

namespace Shares.Api.Extensions
{
    public static class FormFileExtensions
    {
        public static bool IsValid(this IFormFile file)
        {
            if (Path.GetExtension(file.FileName).Trim().ToLowerInvariant() != ".xlsx")
                return false;

            return true;
        }

        public static async Task<IReadOnlyCollection<ExcelRecord>> Parse(this IFormFile file)
        {
            var transactionsFile = await file.GetBytes();

            var transactions = new List<ExcelRecord>();
            const int FIRST_ROW_WITH_DATA = 2;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            await using var stream = new MemoryStream(transactionsFile);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            {
                int rowCounter = 0;
                while (reader.Read())
                {
                    rowCounter++;

                    if(rowCounter < FIRST_ROW_WITH_DATA)
                        continue;

                    var transaction = new ExcelRecord
                    {
                        RowNumber = rowCounter,
                        Isin = reader.GetValue(ColumnConstants.Isin)?.ToString(),
                        ProductName = reader.GetValue(ColumnConstants.ProductName)?.ToString(),
                        TransactionDate = reader.GetValue(ColumnConstants.TransactionDate)?.ToString(),
                        Quantity = reader.GetValue(ColumnConstants.Quantity)?.ToString(),
                        TransactionCost = reader.GetValue(ColumnConstants.TransactionCost)?.ToString()
                    };

                    transactions.Add(transaction);
                }
            }

            return transactions;
        }

        private static async Task<byte[]> GetBytes(this IFormFile formFile)
        {
            await using var memoryStream = new MemoryStream();
            await formFile.CopyToAsync(memoryStream);
            return memoryStream.ToArray();
        }

        internal static class ColumnConstants
        {
            public static int TransactionDate = 0;
            public static int ProductName = 2;
            public static int Isin = 3;
            public static int Quantity = 6;
            public static int TransactionCost = 11;
        }
    }
}
