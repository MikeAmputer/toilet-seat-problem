namespace ToiletSeatSimulator;

public interface IToiletVisitStrategy
{
	bool OnVisitStart(ToiletSeat toiletSeat);

	bool OnVisitEnd(ToiletSeat toiletSeat);
}
