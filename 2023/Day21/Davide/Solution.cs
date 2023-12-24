using System.Data;
using System.Runtime.InteropServices;
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

        public static void Part2(){
            FileReader file = new(FileReader.DavidePath);
            var map = file.GetMap();
            // Console.WriteLine(map.Keys.Max().x);
            // Console.WriteLine(map.Keys.Max().y);
            // for (int i = 0; i < (map.Keys.Max().x + 1) * 3; i++)
            // {
            //     for (int j = 0; j < (map.Keys.Max().y + 1) * 3; j++)
            //     {
            //         Console.Write(GetChar(map,(i,j)));
            //         GetChar(map,(i,j));
            //     }
            //     Console.WriteLine();
            // }
            var startPosition = map.FirstOrDefault(m => m.Value == 'S').Key;
            int virutalSize = 10001;
            startPosition = (startPosition.x + (map.Keys.Max().x + 1) * (int)(virutalSize / 2), startPosition.y  + (map.Keys.Max().y + 1) * (int)(virutalSize / 2));
            var currentPositions = new HashSet<(int x, int y)> {startPosition};
            Console.WriteLine(startPosition);
            // We need the first k points and can then fit a polynomial function to extrapolate 26501365
            for (int i = 0; i < 250; i++)
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

    /// <summary>
    /// Can also handle a virtual sized map 
    /// </summary>
    /// <param name="map"></param>
    /// <param name="pos"></param>
    /// <returns></returns>
    public static bool GardenPlotOnPosition(Dictionary<(int x, int y), char> map, (int x, int y) pos)
    {
        if (pos.x < 0 || pos.y < 0){
            return false;
        }
        int row = pos.x % (map.Keys.Max().x + 1);
        int column = pos.y % (map.Keys.Max().y + 1);
        return map.TryGetValue((row,column), out var value) && (value == '.' || value == 'S');
    }

    public static char GetChar(Dictionary<(int x, int y), char> map, (int x, int y) pos)
    {
        int row = pos.x % (map.Keys.Max().x + 1);
        int column = pos.y % (map.Keys.Max().y + 1);
        map.TryGetValue((row,column), out var value);
        return  value;
    }
}