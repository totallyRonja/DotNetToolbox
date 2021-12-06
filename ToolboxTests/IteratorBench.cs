using BenchmarkDotNet.Attributes;
using RonjasToolbox;

namespace ToolboxTests; 

public class IteratorBench {
	[Benchmark]
	public int For() {
		int sum = 0;
		for (int i = 0; i < 1024; i++) {
			sum += i;
		}
		return sum;
	}
	
	[Benchmark]
	public int IntEnumerator() {
		int sum = 0;
		foreach (int i in 1024) {
			sum += i;
		}
		return sum;
	}
	
	[Benchmark]
	public int RangeEnumerator() {
		int sum = 0;
		foreach (int i in 0..1024) {
			sum += i;
		}
		return sum;
	}
}