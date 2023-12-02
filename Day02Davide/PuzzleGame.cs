
using System.Formats.Asn1;

namespace Day02Davide
{
    public class PuzzleGame
    {

        public List<PuzzleSample> puzzleSamples = new();

        private string GAME = "Game";

        public int Id;

        private readonly string Line;

        private string LineSamples;

        public PuzzleGame(string line)
        {
            if (string.IsNullOrEmpty(line)){
                throw new ArgumentException("Fehler: Leere Line an PuzzleGame übergeben.");
            }

            Line = line;
            LineSamples = string.Empty;
            ExtractGameId();
            ExtractPuzzleSamples();
        }

        private void ExtractPuzzleSamples()
        {
            List<string> samples = LineSamples.Split(";").ToList();
            foreach (var sample in samples)
            {
                PuzzleSample puzzleSample = new(sample);
                puzzleSamples.Add(puzzleSample);
            }

        }

        private void ExtractGameId()
        {
            // Die Position von ":" finden
            int colonIndex = Line.IndexOf(":");

            // Den Substring zwischen "Game" und ":" extrahieren
            string gameIdString = Line.Substring(GAME.Length, colonIndex - GAME.Length).Trim();
            Id = int.Parse(gameIdString);
            LineSamples = Line.Substring(colonIndex + 1);
        }

        public bool ValidateGame(int red, int blue, int green){
            return !puzzleSamples.Where(s => s.Green > green || s.Blue > blue || s.Red > red).Any();
        }

        public long PowerOfFewestNumberOfCubes => puzzleSamples.Max(s => s.Red) * puzzleSamples.Max(s => s.Blue) * puzzleSamples.Max(s => s.Green);
    }
}