using System;
using System.Linq;

namespace Shares.Domain.Entities
{
    public class Transaction
    {
        public Share Share { get; }
        public DateTime Date { get; }
        public int TransactedQuantity { get; }
        public decimal Cost { get; }
        public decimal SharePrice => Math.Abs(Cost / TransactedQuantity);

        public int TotalQuantity { get; }
        //public decimal TotalValue => CurrentQuantity * SharePrice;
        //public decimal TotalAmountLocked { get; private set; }

        public Transaction(Share share, DateTime date, int quantity, decimal cost)
        {
            Share = share;
            Date = date;
            TransactedQuantity = quantity;
            Cost = Math.Abs(cost);

            TotalQuantity = Share.Transactions.Sum(t => t.TransactedQuantity);

            //SetTotalAmountLocked();
        }

        //private void SetTotalAmountLocked()
        //{
        //    TotalAmountLocked = Share.Transactions[Share.Transactions.Count - 1].TotalValue;
        //}
    }
}