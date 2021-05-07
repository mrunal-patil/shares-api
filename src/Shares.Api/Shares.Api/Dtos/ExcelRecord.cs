using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shares.Api.Dtos
{
    public class ExcelRecord
    {
        public int RowNumber { get; set; }
        public string Isin { get; set; }
        public string ProductName { get; set; }
        public string TransactionDate { get; set; }
        public string Quantity { get; set; }
        public string TransactionCost { get; set; }
    }
}
