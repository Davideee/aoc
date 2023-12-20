using AocShared;

namespace Day01.Davide;

public class Solution {
    public static void Run() {
        FileReader fileReader = new();

        CalibrationReader calibrationReader = new (fileReader.Lines);
        Console.WriteLine($"Summe aller Zahlen ist {calibrationReader.GetSum}");
    }
}