using System;
using System.Collections.Generic;

namespace Shares.Domain.Entities
{
    public class Matrix
    {
        public List<string> Tickers { get; } = [];
        public List<Row> Rows { get; } = [];

        public void AddRow(List<decimal?> valuesOfTheRow)
        {
            ArgumentNullException.ThrowIfNull(valuesOfTheRow);

            Rows.Add(new Row(valuesOfTheRow));
        }

        public void AddColumn(List<decimal?> valuesOfTheColumn)
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

    public class Row(List<decimal?> elements)
    {
        public List<decimal?> Elements { get; } = elements ?? [];
    }
}
