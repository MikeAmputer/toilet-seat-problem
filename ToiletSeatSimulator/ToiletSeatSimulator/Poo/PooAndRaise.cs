namespace ToiletSeatSimulator;

public class PooAndRaise : IPooStrategy
{
	public bool OnVisitEnd(ToiletSeat toiletSeat) => toiletSeat.Raise();
}
