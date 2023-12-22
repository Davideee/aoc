using AocShared;

namespace Day21.Davide;

public class Solution {

    public static void Run() {
        Part1();
        Part2();
    }

    public static void Part1(){
        FileReader file = new(FileReader.DavidePath);
        var map = file.GetMap();
        var startPosition = map.FirstOrDefault(m => m.Value == 'S').Key;
        var currentPositions = new HashSet<(int x, int y)> {startPosition};
            for (int i = 0; i < 64; i++)
        {
            var newPositions = new HashSet<(int x, int y)>();
            currentPositions.SelectMany(p => ProcessPosition(p, map)).ToList().ForEach(p => newPositions.Add(p));
            currentPositions = new HashSet<(int x, int y)>(newPositions);
        }
        Console.WriteLine($"Part1: {currentPositions.Count}");
    }

    public static Func<(int x, int y), Dictionary<(int x, int y), char>, IEnumerable<(int x, int y)>> ProcessPosition = (position, map) =>
    {
        var newPositions = new List<(int x, int y)> {
            (position.x + 1, position.y),
            (position.x -1, position.y),
            (position.x, position.y + 1),
            (position.x, position.y - 1),
        };
        return newPositions.Where(p => map.TryGetValue(p, out var value) && (value == '.' || value == 'S'));
    };

        public static void Part2(){
            FileReader file = new(FileReader.DavidePath);
            var matrix = file.GetMatrix();
            var extendedMap = new Dictionary<(int x, int y), char>();

            int row = 0;
            int column = 0;
            int extend = 101;
            for (int k = 0; k < extend; k++)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        extendedMap.Add((row + i, column + j), matrix[i,j]);
                    }
                }
                row += matrix.GetLength(0);
                column += matrix.GetLength(1);
            }
            var startPosition = extendedMap.Where(pair => pair.Value == 'S').FirstOrDefault(pair => pair.Key.x > matrix.GetLength(0) * (int)(extend / 2) && pair.Key.x < matrix.GetLength(0) * ((int)(extend / 2) + 1)).Key;
            var currentPositions = new HashSet<(int x, int y)> {startPosition};
            // We need the first k points and can then fit a polynomial function to extrapolate 26501365
            for (int i = 0; i < 50; i++)
            {
                var newPositions = new HashSet<(int x, int y)>();
                currentPositions.SelectMany(p => ProcessPosition(p, extendedMap)).ToList().ForEach(p => newPositions.Add(p));
                currentPositions = new HashSet<(int x, int y)>(newPositions);
                Console.WriteLine($"{i + 1}, {currentPositions.Count}");
            }
        }
}