namespace Shares.Domain.Entities
{
    public class PercentageInterval
    {
        public int LowerLimit { get; }
        public int UpperLimit { get; }

        public PercentageInterval(int lowerLimit, int upperLimit)
        {
            LowerLimit = lowerLimit;
            UpperLimit = upperLimit;
        }
    }
}
