using AocShared;

namespace Day03.Davide;

public class Solution {
    public static void Run() {
        var fileReader = new FileReader();
        EngineSchematicsReader engineSchematicsReader = new(fileReader.Lines);
        Console.WriteLine($"Part1 Sum:{engineSchematicsReader.SumValidSchemaNumbers}"); 
        Console.WriteLine($"Part2 Sum:{engineSchematicsReader.SumGears}"); 
    }
}