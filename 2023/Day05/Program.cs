using AocShared;

namespace Day05 {
    class Program {
        private static void Main() {
            if (File.Exists(FileReader.RetoPath)){
                Reto.Solution.Run();
            }
            if (File.Exists(FileReader.DavidePath)){
                Davide.Solution.Run();
            }
        }

    }
}