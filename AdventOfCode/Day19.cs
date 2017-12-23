using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
	static class Day19
	{
		enum Direction
		{
			UP,
			DOWN,
			LEFT,
			RIGHT
		};

		private static List<string> map = new List<string>();
		private static List<char> foundLetters = new List<char>();
		private static void fillMap()
		{
			map = File.ReadAllLines(Program.InputFolderPath + "InputDay19.txt").ToList();
		}

		public static void collectingLetters()
		{
			fillMap();
			int horizontalIndex = map[0].IndexOf("|");
			int verticalIndex = 0;
			int iterator = map[0].Length * map.Count;
			Direction direction = Direction.DOWN;
			for (int i = 0; i < iterator; i++)
			{
				if (map[verticalIndex][horizontalIndex] == '|' || map[verticalIndex][horizontalIndex] == '-')
				{
					if (direction == Direction.DOWN)
					{
						Console.WriteLine("Ide w dol");
						verticalIndex++;
					}
					else if (direction == Direction.UP)
					{
						Console.WriteLine("Ide w gore");
						verticalIndex--;
					}
					else if (direction == Direction.LEFT)
					{
						Console.WriteLine("Ide w lewo");
						horizontalIndex--;
					}
					else if (direction == Direction.RIGHT)
					{
						Console.WriteLine("Ide w prawo");
						horizontalIndex++;
					}
				}
				else if (map[verticalIndex][horizontalIndex] == '+')
				{
					if (direction == Direction.DOWN || direction == Direction.UP)
					{
						if (map[verticalIndex][horizontalIndex + 1] != ' ')
						{
							horizontalIndex++;
							direction = Direction.RIGHT;
						}
						else if (map[verticalIndex][horizontalIndex - 1] != ' ')
						{
							horizontalIndex--;
							direction = Direction.LEFT;
						}
					}
					else if (direction == Direction.LEFT || direction == Direction.RIGHT)
					{
						if (map[verticalIndex + 1][horizontalIndex] != ' ')
						{
							verticalIndex++;
							direction = Direction.DOWN;
						}
						else if (map[verticalIndex - 1][horizontalIndex ] != ' ')
						{
							verticalIndex--;
							direction = Direction.UP;
						}
					}
				}
				else if (map[verticalIndex][horizontalIndex] == ' ')
				{
					break;
				}
				else
				{
					foundLetters.Add(map[verticalIndex][horizontalIndex]);
					Console.WriteLine("Znalazlem litere");
					if (direction == Direction.UP)
					{
						verticalIndex--;
					}
					else if (direction == Direction.DOWN)
					{
						verticalIndex++;
					}
					else if (direction == Direction.LEFT)
					{
						horizontalIndex--;
					}
					else if (direction == Direction.RIGHT)
					{
						horizontalIndex++;
					}
				}
			}
			foundLetters.ForEach(x => Console.Write(x));
		}
	}
}
