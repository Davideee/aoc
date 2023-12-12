using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using AocShared;

namespace Day11
{
    class Program
    {
        static void Main()
        {

            Stopwatch stopwatch = new();
            stopwatch.Start();
            var file = new FileReader("data.txt");
            List<int> addRows = file.Lines
                  .Select((s, index) => new { Value = s, Index = index })
                  .Where(item => item.Value.All(c => c == '.'))
                  .Select(item => item.Index)
                  .Reverse()
                  .ToList();

            List<int> addCols = file.VerticalLines()
                  .Select((s, index) => new { Value = s, Index = index })
                  .Where(item => item.Value.All(c => c == '.'))
                  .Select(item => item.Index)
                  .Reverse()
                  .ToList();

            var universe = file.GetMatrix();
            List<Tuple<int, int>> galaxies = new();
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    if (universe[i, j] == '#')
                    {
                        galaxies.Add(Tuple.Create(i, j));
                    }
                }
            }

            int FACTOR = 1;
            List<long> distances = new();
            for (int i = 0; i < galaxies.Count; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++) // Änderung hier
                {
                    long distance = Math.Abs(galaxies[i].Item1 - galaxies[j].Item1) + Math.Abs(galaxies[i].Item2 - galaxies[j].Item2);
                    int expand = addRows
                        .Where(r => Math.Max(galaxies[i].Item1, galaxies[j].Item1) > r && Math.Min(galaxies[i].Item1, galaxies[j].Item1) < r).Count();
                    distance += expand * FACTOR;
                    expand = addCols
                        .Where(r => Math.Max(galaxies[i].Item2, galaxies[j].Item2) > r && Math.Min(galaxies[i].Item2, galaxies[j].Item2) < r).Count();
                    distance += expand * FACTOR;

                    distances.Add(distance);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Part {1}: {distances.Sum()}");

            FACTOR = 1000000 - 1;
            distances = new();
            for (int i = 0; i < galaxies.Count; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++) // Änderung hier
                {
                    long distance = Math.Abs(galaxies[i].Item1 - galaxies[j].Item1) + Math.Abs(galaxies[i].Item2 - galaxies[j].Item2);
                    int expand = addRows
                        .Where(r => Math.Max(galaxies[i].Item1, galaxies[j].Item1) > r && Math.Min(galaxies[i].Item1, galaxies[j].Item1) < r).Count();
                    distance += expand * FACTOR;
                    expand = addCols
                        .Where(r => Math.Max(galaxies[i].Item2, galaxies[j].Item2) > r && Math.Min(galaxies[i].Item2, galaxies[j].Item2) < r).Count();
                    distance += expand * FACTOR;

                    distances.Add(distance);
                }
            }

            Console.WriteLine($"Part {2}: {distances.Sum()}");
            Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
        }
    }
}



