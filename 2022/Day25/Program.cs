
using AocShared;

class Program
{
    static void Main()
    {
        FileReader fileReader = new();

        // Eine Map erstellen (Schlüssel ist vom Typ string, Wert ist vom Typ int)
        Dictionary<string, double> snafuMap = new();

        double gasCounter = 0;
        foreach (var line in fileReader.Lines)
        {
            var number = GetDecimalFromSnafu(line);
            snafuMap.Add(line, number);
            gasCounter += number;
        }

        Console.WriteLine($"total: {gasCounter}");

        string totalSnafuGas = AddSnafu(fileReader.Lines[0], fileReader.Lines[1]);
        for (var i = 2; i < fileReader.Lines.Length; i++)
        {
            totalSnafuGas = AddSnafu(totalSnafuGas, fileReader.Lines[i]);
        }
        Console.WriteLine($"TOTAL DECIMAL {GetDecimalFromSnafu(totalSnafuGas)}");
        Console.WriteLine($"CHECK: {(gasCounter - GetDecimalFromSnafu(totalSnafuGas)) == 0}");
        Console.WriteLine($"TOTAL IN SNAFU {totalSnafuGas}");
    }

    static string AddSnafu(string snafu1, string snafu2)
    {
        var reverseSnafu1 = snafu1.ToCharArray();
        var reverseSnafu2 = snafu2.ToCharArray();
        Array.Reverse(reverseSnafu1);
        Array.Reverse(reverseSnafu2);
        var length1 = reverseSnafu1.Count();
        var length2 = reverseSnafu2.Count();

        string newSnafu = String.Empty;
        string keep1 = string.Empty;
        string keep2 = string.Empty;
        string tempKeep = string.Empty;
        for (int i = 0; i < Math.Max(length1, length2); i++)
        {
            char? char1 = length1 > i ? reverseSnafu1[i] : default(char?);
            char? char2 = length2 > i ? reverseSnafu2[i] : default(char?);

            if (!string.IsNullOrEmpty(keep2))
            {
                throw new ArgumentException("Nid guet!!");
            }
            if (char1.HasValue && char2.HasValue && !string.IsNullOrEmpty(keep1))
            {
                var tempChar1 = AddTwoSnafu($"{char1}{keep1}", ref keep1);
                newSnafu += AddTwoSnafu($"{tempChar1}{char2}", ref keep2);
                if (!string.IsNullOrEmpty(keep1) && !string.IsNullOrEmpty(keep2))
                {
                    keep1 = AddTwoSnafu($"{keep1}{keep2}", ref tempKeep);
                    keep2 = string.Empty;
                }
                else if (string.IsNullOrEmpty(keep1) && !string.IsNullOrEmpty(keep2))
                {
                    keep1 = keep2;
                    keep2 = string.Empty;
                }
            } else if (char1.HasValue && char2.HasValue)
            {
                newSnafu += AddTwoSnafu($"{char1}{char2}", ref keep1);
            }
            else if ((!char1.HasValue || !char2.HasValue) && !string.IsNullOrEmpty(keep1))
            {
                var temp = char1.HasValue ? char1.ToString() : char2.ToString();
                newSnafu += AddTwoSnafu($"{temp}{keep1}", ref keep1);

            }
            else if ((!char1.HasValue || !char2.HasValue) && string.IsNullOrEmpty(keep1))
            {
                newSnafu += char1.HasValue ? char1.ToString() : char2.ToString();
            }
        }

        if (!string.IsNullOrEmpty(keep1))
        {
            newSnafu += keep1;
        }
        char[] charArray = newSnafu.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static string AddTwoSnafu(string snafu, ref string keep)
    {
        switch (snafu)
        {
            case "00":
            case "2=":
            case "=2":
            case "1-":
            case "-1":
                keep = String.Empty;
                return "0";
            case "10":
            case "01":
            case "2-":
            case "-2":
                keep = String.Empty;
                return "1";
            case "11":
            case "20":
            case "02":
                keep = String.Empty;
                return "2";
            case "=1":
            case "1=":
            case "0-":
            case "-0":
                keep = String.Empty;
                return "-";
            case "0=":
            case "=0":
            case "--":
                keep = String.Empty;
                return "=";
            case "==":
                keep = "-";
                return "1";
            case "=-":
            case "-=":
                keep = "-";
                return "2";
            case "22":
                keep = "1";
                return "-";
            case "12":
            case "21":
                keep = "1";
                return "=";
            default:
                throw new ArgumentException($"Undefinierter Buchstabe enthalten, {snafu}");
        }
    }

    static double GetDecimalFromSnafu(string snafuLine)
    {
        double dec = 0;
        int power = 0;
        var reversedSnafuLine = snafuLine.Reverse();
        foreach (var c in reversedSnafuLine)
        {
            dec += Math.Pow(5, power) * GetSingleSnafu(c);
            power++;
        }

        return dec;
    }

    static int GetSingleSnafu(char snafu)
    {
        switch (snafu)
        {
            case '2':
                return 2;
            case '1':
                return 1;
            case '0':
                return 0;
            case '-':
                return -1;
            case '=':
                return -2;
            default:
                throw new ArgumentException($"Undefinierter Buchstabe enthalten, {snafu}");
        }
    }

}