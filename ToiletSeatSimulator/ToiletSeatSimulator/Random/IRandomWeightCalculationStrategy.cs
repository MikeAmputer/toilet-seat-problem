namespace ToiletSeatSimulator;

public interface IRandomWeightCalculationStrategy
{
	int GetRandomWeight(CustomerDayTracker customerDayTracker);
}
