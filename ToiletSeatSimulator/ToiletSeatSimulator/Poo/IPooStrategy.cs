namespace ToiletSeatSimulator;

public interface IPooStrategy : IToiletVisitStrategy
{
	bool IToiletVisitStrategy.OnVisitStart(ToiletSeat toiletSeat) => toiletSeat.Lower();

	public static IPooStrategy Default => new PooAndLeaveStrategy();
}
