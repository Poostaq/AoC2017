using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day16
    {
        static List<char> permutationPromenade = new List<char>(Enumerable.Range('a', 'p'- 'a' +1).Select(i => (Char)i).ToList());
        static List<string> danceFigures = new List<string>();

        public static string performDance()
        {
            fillDanceFigures();
            for(int i = 0; i < danceFigures.Count; i++)
            {
                char figureType = danceFigures[i][0];
                switch (figureType)
                {
                    case 's':
                        int numberOfPrograms = Convert.ToInt32(danceFigures[i].Substring(1));
                        Spin(numberOfPrograms);
                        break;
                    case 'x':
                        string[] indexes = danceFigures[i].Substring(1).Split('/');
                        Exchange(indexes[0].ToInt32(), indexes[1].ToInt32());
                        break;
                    case 'p':
                        string[] programs = danceFigures[i].Substring(1).Split('/');
                        Partner(programs[0][0], programs[1][0]);
                        break;
                }
            }
            StringBuilder result = new StringBuilder();
            permutationPromenade.ForEach(x => result.Append(x));
            return result.ToString();
        }

        public static string performDance2Stars()
        {
            fillDanceFigures();
            int permutationsLoop = 0;
            List<string> positionPermutations = new List<string>();
            for(int y = 0; y< 1000000000; y++)
            {
                performDance();
                StringBuilder resultBuilder = new StringBuilder();
                permutationPromenade.ForEach(x => resultBuilder.Append(x));
                string result = resultBuilder.ToString();
                if (positionPermutations.Contains(result))
                {
                    permutationsLoop = y;
                    break;
                }
                else
                {
                    positionPermutations.Add(result.ToString());
                }
            }
            string finalResult = positionPermutations[(1000000000 % positionPermutations.Count) - 1];
            return finalResult;
        }

        private static void fillDanceFigures()
        {
            var List = File.ReadAllLines(Program.InputFolderPath + "InputDay16.txt")[0];
            danceFigures = List.Split(',').ToList();
        }

        private static void Spin(int numberOfPrograms)
        {
            List<char> tempList = new List<char>();
            for(int i = 0; i < permutationPromenade.Count; i++)
            {
                tempList.Add(permutationPromenade
                    [((i + permutationPromenade.Count - numberOfPrograms) % (permutationPromenade.Count))]);
            }
            permutationPromenade = tempList;
        }

        private static void Exchange(int indexA, int indexB)
        {
            char tempCharA = permutationPromenade[indexA];
            char tempCharB = permutationPromenade[indexB];
            permutationPromenade[indexB] = tempCharA;
            permutationPromenade[indexA] = tempCharB;
        }

        private static void Partner(char programA, char programB)
        {
            int tempIndexA = permutationPromenade.FindIndex(x => x == programA);
            int tempIndexB = permutationPromenade.FindIndex(x => x == programB);
            permutationPromenade[tempIndexA] = programB;
            permutationPromenade[tempIndexB] = programA;
        }


    }

    static class extensions
    {
        public static int ToInt32(this string str)
        {
            return Convert.ToInt32(str);
        }
    }
}
