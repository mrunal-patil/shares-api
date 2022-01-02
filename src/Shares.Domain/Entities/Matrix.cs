using System;
using System.Collections.Generic;

namespace Shares.Domain.Entities
{
    public class Matrix
    {
        public List<Row> Rows { get; }

        public Matrix()
        {
            Rows = new List<Row>();
        }

        public void AddRow(List<int> valuesOfTheRow)
        {
            if (valuesOfTheRow == null)
                throw new ArgumentNullException(nameof(valuesOfTheRow));

            Rows.Add(new Row(valuesOfTheRow));
        }
    }

    public class Row
    {
        public List<int> NumberOfCycles { get; }

        public Row(List<int> numberOfCycles)
        {
            NumberOfCycles = numberOfCycles ?? new List<int>();
        }
    }
}
