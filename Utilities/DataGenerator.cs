namespace CSharpBenchmarks.Utilities;

public static class DataGenerator
{
	public static string String() => Guid.NewGuid().ToString()[..8];

	public static IEnumerable<string> Strings(this int count)
		=> Enumerable.Range(0, count).Select(_ => String());

	public static IEnumerable<string> SortedStrings(this int count)
		=> count.Strings().OrderBy(x => x);
}
