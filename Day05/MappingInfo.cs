namespace Day05;

public class MappingInfo {

    public MappingInfo(long destinationRangeStart, long sourceRangeStart, long length) {
        DestinationRangeStart = destinationRangeStart;
        DestinationRangeEnd = destinationRangeStart + length - 1;
        SourceRangeStart = sourceRangeStart;
        SourceRangeEnd = SourceRangeStart + length - 1;
    }

    public readonly long DestinationRangeStart;
    public readonly long DestinationRangeEnd;
    public readonly long SourceRangeStart;
    public readonly long SourceRangeEnd;
}
