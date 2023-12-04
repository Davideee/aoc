using AocShared;

namespace Day02Davide
{
    class Program
    {
        static void Main()
        {
            FileReader fileReader = new();

            long counter = 0;
            List<PuzzleGame> puzzleGames = new();

            foreach (string line in fileReader.Lines)
            {
               PuzzleGame puzzleGame = new (line);
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
