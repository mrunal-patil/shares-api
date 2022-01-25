namespace Shares.Domain.Entities
{
    public class PercentageIntervalForStopLoss
    {
        public int FirstDroppingPoint { get; }
        public int SecondDroppingPoint { get; }

        public PercentageIntervalForStopLoss(int firstDroppingPoint, int secondDroppingPoint)
        {
            SecondDroppingPoint = secondDroppingPoint;
            FirstDroppingPoint = firstDroppingPoint;
        }
    }
}
