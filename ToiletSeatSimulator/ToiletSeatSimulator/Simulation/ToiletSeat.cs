namespace ToiletSeatSimulator;

public class ToiletSeat
{
	private bool _isLowered;
	private int _actionsCount = 0;

	public int ActionsCount => _actionsCount;

	public ToiletSeat(bool isLowered)
	{
		_isLowered = isLowered;
	}

	public bool Lower()
	{
		if (_isLowered)
			return false;

		ChangeState();
		return true;
	}

	public bool Raise()
	{
		if (!_isLowered)
			return false;

		ChangeState();
		return true;
	}

	private void ChangeState()
	{
		_isLowered = !_isLowered;
		_actionsCount++;
	}
}
