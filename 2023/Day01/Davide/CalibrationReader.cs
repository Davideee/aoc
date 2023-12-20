using System.Runtime.ExceptionServices;

namespace Day01.Davide {
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

        public long GetSum => Numbers.Sum();

        public CalibrationReader(string[] lines){
            foreach (string line in lines)
            {
                var number = $"{FindFirstOrLastNumber(line, false)}{FindFirstOrLastNumber(line, true)}";
                if (string.IsNullOrEmpty(number)){
                    throw new ArgumentException("Fehler: Line enthält keine Zahlen.");
                }

                if (int.TryParse(number, out int parsedNumber))
                {
                    // Das Parsen war erfolgreich
                    Numbers.Add(parsedNumber);
                }
                else
                {
                    // Das Parsen war nicht erfolgreich
                    throw new ArgumentException($"Fehler: Beim Parsen der Zeichenfolge: {number}");
                }
            }

            CheckNumbersList();
        }

        /// <summary>
        ///     Überprüfung auf Implementatonsfehler
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        private void CheckNumbersList(){
            if (Numbers.Any(s => s > 99)){
                throw new ArgumentException("Fehler: Eine Zahl grösser als 100.");           
            }

            if (Numbers.Any(s => s < 10)){
                throw new ArgumentException("Fehler: Eine Zahl kleiner als 10.");           
            }
        }

        /// <summary>
        ///     Findet die erste oder letzte Zahl in einem String. Die Zahl kann entweder "geschrieben" (one) oder als Zahl vorkommen.
        ///     Wenn die letzte gesucht werden soll muss das Boolean last true gesetzt werden.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static int FindFirstOrLastNumber(string line, bool last = false){
            int? number = default;
            int indexBest = int.MaxValue;
            // Wenn die letzte Zahl gefunden werden soll werden der Suchstring und die Wörter umgedreht
            // So wird sichergestellt, dass wirklich immer die erste/letzte Zahl gefunden wird.
            // z.B. ...twofivetwo würde letzte Zahl sonst 5 herausgeben
            string remainingLine = last ? new String(line.Reverse().TakeWhile(Char.IsLetter).ToArray()) 
                    : new String(line.TakeWhile(Char.IsLetter).ToArray());
                    
            if (!string.IsNullOrEmpty(remainingLine)){
                foreach(var spelledNumber in NumbersDictionary){
                    string searchText = last ? new string(spelledNumber.Key.ToCharArray().Reverse().ToArray()) : spelledNumber.Key;
                    var index = remainingLine.IndexOf(searchText, StringComparison.OrdinalIgnoreCase);
                    // Wort gefunden bei Index >=0.
                    if (index >= 0 && (index < indexBest)){
                        number = spelledNumber.Value;
                        indexBest = index;
                    }
                    // Wenn Position an erster Stelle ist muss nicht weiter gesucht werden
                    if (indexBest == 0){
                        break;
                    }
                }
            }

            if (!number.HasValue){
                char c = last ? line.Where(char.IsDigit).Last() : line.Where(char.IsDigit).First();
                return int.Parse(c.ToString());
            }

            return (int)number;
        }
    
    }
}