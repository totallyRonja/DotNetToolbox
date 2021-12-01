using System.Collections;

namespace RonjasToolbox; 

public static class LinqTriplet {
	public static IEnumerable<(T First, T Second, T Third)> Triplet<T>(this IEnumerable<T> input) {
		return new TripletEnumerable<T>(input);
	}

	private class TripletEnumerable<T> : IEnumerable<(T First, T Second, T Third)> {
		private readonly IEnumerable<T> source;
		public TripletEnumerable(IEnumerable<T> input) {
			source = input;
		}

		public IEnumerator<(T First, T Second, T Third)> GetEnumerator() {
			return new TripletEnumerator<T>(source.GetEnumerator());
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}
	}

	private class TripletEnumerator<T> : IEnumerator<(T First, T Second, T Third)> {
		private T? previous = default;
		private T? previous2 = default;
		private readonly IEnumerator<T> source;
		public TripletEnumerator(IEnumerator<T> input) {
			source = input;
			Reset();
		}

		public bool MoveNext() {
			previous2 = previous;
			previous = source.Current;
			return source.MoveNext();
		}

		public void Reset() {
			try {
				source.Reset();
			} catch(NotImplementedException) {}
			source.MoveNext(); //start source enumerator
			MoveNext();
		}

		public (T First, T Second, T Third) Current => (previous2!, previous!, source.Current);

		object IEnumerator.Current => Current;

		public void Dispose() {
			source.Dispose();
		}
	}
}