namespace ToiletSeatSimulator;

public class StandAndLeavePeeStrategy : IPeeStrategy
{
	public bool OnVisitStart(ToiletSeat toiletSeat) => toiletSeat.Raise();

	public bool OnVisitEnd(ToiletSeat toiletSeat) => false;
}
