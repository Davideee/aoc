using System;
using System.IO;
using AocShared;

class Program
{
    static void Main()
    {
        FileReader fileReader = new();

        List<int> totalCalories = new();

        int calories = 0;
        // Das Array mit den Zeilen durchlaufen und jede Zeile ausgeben (oder weitere Verarbeitung durchführen)
        foreach (string line in fileReader.Lines)
        {
            if (line == String.Empty)
            {
                totalCalories.Add(calories);
                calories = 0;
            }
            else
            {
                calories += Int32.Parse(line);
            }
        }

        var index = totalCalories.FindIndex( c=> c == totalCalories.Max());
        Console.WriteLine($"Elve with most Calories - Elve: {index+1}, Calories: {totalCalories.Max()}");

        totalCalories.Sort();
        totalCalories.Reverse();

        Console.WriteLine($"Top three Elves with most Calories - Total Calories: {totalCalories.Take(3).Sum()}");


    }
}