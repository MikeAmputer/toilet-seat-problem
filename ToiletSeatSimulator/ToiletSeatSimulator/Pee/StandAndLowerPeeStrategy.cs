namespace ToiletSeatSimulator;

public class StandAndLowerPeeStrategy : IPeeStrategy
{
	public bool OnVisitStart(ToiletSeat toiletSeat) => toiletSeat.Raise();

	public bool OnVisitEnd(ToiletSeat toiletSeat) => toiletSeat.Lower();
}
