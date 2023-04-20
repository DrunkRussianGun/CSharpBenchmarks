using BenchmarkDotNet.Attributes;
using CSharpBenchmarks.Utilities;

namespace CSharpBenchmarks;

public class SortedCollectionCreationOnSortedData
{
	private IEnumerable<string> inputData = null!;

	[Params(3, 10, 100, 1000, 100000)]
	public int DataLength;

	[GlobalSetup]
	public void SetUp() => inputData = DataLength.SortedStrings().ToArray();

	[Benchmark(Baseline = true)]
	public string[] Array() => inputData.ToArray();

	[Benchmark]
	public SortedList<string, string> SortedList()
	{
		var list = new SortedList<string, string>();
		foreach (var value in inputData)
			list[value] = value;
		return list;
	}

	[Benchmark]
	public SortedDictionary<string, string> SortedDictionary()
	{
		var list = new SortedDictionary<string, string>();
		foreach (var value in inputData)
			list[value] = value;
		return list;
	}

	[Benchmark]
	public SortedSet<string> SortedSet()
	{
		var set = new SortedSet<string>();
		foreach (var value in inputData)
			set.Add(value);
		return set;
	}
}
