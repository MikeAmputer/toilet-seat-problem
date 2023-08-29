namespace ToiletSeatSimulator;

internal static class RandomExtensions
{
	public static int InclusiveBetween(this Random random, int min, int max)
	{
		return random.Next(min, max + 1);
	}

	public static bool NextBool(this Random random)
	{
		return random.Next(0, 2) == 0;
	}

	public static int NextIndexByWeight(this Random random, List<int> weights)
	{
		int totalWeight = 0;
		foreach (int weight in weights)
		{
			totalWeight += weight;
		}

		int randomValue = random.Next(totalWeight) + 1;

		int cumulativeWeight = 0;
		for (int i = 0; i < weights.Count; i++)
		{
			cumulativeWeight += weights[i];
			if (randomValue <= cumulativeWeight)
			{
				return i;
			}
		}

		throw new InvalidOperationException("Weights list cannot be empty.");
	}
}
