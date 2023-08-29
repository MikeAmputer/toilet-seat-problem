namespace ToiletSeatSimulator;

public class PooAndRaiseStrategy : IPooStrategy
{
	public bool OnVisitEnd(ToiletSeat toiletSeat) => toiletSeat.Raise();
}
