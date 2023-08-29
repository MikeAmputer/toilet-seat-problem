namespace ToiletSeatSimulator;

public class PooAndLeaveStrategy : IPooStrategy
{
	public bool OnVisitEnd(ToiletSeat toiletSeat) => false;
}
