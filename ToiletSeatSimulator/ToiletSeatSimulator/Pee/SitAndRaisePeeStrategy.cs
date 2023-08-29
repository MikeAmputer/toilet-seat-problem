namespace ToiletSeatSimulator;

public class SitAndRaisePeeStrategy : IPeeStrategy
{
	public bool OnVisitStart(ToiletSeat toiletSeat) => toiletSeat.Lower();

	public bool OnVisitEnd(ToiletSeat toiletSeat) => toiletSeat.Raise();
}
