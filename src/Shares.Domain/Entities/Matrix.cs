using System;
using System.Collections.Generic;

namespace Shares.Domain.Entities
{
    public class Matrix
    {
        public List<string> Tickers { get; set; }
        public List<Row> Rows { get; }

        public Matrix()
        {
            Rows = new List<Row>();
            Tickers = new List<string>();
        }

        public void AddRow(List<decimal> valuesOfTheRow)
        {
            if (valuesOfTheRow == null)
                throw new ArgumentNullException(nameof(valuesOfTheRow));

            Rows.Add(new Row(valuesOfTheRow));
        }

        public void AddColumn(List<decimal> valuesOfTheColumn)
        {
            if (Rows.Count < valuesOfTheColumn.Count)
            {
                var rowsToAdd = valuesOfTheColumn.Count - Rows.Count;
                while (rowsToAdd > 0)
                {
                    AddRow([]);
                    rowsToAdd--;
                }
            }

            for (var i = 0; i < Rows.Count; i++)
            {
                Rows[i].Elements.Add(valuesOfTheColumn[i]);
            }
        }
    }

    public class Row
    {
        public List<decimal> Elements { get; }

        public Row(List<decimal> elements)
        {
            Elements = elements ?? new List<decimal>();
        }
    }
}
