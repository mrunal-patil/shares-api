using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Domain.Entities
{
    public class Transaction
    {
        public DateTime Date { get; }
        public int Quantity { get; }
        public decimal Cost { get; }
        public decimal SharePrice => Math.Abs(Cost / Quantity);

        public Transaction(DateTime date, int quantity, decimal cost)
        {
            Date = date;
            Quantity = quantity;
            Cost = Math.Abs(cost);
        }
    }
}
