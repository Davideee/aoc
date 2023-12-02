
namespace Day02Davide
{
    public class PuzzleGame
    {

        private List<PuzzleSample> puzzleSamples = new();

        private string GAME = "Game";

        public int Id;

        private string Line;

        private string LineSamples;


        public PuzzleGame(string line)
        {
            Line = line;
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
    }
}