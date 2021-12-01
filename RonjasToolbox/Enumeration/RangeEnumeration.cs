using System.Collections;

namespace RonjasToolbox;

public static class RangeEnumeration {

	public static IEnumerator<int> GetEnumerator(this Range index) {
		if (index.Start.IsFromEnd || index.End.IsFromEnd) throw new IndexOutOfRangeException("the range needs to be \"from the start\"");
		int from = index.Start.Value;
		int to = index.End.Value;
		return new RangeEnumerator(from, to);
	}
	
	public static IEnumerable<int> Iter(this Range index) {
		if (index.Start.IsFromEnd || index.End.IsFromEnd) throw new IndexOutOfRangeException("the range needs to be \"from the start\"");
		int from = index.Start.Value;
		int to = index.End.Value;
		return new RangeEnumerable(from, to);
	}

	private class RangeEnumerable : IEnumerable<int> {
		private readonly (int From, int To) source;
		public RangeEnumerable(int from, int to) {
			source = (from, to);
		}

		public IEnumerator<int> GetEnumerator() {
			return new RangeEnumerator(source.From, source.To);
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

		public RangeEnumerator(int from, int to) {
			this.from = from;
			this.to = to;
			backwards = to < from;
			Reset();
		}

		bool IEnumerator.MoveNext() {
			current += backwards ? -1 : 1;
			return backwards ? (current > to) : (current < to);
		}

		public void Reset() {
			current = from - (backwards ? -1 : 1);
		}

		int IEnumerator<int>.Current => current;

		object IEnumerator.Current => current;

		void IDisposable.Dispose() {}
	}
}