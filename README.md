# toilet-seat-problem
Run simulations to decide whether a man should put the toilet seat down or not.

***WARNING***: This will not help you decide whether a man should pee standing or sitting.

<details>
  <summary><b>Results</b> (Lowering vs. Leaving)</summary>

  I simulated 10k days with the following settings:
  
  ```csharp
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
  ```
Everybody just leaves the toilet seat as it is at the end of every visit. And that gives us around **7.75** toilet seat interactions per day.

If I change Steve's pee strategy to "always lower the seat":
```csharp
visitors[1].PeeStrategy = new StandAndLowerPeeStrategy();
```
that will give us around **11.2** toilet seat interactions per day.

*Changing Steve's strategy to "sit and leave" will drop interactions to zero, but it's a different story.*
</details>
