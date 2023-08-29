namespace ToiletSeatSimulator;

public class Simulation
{
	private readonly SimulationSettings _settings;

	public Simulation(SimulationSettings settings)
	{
		_settings = settings ?? throw new ArgumentNullException(nameof(settings));

		foreach (var v in _settings.Visitors)
		{
			v.Validate();
		}
	}

	public double Simulate()
	{
		var averageDailyActions = 0d;

		for (var i = 0; i < _settings.DaysToSimulate; i++)
		{
			var daySim = new ToiletDaySimulator(
				_settings.Visitors,
				_settings.RandomWeightCalculationStrategy,
				_settings.InitialToiletSeatState,
				_settings.RandomSeedInstance);

			averageDailyActions += 1d * daySim.Simulate() / _settings.DaysToSimulate;
		}

		return averageDailyActions;
	}
}
