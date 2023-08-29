namespace ToiletSeatSimulator;

public class SitAndLeavePeeStrategy : IPeeStrategy
{
	public bool OnVisitStart(ToiletSeat toiletSeat) => toiletSeat.Lower();

	public bool OnVisitEnd(ToiletSeat toiletSeat) => false;
}
