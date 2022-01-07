using System;
using System.Collections.Generic;
using System.Text;

namespace Shares.Domain.Entities
{
    public class PercentageIntervalForStopLoss
    {
        public PercentageInterval FirstDropPercentageInterval { get; }
        public int MaximumRiseAfterFirstDrop { get; }
        public int MinimumValueForSecondDrop { get; }

        public PercentageIntervalForStopLoss(
            PercentageInterval firstDropPercentageInterval,
            int maximumRiseAfterFirstDrop,
            int minimumValueForSecondDrop)
        {
            FirstDropPercentageInterval = firstDropPercentageInterval;
            MaximumRiseAfterFirstDrop = maximumRiseAfterFirstDrop;
            MinimumValueForSecondDrop = minimumValueForSecondDrop;
        }
    }
}
