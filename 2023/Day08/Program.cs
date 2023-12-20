using System.Diagnostics;
using AocShared;

namespace Day08;

class Program {

    static void Main() {
        if (File.Exists(FileReader.RetoPath)){
            Reto.Solution.Run();
        }
        if (File.Exists(FileReader.DavidePath)){
            Davide.Solution.Run();
        } 
    }
}
