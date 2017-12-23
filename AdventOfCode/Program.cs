using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {

        public static string InputFolderPath { get; private set; }

        static Program()
        {
            InputFolderPath = Directory.GetCurrentDirectory();
            InputFolderPath = Path.Combine(InputFolderPath, "..\\..\\");
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(Day1.calculateSum());
            //Console.WriteLine(Day1.calculateSum2Stars());
            //Console.WriteLine(Day2.calculateChecksum());
            //Console.WriteLine(Day2.calculateChecksum2Stars());
            //Console.WriteLine(Day3.calculateDistance());
            //Console.WriteLine(Day3.calculateDistance2Stars());
            //Console.WriteLine(Day16.performDance());
            //Console.WriteLine(Day16.performDance2Stars());
			Day19.collectingLetters();

            Console.ReadKey();
        }


    }
}
