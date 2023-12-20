using AocShared;

namespace Day15.Davide;

public class Solution {
    public static void Run() {
        Part1();
        Part2();
    }

    public static void Part1(){
        // © Nadja
        FileReader file = new(FileReader.DavidePath);
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
        FileReader file = new(FileReader.DavidePath);
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