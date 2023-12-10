namespace AocShared;

/// <summary>
/// Liest ein txt. File ein.
/// </summary>
public class FileReader
{

    public string[] Lines;

    private const string FilePath = "./data/";

    private char[,] Matrix;

    public FileReader(string path = "")
    {
        var readPath = string.IsNullOrEmpty(path) ? FilePath + "data.txt" : FilePath + path;
        ReadLines(readPath);
    }

    private void ReadLines(string path)
    {
        // Pfad zur Datei, die Sie einlesen möchten
        string[] lines = Array.Empty<string>();

        try
        {
            // Alle Zeilen aus der Datei lesen und in einem Array speichern
            Lines = File.ReadAllLines(path);
        }
        catch (IOException e)
        {
            // Fehlerbehandlung für den Fall, dass die Datei nicht gelesen werden kann
            Console.WriteLine("Fehler beim Lesen der Datei: " + e.Message);
        }
    }

    public char[,] GetMatrix()
    {
        Matrix = new char[Lines.Length, Lines[0].Length];

        for (int i = 0; i < Lines.Length; i++)
        {
            for (int j = 0; j < Lines[i].Length; j++)
            {
                Matrix[i, j] = Lines[i][j];
            }
        }
        return Matrix;
    }

    public Tuple<int, int>? GetKoordinates(char c)
    {
        for (int i = 0; i < Matrix.GetLength(0); i++)
        {
            for (int j = 0; j < Matrix.GetLength(1); j++)
            {
                if (Matrix[i, j] == c)
                {
                    return Tuple.Create(i, j);
                }
            }
        }
        return null;
    }
}