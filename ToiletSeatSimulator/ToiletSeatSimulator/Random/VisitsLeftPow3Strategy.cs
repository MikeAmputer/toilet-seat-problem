namespace ToiletSeatSimulator;

public class VisitsLeftPow3Strategy : IRandomWeightCalculationStrategy
{
	public int GetRandomWeight(CustomerDayTracker customerDayTracker)
	{
		return (int)Math.Pow(customerDayTracker.VisitsLeft, 3);
	}
}
