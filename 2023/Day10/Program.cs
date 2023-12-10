using System.Diagnostics;
using AocShared;
using Day10;
using Microsoft.VisualBasic.CompilerServices;

namespace Day09
{
    class Program
    {
        static void Main()
        {

            Stopwatch stopwatch = new();
            stopwatch.Start();
            var file = new FileReader("data.txt");
            char[,] fields = file.GetMatrix();
            Tuple<int, int> start = file.GetKoordinates('S');
            PipeNavigator pipeNavigator = new PipeNavigator(fields, start);
            stopwatch.Stop();
            Console.WriteLine($"Part {1}: {pipeNavigator.GetFarestCount}");
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
        }
    }
}



