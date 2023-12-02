namespace Day02Davide
{
    public class PuzzleGame
    {

        private List<PuzzleSample> puzzleSamples = new();

        private string GAME = "Game";

        public int Id;

        public PuzzleGame(string line)
        {
            ExtractGameId(line);
        }

        private void ExtractGameId(string line)
        {
            // Die Position von "Game" finden
            int gameIndex = line.IndexOf(GAME) + GAME.Length;

            // Die Position von ":" finden, beginnend ab "Game"
            int colonIndex = line.IndexOf(":");

            // Den Substring zwischen "Game" und ":" extrahieren
            string gameIdString = line.Substring(gameIndex, colonIndex).Trim();

            Id = int.Parse(gameIdString);
        }
    }
}