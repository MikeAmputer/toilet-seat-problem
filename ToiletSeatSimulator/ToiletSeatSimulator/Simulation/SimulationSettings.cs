namespace ToiletSeatSimulator;

public class SimulationSettings
{
	public List<ToiletCustomerSettings> Visitors { get; set; } = new();
	public uint DaysToSimulate { get; set; } = 100;
	public IRandomWeightCalculationStrategy RandomWeightCalculationStrategy { get; set; } = new VisitsLeftPow3Strategy();
	public ToiletSeatState InitialToiletSeatState { get; set; } = ToiletSeatState.Random;
	public Random? RandomSeedInstance { get; set; } = null;
}
