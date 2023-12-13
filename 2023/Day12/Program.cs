using System.Diagnostics;
using AocShared;

namespace Day12
{
    public class Program
    {
        static void Main()
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var file = new FileReader("data.txt");
            long permutationCounts = 0;

            foreach (var line in file.Lines) {
                string[] input = line.Trim().Split(" ").ToArray();
                string springDataRaw = input[0];
                List<int> sequence = input[1].Trim().Split(",").Select(int.Parse).ToList();
                SpringData springData = new(springDataRaw, sequence);
                permutationCounts += springData.Counts;
            }

            stopwatch.Stop();
            Console.WriteLine($"Part {1}: {permutationCounts}");
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
        }

        private static void Part2()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var file = new FileReader("data.txt");
            long permutationCounts = 0;

            foreach (var line in file.Lines) {
                string[] input = line.Trim().Split(" ").ToArray();
                string springDataRaw = input[0];
                string springDataRawPart2 = $"{springDataRaw}?{springDataRaw}?{springDataRaw}?{springDataRaw}?{springDataRaw}";
                List<int> sequence = input[1].Trim().Split(",").Select(int.Parse).ToList();
                List<int> sequencePart2 = Enumerable.Repeat(sequence, 5).SelectMany(x => x).ToList();
                SpringData springData = new(springDataRawPart2, sequencePart2);

                permutationCounts += springData.Counts;
            }
            stopwatch.Stop();
            Console.WriteLine($"Part 2: {permutationCounts}");
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
        }
    }
}



