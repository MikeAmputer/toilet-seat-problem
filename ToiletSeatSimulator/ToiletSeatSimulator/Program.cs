using ToiletSeatSimulator;

var visitors = new List<ToiletCustomerSettings>()
{
	new ToiletCustomerSettings()
	{
		Name = "Susan",
		PeeStrategy = new SitAndLeavePeeStrategy(),
		PooStrategy = new PooAndLeaveStrategy(),
		MinDailyPeeTimes = 5,
		MaxDailyPeeTimes = 9,
		MinDailyPooTimes = 0,
		MaxDailyPooTimes = 2,
	},
	new ToiletCustomerSettings()
	{
		Name = "Steve",
		PeeStrategy = new StandAndLeavePeeStrategy(),
		PooStrategy = new PooAndLeaveStrategy(),
		MinDailyPeeTimes = 4,
		MaxDailyPeeTimes = 7,
		MinDailyPooTimes = 0,
		MaxDailyPooTimes = 2,
	},
};

var simulationSettings = new SimulationSettings
{
	Visitors = visitors,
	DaysToSimulate = 10000,
	RandomWeightCalculationStrategy = new VisitsLeftPow3Strategy(),
	InitialToiletSeatState = ToiletSeatState.Random,
	RandomSeedInstance = default,
};

var simulation = new Simulation(simulationSettings);

Console.WriteLine($"Average toilet seat actions for 'just leave' stratagy: {simulation.Simulate():N3}");

visitors[1].PeeStrategy = new StandAndLowerPeeStrategy();

Console.WriteLine($"Average toilet seat actions for 'man should lower' strategy: {simulation.Simulate():N3}");