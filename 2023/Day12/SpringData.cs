public class SpringData
{
    private readonly Permutations Permutations;
    public readonly long PermutationCounts;
    public SpringData(string springDataRaw, int[] sequence, Permutations permutations)
    {
        Permutations = permutations;

        List<string> combinations = Permutations.GenerateCharCombinations(springDataRaw.Where(c => c == '?').Count());
        foreach (var combination in combinations)
        {
            string springDataCombination = CreateNewSpringData(springDataRaw, combination);
            int[] sequenceCombination = CountConsecutiveHashGroups(springDataCombination);
            if (sequenceCombination.SequenceEqual(sequence))
            {
                PermutationCounts++;
            }
        }
    }
    public string CreateNewSpringData(string springDataRaw, string combination)
    {
        string newSpringData = string.Empty;
        int replaced = 0;
        foreach (var c in springDataRaw)
        {
            if (c == '?')
            {
                newSpringData += combination[replaced];
                replaced++;
            }
            else
            {
                newSpringData += c;
            }
        }
        return newSpringData;
    }

    public int[] CountConsecutiveHashGroups(string input)
    {
        List<int> counts = new List<int>();
        int currentCount = 0;

        foreach (char c in input)
        {
            if (c == '#')
            {
                currentCount++;
            }
            else if (currentCount > 0)
            {
                counts.Add(currentCount);
                currentCount = 0;
            }
        }

        // Add the count of the last group if it ends with '#'
        if (currentCount > 0)
        {
            counts.Add(currentCount);
        }

        return counts.ToArray();
    }
}