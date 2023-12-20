using AocShared;

namespace Day13.Davide;

public class Solution {
    public static void Run() {
        Part1();
    }

    private static void Part1()
    {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        var file = new FileReader(FileReader.DavidePath);
        List<string[]> mountains = file.GetSeparatedStringLines();

        long count = 0;
        foreach (var m in mountains) {
            MountainMirror mountain = new(m);
            count += mountain.Count;
        }
        stopwatch.Stop();
        Console.WriteLine($"Part1: {count}");
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
    }
}