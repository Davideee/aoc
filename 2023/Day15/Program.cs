﻿using AocShared;


namespace Day15
{
    class Program
    {
        static void Main()
        {            
            if (File.Exists(FileReader.RetoPath)){
                Reto.Solution.Run();
            }
            if (File.Exists(FileReader.DavidePath)){
                Davide.Solution.Run();
            } 
        }
    }
}




