namespace Day02Davide
{
    class Program
    {
        static void Main()
        {
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
            long counter = 0;
            List<PuzzleGame> puzzleGames = new();

            foreach (var line in lines)
            {
               PuzzleGame puzzleGame = new PuzzleGame(line); 
               puzzleGames.Add(puzzleGame);
               if (puzzleGame.ValidateGame(red: 12, green: 13, blue: 14)){
                    counter += puzzleGame.Id;
               }
            }
            Console.WriteLine($"Summe aller Möglichen Ids ist {counter}");

            // Part two
            long powerCounter = 0;
            foreach (var game in puzzleGames)
            {
               powerCounter += game.PowerOfFewestNumberOfCubes;
            }
            Console.WriteLine($"Summe der Produkte der minimaler Anzahl Würfel ist {powerCounter}");
        }

    }
}
