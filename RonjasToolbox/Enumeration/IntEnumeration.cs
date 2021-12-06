using System.Collections;

namespace RonjasToolbox;

public static class IntEnumeration {

	public static IntEnumerator GetEnumerator(this int target) {
#if DEBUG
		if (target < 0) throw new IndexOutOfRangeException("target must not be negative");
#endif
		return new IntEnumerator(target);
	}

	public static IntEnumerable Iter(this int target) {
#if DEBUG
		if (target < 0) throw new IndexOutOfRangeException("target must not be negative");
#endif
		return new IntEnumerable(target);
	}

	public struct IntEnumerable : IEnumerable<int> {
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


	public struct IntEnumerator : IEnumerator<int> {
		private int current;
		private readonly int to;

		public IntEnumerator(int to) {
			this.to = to;
			current = -1;
		}

		public bool MoveNext() {
			current++;
			return current < to;
		}

		public void Reset() {
			current = -1;
		}

		public int Current => current;

		object IEnumerator.Current => current;

		public void Dispose() {}
	}
}