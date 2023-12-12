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
            List<char> charList = new() { '#', '.' };
            long permutationCounts = 0;
            Permutations permutations = new Permutations(charList);

            Parallel.ForEach(file.Lines, line =>
            {
                string[] input = line.Trim().Split(" ").ToArray();
                string springDataRaw = input[0];
                int[] sequence = input[1].Trim().Split(",").Select(int.Parse).ToArray();
                SpringData springData = new SpringData(springDataRaw, sequence, permutations);
                Interlocked.Add(ref permutationCounts, springData.PermutationCounts);
            });

            stopwatch.Stop();
            Console.WriteLine($"Part {1}: {permutationCounts}");
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds / 1000}s");
        }
    }
}



