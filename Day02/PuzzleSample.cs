namespace Day02
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
                number = new string(colourCount.Trim().TakeWhile(char.IsDigit).ToArray());
                colour = new string(colourCount.Trim().Where(char.IsLetter).ToArray());
                if (Enum.TryParse(colour, true, out ColourEnum parsedColour) 
                    && int.TryParse(number, out int parsedNumber))
                {
                    switch (parsedColour){
                        case ColourEnum.Red:
                            Red = parsedNumber;
                            break;
                        case ColourEnum.Blue:
                            Blue = parsedNumber;
                            break;
                        case ColourEnum.Green:
                            Green = parsedNumber;
                            break;
                        default:
                            throw new ArgumentException("Fehler: Ungültige Colour von File gelesen");
                    }
                }
                else
                {
                    throw new ArgumentException($"Fehler: Konnte übergebene Farbe oder Nummer nicht parsen. Farbe:={colour}, Number:={number}");
                }
            }    
        }

        public int Red { get; set; }

        public int Green { get; set; }

        public int Blue { get; set; }
    }
}