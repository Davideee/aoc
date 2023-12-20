using System.Diagnostics;
using System.Runtime.Caching;
using System.Text;
using AocShared;

namespace Day14.Davide;

public class Solution {
    private static readonly MemoryCache Cache = MemoryCache.Default;
    private static readonly CacheItemPolicy _policy = new()
    {
        AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration
    };
    public static bool ReadCache = false;

    public record TiltItem(string[] Matrix, int Iteration, string Key);
    public static readonly List<TiltItem> CachedTiltItems = new(); 

    public static void Run() {
        Part1();
        Part2();
    }

     public static void Part1(){
        Stopwatch stopwatch = new();
        stopwatch.Start();
        FileReader file = new(FileReader.DavidePath);
        long count = 0;
        foreach (var vLine in file.VerticalLines())
        {
            string oldString = string.Empty;
            char[] reversedString = vLine.ToCharArray();
            Array.Reverse(reversedString);
            string newString = new string(reversedString);
            while (newString != oldString){
                oldString = newString;
                newString = newString.Replace("O.", ".O");
            }
            count += newString.Select((s, index) => s == 'O' ? index + 1 : 0).Sum();
        }
        stopwatch.Stop();
        Console.WriteLine($"Part 1: {count}");
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
    }

    public static void Part2(){
        Stopwatch stopwatch = new();
        stopwatch.Start();
        FileReader file = new(FileReader.DavidePath);
        string[] newMatrix = file.Lines;
        string oldHash = string.Empty;
        int iterations = 0;
        while (true)
        {
            oldHash = GetArrayHashCode(newMatrix).ToString();
            newMatrix = PerformCycle(newMatrix, iterations);
            if (ReadCache){
                break;
            }
            iterations++;
        }
        TiltItem item = (TiltItem)Cache[oldHash];
        int period = iterations - item.Iteration;
        int remainingCycles = (1000000000 - item.Iteration - 1) % period;

        for (int i = 0; i < remainingCycles; i++)
        {
            newMatrix = PerformCycle(item.Matrix, iterations);
        }
        string[] northMatrix = RotateClockwise(newMatrix);
        long count = 0;
        foreach (var line in northMatrix)
        {
            count += line.Select((s, index) => s == 'O' ? index + 1 : 0).Sum();
        }
        stopwatch.Stop();
        Console.WriteLine($"Part 2: {count}");
        Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");
    }

    public static string[] PerformCycle(string[] eastMatrix, int it){
        string key = GetArrayHashCode(eastMatrix).ToString();
        if (Cache.Contains(key.ToString())) {
            TiltItem item = (TiltItem)Cache[key];
            CachedTiltItems.Add(item);
            ReadCache = true;
            return item.Matrix;
        }
        string[] tiltedMatrix = eastMatrix;
        string[] rotatedMatrix;
        for (int i = 0; i < 4; i++)
        {
            rotatedMatrix = RotateClockwise(tiltedMatrix);
            tiltedMatrix = Tilt(rotatedMatrix);
        }
        var newItem = new CacheItem(key, new TiltItem(tiltedMatrix,it, key));
        Cache.Add(newItem, _policy);         
        return tiltedMatrix;
    }

    public static string[] Tilt(string[] lines){
        string[] stringLines = lines;
        List<string> tilted = new();
        foreach (var line in stringLines)
        {
            string oldString = string.Empty;
            string newString = line;
            while (newString != oldString){
                oldString = newString;
                newString = newString.Replace("O.", ".O");
            }
            tilted.Add(newString);
        }
        stringLines = tilted.ToArray();
        return stringLines;
    }

    public static string[] RotateClockwise(string[] stringArray)
    {
        int numRows = stringArray.Length;
        int numCols = stringArray[0].Length;
        string[] result = new string[numCols];
        for (int col = 0; col < numCols; col++)
        {
            StringBuilder colBuilder = new StringBuilder(numRows);
            for (int row = numRows - 1; row >= 0; row--)
            {
                if (col < stringArray[row].Length)
                {
                    colBuilder.Append(stringArray[row][col]);
                }
                else
                {
                    colBuilder.Append(' '); 
                }
            }
            result[col] = colBuilder.ToString();
        }
        return result;
    }

    static int GetArrayHashCode(string[] array)
    {
        StringBuilder stringBuilder = new StringBuilder();

        foreach (string line in array)
        {
            stringBuilder.Append(line);
        }

        string concatenatedString = stringBuilder.ToString();
        return concatenatedString.GetHashCode();
    }
}