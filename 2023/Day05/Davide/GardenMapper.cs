namespace Day05.Davide;

public class GardenMapper {
    private readonly List<MappingInfo> _mappingInfos;
    public GardenMapper(List<MappingInfo> mappingInfos) {
        _mappingInfos = mappingInfos;
    }

    public long MapSource(long source) {
        // LINQ -> bad performance for part 2
        // long? mapped = _mappingInfos
        //     .Where(m => m.SourceRangeStart <= source && source <= m.SourceRangeEnd)
        //     .Select(m => (long?)(source - m.SourceRangeStart + m.DestinationRangeStart))
        //     .FirstOrDefault();

        long? mapped = default;
        foreach (var mappingInfo in _mappingInfos) {
            if (mappingInfo.SourceRangeStart <= source && source <= mappingInfo.SourceRangeEnd) {
                mapped = (source - mappingInfo.SourceRangeStart + mappingInfo.DestinationRangeStart);
            }
        }
        return mapped ?? source;
    }

    // TODO Not correct
    public long MapLocation(long location) {
        long? mapped = default;

        foreach (var mappingInfo in _mappingInfos) {
            if (mappingInfo.DestinationRangeStart <= location && location <= mappingInfo.DestinationRangeEnd) {
                mapped = (location - mappingInfo.DestinationRangeStart + mappingInfo.DestinationRangeStart);
            }
        }
        return mapped ?? location;
    }
}