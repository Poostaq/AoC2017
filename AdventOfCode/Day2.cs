using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day2
    {
        static List<List<int>> numbers = new List<List<int>>();

        public static int calculateChecksum()
        {
            int result = 0;
            fillNumbers();
            for(int i = 0; i<numbers.Count; i++)
            {
                int maxValue = numbers[i].Max();
                int minValue = numbers[i].Min();
                int valueToAppend = maxValue - minValue;
                result = result + valueToAppend;
            }
            return result;
        }

        public static int calculateChecksum2Stars()
        {
            int result = 0;
            fillNumbers();
            for(int i = 0; i<numbers.Count; i++)
            {
                for (int j = 0; j < numbers[i].Count; j++)
                {
                    for (int k = 0; k < numbers[i].Count; k++)
                    {
                        if (numbers[i][j] != numbers[i][k])
                        {
                            if (numbers[i][j] % numbers[i][k] == 0)
                            {
                                result = result + (numbers[i][j] / numbers[i][k]);
                            }
                        }

                    }
                }
            }
            return result;
        }

        private static void fillNumbers()
        {
            var List = File.ReadAllLines(Program.InputFolderPath + "InputDay2.txt");
            for(int i = 0; i<List.Length; i++)
            {
                numbers.Add(new List<int>());
                string[] stringedNumbers = List[i].Split(new char[1] { '\t' });
                for(int y = 0; y<stringedNumbers.Length; y++)
                {
                    numbers[i].Add(Convert.ToInt32(stringedNumbers[y]));
                }
            }
        }

        private static int sumNumbers(string numbers)
        {
            int results = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                results = results + (int)Char.GetNumericValue(numbers[i]);
            }
            return results;
        }
    }
}
