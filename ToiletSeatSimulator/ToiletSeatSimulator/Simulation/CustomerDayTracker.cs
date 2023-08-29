namespace ToiletSeatSimulator;

public class CustomerDayTracker
{
	public ushort PeesLeft { get; private set; }
	public ushort PoosLeft { get; private set; }

	public int VisitsLeft => PeesLeft + PoosLeft;

	public CustomerDayTracker(ushort pees, ushort poos)
	{
		PeesLeft = pees;
		PoosLeft = poos;
	}

	internal void DecrementPeesLeft()
	{
		if (PeesLeft == 0)
			throw new InvalidOperationException("No pees left.");

		PeesLeft--;
	}

	internal void DecrementPoosLeft()
	{
		if (PoosLeft == 0)
			throw new InvalidOperationException("No poos left.");

		PoosLeft--;
	}
}
