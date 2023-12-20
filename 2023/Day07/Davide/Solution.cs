using AocShared;

namespace Day07.Davide;

public class Solution {
    public static void Run() {
        bool part2 = true;
        FileReader file = new FileReader(FileReader.DavidePath);
        List<CardHand> cardHands = new();
        foreach (var line in file.Lines) {
            var hand = line[..5].Trim();
            var bid = int.Parse(line[6..].Trim());
                cardHands.Add(new CardHand(hand, bid, part2));
        }

        List<CardHand> sortedCardHands = cardHands.OrderBy(objekt => objekt).ToList();

        foreach (var hand in sortedCardHands) {
            Console.WriteLine(hand);
        }
        long sum = sortedCardHands
            .Select((c, index) => c.Bid * (index + 1))
            .Sum();
        Console.WriteLine($"Part1 Sum: {sum}");

        sum = 0;
        for (int i = 0; i < sortedCardHands.Count; i++) {
            sum += sortedCardHands[i].Bid * (i + 1);
        }
        Console.WriteLine($"Part2 Sum: {sum}");
    }
}