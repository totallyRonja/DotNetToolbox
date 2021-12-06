using System.Collections;

namespace RonjasToolbox;

public static class RangeEnumeration {

	public static IEnumerator<int> GetEnumerator(this Range index) {
		int from = index.Start.Value;
		if (index.Start.IsFromEnd) from = -from;
		int to = index.End.Value;
		if (index.End.IsFromEnd) from = -from;
		return new RangeEnumerator(from, to, false);
	}
	
	public static IEnumerable<int> Iter(this Range index, bool inclusive = false) {
		int from = index.Start.Value;
		if (index.Start.IsFromEnd) from = -from;
		int to = index.End.Value;
		if (index.End.IsFromEnd) from = -from;
		return new RangeEnumerable(from, to, inclusive);
	}

	private class RangeEnumerable : IEnumerable<int> {
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

	private class RangeEnumerator : IEnumerator<int> {
		private int current;
		private readonly int from;
		private readonly int to;
		private readonly bool backwards;
		private readonly bool inclusive;

		public RangeEnumerator(int from, int to, bool inclusive) {
			this.from = from;
			this.to = to;
			this.inclusive = inclusive;
			backwards = to < from;
			Reset();
		}

		bool IEnumerator.MoveNext() {
			current += backwards ? -1 : 1;
			if(inclusive) return backwards ? (current >= to) : (current <= to);
			else return backwards ? (current > to) : (current < to);
		}

		public void Reset() {
			current = from - (backwards ? -1 : 1);
		}

		int IEnumerator<int>.Current => current;

		object IEnumerator.Current => current;

		void IDisposable.Dispose() {}
	}
}