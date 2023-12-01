namespace Day01Davide {
    public class CalibrationReader{

        private static Dictionary<string, int> NumbersDictionary => new()
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 }        
            };

        List<int> Numbers = new();

        public CalibrationReader(string[] lines){
            int c = 0;
            long counter = 0;
            foreach (string line in lines)
            {
                var number = $"{FindFirstNumber(line)}{FindLastNumber(line)}";
                Console.WriteLine(line);
                Console.WriteLine(number);
                Console.WriteLine(string.Empty);
                if (string.IsNullOrEmpty(number)){
                    throw new ArgumentException("Fehler: Line enthält keine Zahlen.");
                }

                if (int.TryParse(number, out int parsedNumber))
                {
                    // Das Parsen war erfolgreich
                    Numbers.Add(parsedNumber);
                    counter += parsedNumber;
                }
                else
                {
                    // Das Parsen war nicht erfolgreich
                    throw new ArgumentException($"Fehler: Beim Parsen der Zeichenfolge: {number}");
                }
                c += 1;
            }

            if (Numbers.Any(s => s > 99)){
                throw new ArgumentException("Fehler: Eine Zahl grösser als 100.");           
            }

            if (Numbers.Any(s => s < 10)){
                throw new ArgumentException("Fehler: Eine Zahl kleiner als 10.");           
            }
        }

        public static int FindLastNumber(string line){
            var position = line.Length - 1;
            int? number = default;
            if (char.IsDigit(line[position])){
                number = int.Parse(line[position].ToString());
            } else {
                // Alle string bis zur ersten Zahl speichern
                string text = new String(line.Reverse().TakeWhile(Char.IsLetter).ToArray());
                number = FindValue(text, true);
            }

            if (!number.HasValue){
                char c = line.Where(char.IsDigit).Last();
                return int.Parse(c.ToString());
            }
            return (int)number;
        }


        public static int FindFirstNumber(string line){          
            int? number = default;
            if (char.IsDigit(line[0])){
                number = int.Parse(line[0].ToString());
            } else {
                // Alle string bis zur ersten Zahl speichern
                string text = new String(line.TakeWhile(Char.IsLetter).ToArray());
                number = FindValue(text, false);
            }

            if (!number.HasValue){
                char c = line.Where(char.IsDigit).First();
                return int.Parse(c.ToString());
            }

            return (int)number;
        }

        private static int? FindValue(string text, bool reversed = false){
            int? number = default;
            int indexBest = int.MaxValue;
            foreach(var spelledNumber in NumbersDictionary){
                string searchText = reversed ? new string(spelledNumber.Key.ToCharArray().Reverse().ToArray()) : spelledNumber.Key;
                var index = text.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);
                // Wenn das Wort gefunden wird kommt ein Wert >= 0. Wenn position dann noch null ist oder kleiner als das aktuellste -> überschreiben
                if (index >= 0 && (index < indexBest)){
                    number = spelledNumber.Value;
                    indexBest = index;
                }
            }
            return number;
        }

        public long GetSum => Numbers.Sum();
    }
}