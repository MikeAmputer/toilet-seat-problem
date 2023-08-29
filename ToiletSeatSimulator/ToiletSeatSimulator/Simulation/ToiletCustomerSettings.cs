namespace ToiletSeatSimulator;

public class ToiletCustomerSettings
{
	public string Name { get; init; } = "Untitled";
	public IPeeStrategy PeeStrategy { get; set; } = IPeeStrategy.BoyDefault;
	public IPooStrategy PooStrategy { get; set; } = IPooStrategy.Default;
	public ushort MinDailyPeeTimes { get; init; } = 4;
	public ushort MaxDailyPeeTimes { get; init; } = 8;
	public ushort MinDailyPooTimes { get; init; } = 0;
	public ushort MaxDailyPooTimes { get; init; } = 3;

	public void Validate()
	{
		if (MinDailyPeeTimes > MaxDailyPeeTimes)
			throw new InvalidOperationException("Max daily pee times is lower than min daily pee times.");

		if (MinDailyPooTimes > MaxDailyPooTimes)
			throw new InvalidOperationException("Max daily poo times is lower than min daily poo times.");
	}
}