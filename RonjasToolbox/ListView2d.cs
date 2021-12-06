using System.Collections;

namespace RonjasToolbox; 

public class ListView2d<T>: IList<T> {
	public IList<T> Data;
	public int Width;
	public int Height;

	public ListView2d(IList<T> data, int width, int height) {
		Data = data;
		Width = width;
		Height = height;
	}
	
	public T this[int x, int y] {
		get {
			if (x < 0 || x >= Width || y < 0 || y > Height) throw new IndexOutOfRangeException();
			var index = y * Width + x;
			return Data[index];
		}
		set {
			if (x < 0 || x >= Width || y < 0 || y > Height) throw new IndexOutOfRangeException();
			var index = y * Width + x;
			Data[index] = value;
		}
	}

	public override string ToString() {
		return this.Chunk(Width)
			.Select((line, i) => (i==0?"[":" ") + line.Join(", "))
			.Join("\n")+"]";
	}

	//IList stuff
	public IEnumerator<T> GetEnumerator() => Data.GetEnumerator();

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	public void Add(T item) => Data.Add(item);

	public void Clear() => Data.Clear();

	public bool Contains(T item) => Data.Contains(item);

	public void CopyTo(T[] array, int arrayIndex) => Data.CopyTo(array, arrayIndex);

	public bool Remove(T item) => Data.Remove(item);

	public int Count => Data.Count;
	public bool IsReadOnly => Data.IsReadOnly;
	public int IndexOf(T item) => Data.IndexOf(item);

	public void Insert(int index, T item) => Data.Insert(index, item);

	public void RemoveAt(int index) => Data.RemoveAt(index);

	public T this[int index] {
		get => Data[index];
		set => Data[index] = value;
	}
}