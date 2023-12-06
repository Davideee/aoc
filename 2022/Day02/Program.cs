class Program
{
    static void Main()
    {
        // Pfad zur Datei, die Sie einlesen möchten
        string filePath = "C:/Users/dadi/RiderProjects/AdventOfCode2022-2/AdventOfCode2022-2/Data/data.txt";
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

        List<int> pointsByShape = new List<int>();
        List<int> pointsByGame = new List<int>();

        // Das Array mit den Zeilen durchlaufen und jede Zeile ausgeben (oder weitere Verarbeitung durchführen)
        foreach (string line in lines)
        {
            pointsByShape.Add(PointBySingleShape(line[^1]));
            pointsByGame.Add(PointBySingleGame(line));
        }
        Console.WriteLine($"Number of Points: {pointsByShape.Sum() + pointsByGame.Sum()}");

        // PART 2
        List<int> pointsByShape2 = new List<int>();
        List<int> pointsByGame2 = new List<int>();
        foreach (string line in lines)
        {
            pointsByShape2.Add(PointByShapeWithDefinedResult(line));
            pointsByGame2.Add(PointByDefinedGameResult(line[^1]));
        }

        Console.WriteLine($"Number of Points second Task: {pointsByShape2.Sum() + pointsByGame2.Sum()}");
    }



    static int PointBySingleGame(string line)
    {
        switch (line)
        {
            case "A X":
            case "B Y":
            case "C Z":
                return 3;
            case "C X":
            case "B Z":
            case "A Y":
                return 6;
            case "C Y":
            case "B X":
            case "A Z":
                return 0;
            default:
                throw new ArgumentException("Undefinierte Buchstaben enthalten");
        }
    }

    static int PointBySingleShape(char shape)
    {
        switch (shape)
        {
            // Rock (A)
            case 'X':
                return 1;
            // Paper (B)
            case 'Y':
                return 2;
            // Scissors (C)
            case 'Z':
                return 3;
            default:
                throw new ArgumentException("Undefinierter Buchstabe enthalten");
        }
    }

    static int PointByDefinedGameResult(char gameresult)
    {
        switch (gameresult)
        {
            // Loose
            case 'X':
                return 0;
            // Draw
            case 'Y':
                return 3;
            // Win
            case 'Z':
                return 6;
            default:
                throw new ArgumentException("Undefinierter Buchstabe enthalten");
        }
    }

    private static int PointByShapeWithDefinedResult(string line)
    {
        switch (line)
        {
            // Choose Rock
            case "B X":
            case "A Y":
            case "C Z":
                return 1;
            // Choose Paper
            case "C X":
            case "B Y":
            case "A Z":
                return 2;
            // Choose Scissor
            case "A X":
            case "C Y":
            case "B Z":
                return 3;
            default:
                throw new ArgumentException("Undefinierte Buchstaben enthalten");
        }
    }
}