using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Domain.Entities
{
    public class Share
    {
        public string Isin { get; }
        public string Name { get; }
        public IReadOnlyCollection<Transaction> Transactions { get; }

        public Share(string name, string isin, IReadOnlyCollection<Transaction> transactions)
        {
            Isin = isin;
            Name = name;
            Transactions = transactions ?? new List<Transaction>();
        }
    }
}
