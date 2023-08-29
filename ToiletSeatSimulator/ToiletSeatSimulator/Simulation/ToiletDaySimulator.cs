namespace ToiletSeatSimulator;

internal class ToiletDaySimulator
{
	private readonly Dictionary<ToiletCustomerSettings, CustomerDayTracker> _visitors = new();
	private readonly IRandomWeightCalculationStrategy _randomWeightCalculationStrategy;
	private readonly Random _random;
	private readonly ToiletSeat _toiletSeat;

	public ToiletDaySimulator(
		IEnumerable<ToiletCustomerSettings> visitors,
		IRandomWeightCalculationStrategy randomWeightCalculationStrategy,
		ToiletSeatState initialState = ToiletSeatState.Random,
		Random? random = null)
	{
		_randomWeightCalculationStrategy = randomWeightCalculationStrategy
			?? throw new ArgumentNullException(nameof(randomWeightCalculationStrategy));

		_random = random ?? new Random(Guid.NewGuid().GetHashCode());

		foreach (var visitor in visitors)
		{
			_visitors.Add(
				visitor,
				new CustomerDayTracker(
					(ushort)_random.InclusiveBetween(visitor.MinDailyPeeTimes, visitor.MaxDailyPeeTimes),
					(ushort)_random.InclusiveBetween(visitor.MinDailyPooTimes, visitor.MaxDailyPooTimes)));
		}

		_toiletSeat = new(ToIsLowered(initialState));
	}

	public int Simulate()
	{
		while (GetNextVisitor(out var nextVisitor))
		{
			var visitorTracker = _visitors[nextVisitor!];

			if (GonnaPee(visitorTracker))
			{
				nextVisitor!.PeeStrategy.OnVisitStart(_toiletSeat);
				visitorTracker.DecrementPeesLeft();
				nextVisitor!.PeeStrategy.OnVisitEnd(_toiletSeat);
			}
			else
			{
				nextVisitor!.PooStrategy.OnVisitStart(_toiletSeat);
				visitorTracker.DecrementPoosLeft();
				nextVisitor!.PooStrategy.OnVisitEnd(_toiletSeat);
			}
		}

		return _toiletSeat.ActionsCount;
	}

	private bool ToIsLowered(ToiletSeatState initialState) => initialState switch
	{
		ToiletSeatState.Lowered => true,
		ToiletSeatState.Lifted => false,
		_ => _random.NextBool(),
	};

	private bool GetNextVisitor(out ToiletCustomerSettings? nextVisitor)
	{
		var visitors = _visitors
			.Select(v => (visitor: v.Key, randomWeight: _randomWeightCalculationStrategy.GetRandomWeight(v.Value)))
			.Where(v => v.randomWeight > 0)
			.ToList();

		if (visitors.Count == 0)
		{
			nextVisitor = null;
			return false;
		}

		var nextIndex = _random.NextIndexByWeight(visitors.Select(v => v.randomWeight).ToList());

		nextVisitor = visitors[nextIndex].visitor;
		return true;
	}

	private bool GonnaPee(CustomerDayTracker customerTracker)
	{
		if (customerTracker.PoosLeft == 0)
			return true;

		if (customerTracker.PeesLeft == 0)
			return false;

		return _random.NextIndexByWeight(new List<int> { customerTracker.PeesLeft, customerTracker.PoosLeft }) == 0;

	}
}
