using System;
using System.Collections.Generic;
using System.Linq;

namespace Shares.Domain.Entities
{
    public class Share
    {
        public string Isin { get; }
        public string Name { get; }
        public List<Transaction> Transactions { get; private set; }

        public Share(string name, string isin)
        {
            Isin = isin;
            Name = name;
            Transactions = new List<Transaction>();
        }

        public void AddTransaction(DateTime transactionDate, int transactionQuantity, decimal transactionCost)
        {
            Transactions.Add(new Transaction(this, transactionDate, transactionQuantity, transactionCost));
            Transactions = Transactions.OrderBy(t => t.Date).ToList();
        }

    }
}