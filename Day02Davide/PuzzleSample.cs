namespace Day02Davide
{
    public class PuzzleSample
    {
        public PuzzleSample(string sample)
        {
            ParseSample(sample);
        }


        private void ParseSample(string sample){
            List<string> colourCounts = sample.Split(",").ToList();
            string number = string.Empty;
            string colour = string.Empty;
            foreach (var colourCount in colourCounts)
            {
                number = new String(colourCount.TakeWhile(char.IsDigit).ToArray());
                colour = new string(colourCount.Where(char.IsLetter).ToArray());
                Console.WriteLine(number);
                Console.WriteLine(colour);
            }

        }

        public int Red { get; set; }

        public int Green { get; set; }

        public int Blue { get; set; }
    }
}