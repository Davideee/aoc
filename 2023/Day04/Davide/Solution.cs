using AocShared;

namespace Day04.Davide;

public class Solution {
    public static void Run() {
            FileReader fileReader = new();
            List<Scratchcard> scratchcards = new();
            double counter = 0;
            List<int> scratchCardIdsCopied = new();
            foreach (var line in fileReader.Lines) {
                Scratchcard scratchcard = new (line);
                scratchcards.Add(scratchcard);
                scratchCardIdsCopied.AddRange(scratchcard.GetCopiedIds());
                counter += scratchcard.GetCountTask1();
            }
            Console.WriteLine($"Summe Task 1: {counter}");

            List<int> tempScratchCardIds = scratchCardIdsCopied.ToList();
            scratchCardIdsCopied.Clear();
            while (tempScratchCardIds.Count != 0) {
                List<int> newCards = new();
                foreach (var id in tempScratchCardIds) {
                    newCards.AddRange(scratchcards.First(sc => sc.Id == id).GetCopiedIds());
                }
                scratchCardIdsCopied.AddRange(tempScratchCardIds);
                tempScratchCardIds = newCards.ToList();
            }

            foreach (var scratchcard in scratchcards) {
                Console.WriteLine($"Id {scratchcard.Id}: Counts {scratchCardIdsCopied.Where(sc => sc == scratchcard.Id).Count() + 1}");
            }
            Console.WriteLine($"Summe Task 2: {scratchcards.Count + scratchCardIdsCopied.Count}");
    }
}