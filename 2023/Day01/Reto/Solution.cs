using AocShared;

namespace Day01.Reto;

public class Solution {
    public static void Run() {
            // Instanz von CalibrationChecker erstellen
            CalibrationChecker checker = new CalibrationChecker();
            
           //Pfad setzen und alle Lines einlesen
            string currentDirectory = Directory.GetCurrentDirectory();

            string path = currentDirectory+"\\Reto\\data\\data.txt";
            string[] lines = File.ReadAllLines(path);
           
            int sum = checker.CalculateSum(lines);
            Console.WriteLine("Die Summe der Calibration-Werte lautet:"+sum);
    }
}