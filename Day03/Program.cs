using AocShared;

namespace Day03
{
    class Program
    {
        static void Main()
        {
            var fileReader = new FileReader();
            EngineSchematicsReader engineSchematicsReader = new(fileReader.Lines);
            Console.WriteLine($"Part1 Sum:{engineSchematicsReader.SumValidSchemaNumbers}"); 
            Console.WriteLine($"Part2 Sum:{engineSchematicsReader.SumGears}"); 

        }

    }
}
