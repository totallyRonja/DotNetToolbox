namespace RonjasToolbox; 

public static class StringExtensions {
	public static string Join<T>(this IEnumerable<T> collection, string Separator) {
		return string.Join(Separator, collection);
	}

	public static bool IsNullOrEmpty(this string str) {
		return string.IsNullOrEmpty(str);
	}
	
	public static bool IsNullOrWhiteSpace(this string str) {
		return string.IsNullOrWhiteSpace(str);
	}
}