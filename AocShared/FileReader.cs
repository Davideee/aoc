namespace AocShared;

/// <summary>
/// Liest ein txt. File ein.
/// </summary>
public class FileReader {

    public string[] Lines;

    private const string FilePath = "./data/data.txt";


    public FileReader(string path = "") {
        var readPath = string.IsNullOrEmpty(path) ? FilePath : path;
        ReadLines(readPath);
    }

    private void ReadLines(string path) {
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
}