using System.Collections;

namespace RonjasToolbox;

public static class RangeEnumeration {

	public static RangeEnumerator GetEnumerator(this Range index) {
		int from = index.Start.Value;
		if (index.Start.IsFromEnd) from = -from;
		int to = index.End.Value;
		if (index.End.IsFromEnd) from = -from;
		return new RangeEnumerator(from, to, false);
	}
	
	public static RangeEnumerable Iter(this Range index, bool inclusive = false) {
		int from = index.Start.Value;
		if (index.Start.IsFromEnd) from = -from;
		int to = index.End.Value;
		if (index.End.IsFromEnd) from = -from;
		return new RangeEnumerable(from, to, inclusive);
	}

	public struct RangeEnumerable : IEnumerable<int> {
		private readonly (int From, int To, bool inclusive) source;
		public RangeEnumerable(int from, int to, bool inclusive) {
			source = (from, to, inclusive);
		}

		public IEnumerator<int> GetEnumerator() {
			return new RangeEnumerator(source.From, source.To, source.inclusive);
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}

	public struct RangeEnumerator : IEnumerator<int> {
		private int current;
		private readonly int from;
		private readonly int to;
		private readonly int step;

		public RangeEnumerator(int from, int to, bool inclusive) {
			step = to < from ? -1 : 1;
			this.from = from;
			this.to = inclusive ? to + step : to;
			current = from - step;
		}

		public bool MoveNext() {
			current += step;
			return current != to;
		}

		public void Reset() {
			current = from - step;
		}

		public int Current => current;

		object IEnumerator.Current => current;

		public void Dispose() {}
	}
}