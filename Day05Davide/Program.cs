using AocShared;

namespace Day05Davide {
    class Program {
        private static void Main() {
            FileReader fileReader = new();
            List<long> seeds = fileReader.Lines[0][6..]
                .Trim()
                .Split(" ")
                .Select(long.Parse)
                .ToList();
            List<GardenMapper> gardenMappers = new();
            List<MappingInfo> mappingInfos = new();

            for (int i = 0; i < fileReader.Lines.Length; i++) {
                if (!string.IsNullOrEmpty(fileReader.Lines[i]) && char.IsDigit(fileReader.Lines[i][0]))
                {
                    var numbers = fileReader.Lines[i].Trim().Split(" ").Select(long.Parse).ToList();
                    mappingInfos.Add(new MappingInfo(numbers[0], numbers[1], numbers[2]));

                }  else if (mappingInfos.Count > 0) {
                    gardenMappers.Add(new GardenMapper(mappingInfos));
                    mappingInfos = new();
                }
            }
            gardenMappers.Add(new GardenMapper(mappingInfos));

            List<long> locations = new();
            foreach (var seed in seeds) {
                long? location = default;
                foreach (var gardenMapper in gardenMappers) {
                    location = gardenMapper.MapSource(location ?? seed);
                }
                locations.Add((long)location);
            }

            Console.WriteLine($"Min location Part1: {locations.Min()}");

            // Part 2
            List<MapRange> ranges = new();
            for (int i = 0; i < seeds.Count; i++) {
                var min = seeds[i];
                i++;
                var max = min + seeds[i];
                ranges.Add(new MapRange(min, max - 1));
            }

            // TestOverlappingRanges(ranges);

            long locationPart2 = long.MaxValue;

            foreach (MapRange range in ranges)
            {
                Parallel.For(0, range.Max + 1, seed => 
                {
                    long? location = default;
                    foreach (var gardenMapper in gardenMappers)
                    {
                        location = gardenMapper.MapSource(location ?? seed);
                    }
                    Interlocked.Exchange(ref locationPart2, Math.Min(location ?? long.MaxValue, locationPart2));
                });
            }
            Console.WriteLine("Final New Location: " + locationPart2);
        }

        private static void TestOverlappingRanges(List<MapRange> ranges){
            for (int i = 0; i < ranges.Count; i++)
                {
                    for (int j = i + 1; j < ranges.Count; j++) {

                        Console.WriteLine(ranges[i].OverlappingInput(ranges[j]));
                        Console.WriteLine(ranges[i].NumberInsideRange(ranges[j].Max));
                        Console.WriteLine(ranges[i].NumberInsideRange(ranges[j].Min));

                        Console.WriteLine(ranges[j].OverlappingInput(ranges[i]));
                        Console.WriteLine(ranges[j].NumberInsideRange(ranges[i].Max));
                        Console.WriteLine(ranges[j].NumberInsideRange(ranges[i].Min));
                        Console.WriteLine();
                    }
                }
                // my ranges aren't overlapping so no performance gain
        }
    }


}