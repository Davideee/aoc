using System;
using System.Text.RegularExpressions;

namespace Day01.Reto
{
    class CalibrationChecker
    {




        // Eine Methode, um eine Zeile zu überprüfen
        public int CalculateSum(string[] lines)
        {
              int sum = 0;
             

        //alle Lines iterieren
        foreach (string line in lines){
            //erstes Zeichen pro Line finden
               string firstDigit = Regex.Match(line, @"\d").Value;
            //letztes Zeichen pro Line finden (Ziffer die gefolgt wird von einer beliebigen Anzahl Nicht-Ziffern)
               string lastDigit = Regex.Match(line, @"\d(?=[^\d]*$)").Value;
               // Console.WriteLine("Line"+line+"   Fd:"+firstDigit+"   LD:"+lastDigit);

                //firstDigit und lastDigit Pärchen addieren
                string twoDigitNumber = firstDigit + lastDigit;

                //aus String in Int umwandeln
                int calibrationValue = int.Parse(twoDigitNumber);
                //summe laufend mit den entsprechenden Werten addieren
                sum += calibrationValue;
        }


            return sum;     
        }
    }
}
