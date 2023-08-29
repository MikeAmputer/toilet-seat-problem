namespace ToiletSeatSimulator;

public class VisitsLeftPow2Strategy : IRandomWeightCalculationStrategy
{
	public int GetRandomWeight(CustomerDayTracker customerDayTracker)
	{
		return (int)Math.Pow(customerDayTracker.VisitsLeft, 2);
	}
}
