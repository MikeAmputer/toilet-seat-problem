namespace ToiletSeatSimulator;

public interface IPeeStrategy : IToiletVisitStrategy
{
	public static IPeeStrategy GirlDefault => new SitAndLeavePeeStrategy();

	public static IPeeStrategy BoyDefault => new StandAndLeavePeeStrategy();
}
