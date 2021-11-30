using System.Collections;

namespace RonjasToolbox;

public static class RangeForeach {

	public static IEnumerator<int> GetEnumerator(this Range index) {
		if (index.Start.IsFromEnd || index.End.IsFromEnd) throw new IndexOutOfRangeException("the range needs to be \"from the start\"");
		int from = index.Start.Value;
		int to = index.End.Value;
		if (to < from) throw new IndexOutOfRangeException("end must be bigger than start");

		return new RangeEnumerator(from, to);
	}


	private class RangeEnumerator : IEnumerator<int> {
		private int current;
		private readonly int from;
		private readonly int to;

		public RangeEnumerator(int from, int to) {
			this.from = from;
			this.to = to;
			Reset();
		}

		bool IEnumerator.MoveNext() {
			current++;
			return current < to;
		}

		public void Reset() {
			current = @from - 1;
		}

		int IEnumerator<int>.Current => current;

		object IEnumerator.Current => current;

		void IDisposable.Dispose() {}
	}
}