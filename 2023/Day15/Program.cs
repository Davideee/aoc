using System.Linq.Expressions;
using AocShared;


namespace Day14
{
    class Program
    {
        static void Main()
        {
            Part1();
            Part2();
        }

        public static void Part1(){
            // © Nadja
            FileReader file = new();
            List<string> InitializationSequences = file.Lines[0].Split(",").Select(s => s.Trim()).ToList();
            
            long total = 0;

            foreach (string sequence in InitializationSequences)
            {
                char[] charArray = sequence.ToCharArray();
                int mapped = 0;
                int value = 0;

                for (int i = 0; i < charArray.Length; i++)
                {
                    mapped = (byte)charArray[i];
                    value = (value + mapped) * 17 % 256;
                }
                
                total += value;
            }

            Console.WriteLine(total);
        }

        public static void Part2(){
            FileReader file = new();
            List<string> InitializationSequences = file.Lines[0].Split(",").Select(s => s.Trim()).ToList();

            List<Box> boxes = new();
            foreach (string sequence in InitializationSequences)
            {
                string label = new string(sequence.TakeWhile(s => s != '=' && s != '-').ToArray());
                bool removeOperation = sequence.Contains('-');
                bool addOperation = sequence.Contains('=');
                int? focusLength = sequence.Any(char.IsNumber) ? int.Parse(string.Concat(sequence.Where(char.IsNumber))) : null;
                int boxId = GetHash(label);
                if (addOperation && focusLength.HasValue){
                    Box box = boxes.FirstOrDefault(b => b.BoxId == boxId);
                    if (box == null){
                        box = new(boxId);
                        boxes.Add(box);
                    }
                    Lens lens = new(label, (int)focusLength);
                    box.CreateOrUpdateLens(lens);
                } else if (removeOperation){
                    Box box = boxes.FirstOrDefault(b => b.BoxId == boxId);
                    box?.RemoveLens(label);
                }
            }
            long totalCounts = boxes.Select(b => b.GetCount).Sum();
            Console.WriteLine(totalCounts);
        } 

        private static int GetHash(string str){
            char[] charArray = str.ToCharArray();
            int value = 0;
            for (int i = 0; i < charArray.Length; i++)
            {
                int mapped = (byte)charArray[i];
                value = (value + mapped) * 17 % 256;
            }
            return value;
        }
    }

    public class Box {
        public int BoxId;
        public List<Lens> Lenses = new();
        public Box(int box){
            BoxId = box;
        }

        public void CreateOrUpdateLens(Lens newLens){
            Lens oldLens = Lenses.FirstOrDefault(s => newLens.Label == s.Label);
            if (oldLens == null){
                Lenses.Add(newLens);
            } else {
                oldLens.FocusLength = newLens.FocusLength;
            }
        }

        public void RemoveLens(string label){
            Lens lens = Lenses.Find(l => l.Label == label);
            if (lens != null)
            {
                Lenses.Remove(lens);
            }
        }

        public long GetCount => Lenses.Select((l, index) => (index + 1) * l.FocusLength * (BoxId + 1)).Sum();
    }

    public class Lens {
        public int FocusLength;
        public string Label;
        public Lens(string label, int focusLength){
            FocusLength = focusLength;
            Label = label;
        }
    }

}




