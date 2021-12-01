using RonjasToolbox;

int[] arr = {0, 1, 2, 3};

foreach (var i in (^5..6).Iter().Where(i => i%2 == 0).Triplet()) {
	Console.Write(i); //(-4, -2, 0) (-2, 0, 2) (0, 2, 4)
}
Console.WriteLine();

Console.WriteLine(string.Concat(arr.Pair()));
Console.WriteLine(string.Concat(arr.Triplet()));