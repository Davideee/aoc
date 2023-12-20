using System.Diagnostics;
using AocShared;

namespace Day10.Davide;

public class Solution {
    public static void Run() {
        Stopwatch stopwatch = new();
        stopwatch.Start();
        var file = new FileReader(FileReader.DavidePath);
        char[,] fields = file.GetMatrix();
        Tuple<int, int> start = file.GetKoordinates('S');
        PipeNavigator pipeNavigator = new PipeNavigator(fields, start);
        stopwatch.Stop();
        Console.WriteLine($"Part {1}: {pipeNavigator.GetFarestCount}");
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
    }
}