namespace Day05Davide; 

public class MapRange {
    public long Min;
    public long Max;
    public MapRange(long min, long max) {
        Min = min;
        Max = max;
    }

    public bool OverlappingInput(MapRange range)
    {
        return Min <= range.Min && range.Max <= Max;
    }

    public bool NumberInsideRange(long num) {
        return Min <= num && num <= Max;
    }
}