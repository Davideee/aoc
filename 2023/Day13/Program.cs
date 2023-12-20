using System.Diagnostics;
using AocShared;

namespace Day12
{
    public class Program
    {
        static void Main()
        {
            Part1();
        }

        private static void Part1()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var file = new FileReader("data.txt");
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
}



