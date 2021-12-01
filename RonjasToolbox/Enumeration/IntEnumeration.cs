using System.Collections;

namespace RonjasToolbox;

public static class IntEnumeration {

	public static IEnumerator<int> GetEnumerator(this int target) {
		if (target < 0) throw new IndexOutOfRangeException("target must not be negative");
		return new IntEnumerator(target);
	}

	public static IEnumerable<int> Iter(this int target) {
		if (target < 0) throw new IndexOutOfRangeException("target must not be negative");
		return new IntEnumerable(target);
	}
	
	private class IntEnumerable : IEnumerable<int> {
		private readonly int source;
		public IntEnumerable(int input) {
			source = input;
		}

		public IEnumerator<int> GetEnumerator() {
			return new IntEnumerator(source);
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}


	private class IntEnumerator : IEnumerator<int> {
		private int current;
		private readonly int to;

		public IntEnumerator(int to) {
			this.to = to;
			Reset();
		}

		bool IEnumerator.MoveNext() {
			current++;
			return current < to;
		}

		public void Reset() {
			current = -1;
		}

		int IEnumerator<int>.Current => current;

		object IEnumerator.Current => current;

		void IDisposable.Dispose() {}
	}
}