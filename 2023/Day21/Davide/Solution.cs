using System.Data;
using System.Runtime.InteropServices;
using AocShared;
namespace Day21.Davide;

public class Solution {

    public static void Run() {
        // Part1();
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

        public static void Part2(){
            FileReader file = new(FileReader.DavidePath);
            var map = file.GetMap();
            Console.WriteLine(map.Keys.Max().x);
            Console.WriteLine(map.Keys.Max().y);
            for (int i = 0; i < map.Keys.Max().x * 3; i++)
            {
                for (int j = 0; j < map.Keys.Max().y * 3; j++)
                {
                    Console.Write(GetChar(map,(i,j)));
                }
                Console.WriteLine();
            }
            var startPosition = map.FirstOrDefault(m => m.Value == 'S').Key;
            int virutalSize = 3;
            startPosition = (startPosition.x + map.Keys.Max().x * (int)(virutalSize / 2), startPosition.y  + map.Keys.Max().y * (int)(virutalSize / 2));
            var currentPositions = new HashSet<(int x, int y)> {startPosition};
            Console.WriteLine(startPosition);
            // We need the first k points and can then fit a polynomial function to extrapolate 26501365
            // TODO Still some issue with test data..
            for (int i = 0; i < 10; i++)
            {
                var newPositions = new HashSet<(int x, int y)>();
                currentPositions.SelectMany(p => ProcessPosition(p, map)).ToList().ForEach(p => newPositions.Add(p));
                currentPositions = new HashSet<(int x, int y)>(newPositions);
                Console.WriteLine($"{i + 1}, {currentPositions.Count}");
            }
        }

    public static Func<(int x, int y), Dictionary<(int x, int y), char>, IEnumerable<(int x, int y)>> ProcessPosition = (position, map) =>
    {
        var newPositions = new List<(int x, int y)> {
            (position.x + 1, position.y),
            (position.x -1, position.y),
            (position.x, position.y + 1),
            (position.x, position.y - 1),
        };
        return newPositions.Where(p => GardenPlotOnPosition(map, p));
    };

    public static bool GardenPlotOnPosition(Dictionary<(int x, int y), char> map, (int x, int y) pos)
    {
        if (pos.x < 0 || pos.y < 0){
            return false;
        }
        // Handle virtual map
        int row = pos.x % map.Keys.Max().x;
        int column = pos.y % map.Keys.Max().y;
        return map.TryGetValue((row,column), out var value) && (value == '.' || value == 'S');
    }

    public static char GetChar(Dictionary<(int x, int y), char> map, (int x, int y) pos)
    {
        // Handle virtual map
        int row = (pos.x + 1) % (map.Keys.Max().x + 1);
        int column = (pos.y + 1) % (map.Keys.Max().y + 1);
        map.TryGetValue((row,column), out var value);
        return  value;
    }
}