using System.Runtime.Caching;

namespace Day12.Davide;

public class SpringData {
    private readonly MemoryCache Cache = MemoryCache.Default;
    private readonly string RawString;
    private readonly List<int> RawSequence;
    private readonly CacheItemPolicy _policy = new()
    {
        AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration
    };
    public readonly long Counts;


    public SpringData(string springDataRaw, List<int> sequenceRaw) {
        RawString = springDataRaw;
        RawSequence = sequenceRaw;
        Counts = GetCounts(springDataRaw, sequenceRaw);
    }

    private long GetCounts(string springData, List<int> sequence) {
        string key = $"{springData}_{string.Join(",", sequence)}";
        if (Cache.Contains(key)) {
            return (long)Cache[key];
        }
        long result = ComputeCounts(springData, sequence.ToList());
        var newItem = new CacheItem(key, result);
        Cache.Add(newItem, _policy);
        return result;
    }
    
    private long ComputeCounts(string springData, List<int> sequence) {
        switch (springData.FirstOrDefault()) {
            case '#':
                return ProcessHash(springData, sequence);
            case '.':
                // simply skip the dot
                return GetCounts(springData[1..], sequence);
            case '?':
                // create a branch: return the counts of both possibilities
                return GetCounts("#" + springData[1..], sequence) + GetCounts("." + springData[1..], sequence);
            case '\0':
                // if there are no remaining numbers in the sequence it is a match
                // if there are still some numbers it is not a solution
                return sequence.Count == 0 ? 1 : 0;
            default:
                throw new ArgumentException("Error: wrong input found");
        }
    }

    private long ProcessHash(string springData, List<int> sequence) {
        // Length of string is less than sum of sequence
        if (springData.Length < sequence.Sum()) {
            return 0;
        }

        // sequence is empty but a hash is left
        if (sequence.Count == 0) {
            return 0;
        }

        // get current number
        int number = sequence[0];
        // remove it from the list
        sequence.RemoveAt(0);
        // get next dot, if there is no dot i = -1
        int i = springData.IndexOf('.');
        int numberOfEntries = i < 0 ? springData.Length : i;

        // if the remaining string or the remaining chars to the next dot
        // are less than the current number it is not a valid solution
        if (springData.Length < number || numberOfEntries < number) {
            return 0;
        }
        // the remaining string matches exactly the length of the number
        if (springData.Length == number) {
            return GetCounts("", sequence);
        }
        // the length of the string is bigger than the number and the next dot is outside of this range
        // check if at the numbers position a '#' is -> impossible to fullfil the sequence count
        if (springData[number] == '#') {
            return 0;
        }
        // when a ? follows directly after this group, we need to define it as a dot
        if (springData[number] == '?') {
            springData = springData.Remove(number, 1).Insert(number, ".");
        }
        return GetCounts(springData[(number)..], sequence);
    }
}