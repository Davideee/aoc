namespace Day05Davide;

public class MappingInfo {

    public MappingInfo(long destinationRangeStart, long sourceRangeStart, long length) {
        DestinationRangeStart = destinationRangeStart;
        SourceRangeStart = sourceRangeStart;
        SourceRangeEnd = SourceRangeStart + length - 1;
    }

    public readonly long DestinationRangeStart;
    public readonly long SourceRangeStart;
    public readonly long SourceRangeEnd;
}
