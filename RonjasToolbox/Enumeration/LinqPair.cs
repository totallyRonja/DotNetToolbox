using System.Collections;

namespace RonjasToolbox; 

public static class LinqPair {
	public static IEnumerable<(T First, T Second)> Pair<T>(this IEnumerable<T> input) {
		return new PairEnumerable<T>(input);
	}

	private class PairEnumerable<T> : IEnumerable<(T First, T Second)> {
		private readonly IEnumerable<T> source;
		public PairEnumerable(IEnumerable<T> input) {
			source = input;
		}

		public IEnumerator<(T First, T Second)> GetEnumerator() {
			return new PairEnumerator<T>(source.GetEnumerator());
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}

	private class PairEnumerator<T> : IEnumerator<(T First, T Second)> {
		private T? previous = default;
		private readonly IEnumerator<T> source;
		public PairEnumerator(IEnumerator<T> input) {
			source = input;
			Reset();
		}

		public bool MoveNext() {
			previous = source.Current;
			return source.MoveNext();
		}

		public void Reset() {
			try {
				source.Reset();
			} catch(NotImplementedException) {}
			source.MoveNext();
		}

		public (T First, T Second) Current => (previous!, source.Current);

		object IEnumerator.Current => Current;

		public void Dispose() {
			source.Dispose();
		}
	}
}