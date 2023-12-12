public class Permutations
{
    private readonly List<char> CharList;

    public Permutations(List<char> charList)
    {
        CharList = charList;
    }

    public List<string> GenerateCharCombinations(int combinationLength)
    {
        if (combinationLength <= 0)
        {
            throw new ArgumentException("Die Kombinationslänge muss größer als 0 sein.");
        }

        return GenerateCombinationsInternal(combinationLength).ToList();
    }

    private IEnumerable<string> GenerateCombinationsInternal(int combinationLength)
    {
        if (combinationLength == 1)
        {
            return CharList.Select(c => c.ToString());
        }

        return CharList.SelectMany(c =>
            GenerateCombinationsInternal(combinationLength - 1),
            (c, suffix) => c + suffix);
    }
}
