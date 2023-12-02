namespace Day02Davide
{
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

            PuzzleGame puzzleGame = new PuzzleGame("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
        }

    }
}
