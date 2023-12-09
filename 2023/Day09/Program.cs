using System.Diagnostics;
using AocShared;

namespace Day09
{
    class Program
    {
        static void Main() {
            for (int i = 1; i < 3; i++) {
                Stopwatch stopwatch = new();
                stopwatch.Start();
                var file = new FileReader();

                long lastNumbers = 0;

                foreach (var line in file.Lines) {
                    List<long> sequence = line.Trim().Split(" ").Select(long.Parse).ToList();
                    if (i == 2) {
                        sequence.Reverse();
                    }
                    lastNumbers += sequence.Last();
                    while (sequence.Any(s => s != 0)) {
                        List<long> nextSequence = sequence.Skip(1).Select((current, index) => current - sequence[index]).ToList();
                        lastNumbers += nextSequence.Last();
                        sequence = nextSequence.ToList();
                    }
                }

                stopwatch.Stop();
                Console.WriteLine($"Part {i}: {lastNumbers}");
                Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
            }
        }
    }
}