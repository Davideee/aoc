using System.Runtime.CompilerServices;
using Day01Davide;

namespace Template{
    class Program
{
        static void Main()
        {
            // Aktueller Ausführpfad erhalten
            string currentDirectory = Directory.GetCurrentDirectory();

            // Pfad zur Datei, die Sie einlesen möchten
            string filePath = "./data/data.txt";
            string[] lines = Array.Empty<string>();

            try
            {
                // Alle Zeilen aus der Datei lesen und in einem Array speichern
                lines = File.ReadAllLines(filePath);
            }
            catch (IOException e)
            {
                // Fehlerbehandlung für den Fall, dass die Datei nicht gelesen werden kann
                Console.WriteLine("Fehler beim Lesen der Datei: " + e.Message);
            }

            CalibrationReader calibrationReader = new CalibrationReader(lines);
            Console.WriteLine($"Summe aller Zahlen ist {calibrationReader.GetSum}");  
        }

    }
}
