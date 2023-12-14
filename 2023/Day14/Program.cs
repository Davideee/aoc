using AocShared;
using System.Diagnostics;

namespace Day14
{
    class Program
    {
        static void Main()
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();
            FileReader file = new();
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
    }
}



