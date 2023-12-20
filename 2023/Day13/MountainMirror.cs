namespace Day12;

public class MountainMirror {
    private readonly string[] _mountain;
    private string[] _mountainTransposed;
    private readonly List<Pair> _verticalPairs = new();
    private readonly List<Pair> _horizontalPairs = new();
    public readonly int Count;

    public MountainMirror(string[] mountain) {
        _mountain = mountain;
        int horizontalCount = CheckMirror(_mountain, _horizontalPairs, mountain.Length) * 100;

        Transpose();
        int verticalCount = CheckMirror(_mountainTransposed, _verticalPairs, mountain[0].Length);



        Count = horizontalCount > verticalCount ? horizontalCount : verticalCount;
        PrintMountain(mountain);
        Console.WriteLine($"HorizontalCount: {horizontalCount}");
        Console.WriteLine($"VerticalCount: {verticalCount}");
        Console.WriteLine($"Count: {Count}");

        if (horizontalCount > 0 && verticalCount > 0) {
            throw new ArgumentException("Error, both touch the edge");
        }
    }

    private int CheckMirror(string[] mountain, List<Pair> pairs, int max) {
        int count = 0;
        for (int i = 0; i < mountain.Length; i++) {
            // if the first edge has no copy
            if (i == 1 && pairs.Count == 0) {
                break;
            }
            for (int j = i + 1; j < mountain.Length; j++) {
                if (mountain[i] == mountain[j])
                {
                    pairs.Add(new Pair(i, j));
                }
            }
        }
        for (int i = mountain.Length - 1; i >= 0; i--) {
            // if the last edge has no copy
            if (i == mountain.Length - 2 && pairs.Count == 0) {
                break;
            }
            for (int j = i - 1; j >= 0; j--) {
                if (mountain[i] == mountain[j])
                {
                    pairs.Add(new Pair(i, j));
                }
            }
        }

        List<Pair> sortedPairs = pairs.Distinct().OrderBy(p => p.Difference).ToList();
        pairs.Clear();
        Pair newPair = sortedPairs.FirstOrDefault();
        if (newPair?.Difference == 1 && sortedPairs.Count > 1) {
            while (newPair != null) {
                pairs.Add(newPair);
                newPair = sortedPairs.FirstOrDefault(p => p.MaxValue == newPair.MaxValue + 1 && p.Difference - 2 == newPair.Difference);

            }
            if (pairs.Count > 1) {
                if (pairs.Last().MinValue == 1 || pairs.Last().MaxValue == max) {
                    count = pairs.First().MinValue;
                }
            }
        }
        return count;
    }

    private void Transpose()
    {
        _mountainTransposed = new string[_mountain[0].Length];
        for (int i = 0; i < _mountainTransposed.Length; i++)
        {
            foreach (var line in _mountain)
            {
                _mountainTransposed[i] += line[i];
            }

        }
    }

    public static void PrintMountain(string[] mountain) {
        foreach (var line in mountain) {
            Console.WriteLine(line);
        }
        Console.WriteLine();
    }
}