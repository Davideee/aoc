namespace Day05Davide; 

class Range {
    public long Min;
    public long Max;
    public Range(long min, long max) {
        Min = min;
        Max = max;
    }

    public bool OverlappingInput(Range range)
    {
        return Min <= range.Min && range.Max <= Max;
    }

    public bool NumberInsideRange(long num) {
        return Min <= num && num <= Max;
    }
}