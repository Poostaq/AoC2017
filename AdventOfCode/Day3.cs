using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Day3
    {
        static int spiralDistanceHorizontalMax = 1;
        static int spiralDistanceVerticalMax = 1;
        static int spiralDistanceHorizontalCurrent = 0;
        static int spiralDistanceVerticalCurrent = 0;
        enum direction
        {
            HORIZONTALPLUS = 0,
            VERTICALPLUS = 1,
            HORIZONTALMINUS = 2,
            VERTICALMINUS = 3
        }
        static direction currentDirection = direction.HORIZONTALPLUS;

        static Dictionary<int, Tuple<int,int>> valueCoordinates = new Dictionary<int, Tuple<int,int>>();
        static List<Node> valueAtCoordinates = new List<Node>();
        public static int calculateDistance()
        {
            int result = 0;
            valueCoordinates[1] = new Tuple<int, int>(spiralDistanceHorizontalCurrent, spiralDistanceVerticalCurrent);
            for (int i = 2; i <= 325489; i++)
            {
                switch (currentDirection)
                {
                    case direction.HORIZONTALMINUS:
                        {
                            spiralDistanceHorizontalCurrent--;
                            break;
                        }
                    case direction.HORIZONTALPLUS:
                        {
                            spiralDistanceHorizontalCurrent++;
                            if (spiralDistanceVerticalCurrent == 0 && spiralDistanceHorizontalCurrent == 1)
                            {
                                currentDirection = (direction)(((int)currentDirection + 1) % 4);
                            }
                            break;
                        }
                    case direction.VERTICALMINUS:
                        {
                            spiralDistanceVerticalCurrent--;
                            break;
                        }
                    case direction.VERTICALPLUS:
                        {
                            spiralDistanceVerticalCurrent++;
                            break;
                        }
                }
                
                if(Math.Abs(spiralDistanceVerticalCurrent) == Math.Abs(spiralDistanceVerticalMax) &&
                    Math.Abs(spiralDistanceHorizontalCurrent) == Math.Abs(spiralDistanceHorizontalMax))
                {
                    currentDirection = (direction)(((int)currentDirection + 1) % 4);
                }
                if (spiralDistanceVerticalCurrent == -spiralDistanceVerticalMax && spiralDistanceHorizontalCurrent == -spiralDistanceHorizontalMax)
                {
                    spiralDistanceHorizontalMax++;
                }
                if (spiralDistanceVerticalCurrent == -spiralDistanceVerticalMax && spiralDistanceHorizontalCurrent == spiralDistanceHorizontalMax)
                {
                    spiralDistanceVerticalMax++;
                }
                valueCoordinates[1] = new Tuple<int, int>(spiralDistanceHorizontalCurrent, spiralDistanceVerticalCurrent);
            }
            result = Math.Abs(spiralDistanceVerticalCurrent) + Math.Abs(spiralDistanceHorizontalCurrent);
            return result;
        }

        public static int calculateDistance2Stars()
        {
            int result = 0;
            valueAtCoordinates.Add(new Node(0, 0, 1));
            for (int i = 1; i < 325489; i++)
            {
                switch (currentDirection)
                {
                    case direction.HORIZONTALMINUS:
                        {
                            spiralDistanceHorizontalCurrent--;
                            break;
                        }
                    case direction.HORIZONTALPLUS:
                        {
                            spiralDistanceHorizontalCurrent++;
                            if (spiralDistanceVerticalCurrent == 0 && spiralDistanceHorizontalCurrent == 1)
                            {
                                currentDirection = (direction)(((int)currentDirection + 1) % 4);
                            }
                            break;
                        }
                    case direction.VERTICALMINUS:
                        {
                            spiralDistanceVerticalCurrent--;
                            break;
                        }
                    case direction.VERTICALPLUS:
                        {
                            spiralDistanceVerticalCurrent++;
                            break;
                        }
                }
                if (Math.Abs(spiralDistanceVerticalCurrent) == Math.Abs(spiralDistanceVerticalMax) &&
                    Math.Abs(spiralDistanceHorizontalCurrent) == Math.Abs(spiralDistanceHorizontalMax))
                {
                    currentDirection = (direction)(((int)currentDirection + 1) % 4);
                }
                if (spiralDistanceVerticalCurrent == -spiralDistanceVerticalMax && spiralDistanceHorizontalCurrent == -spiralDistanceHorizontalMax)
                {
                    spiralDistanceHorizontalMax++;
                }
                if (spiralDistanceVerticalCurrent == -spiralDistanceVerticalMax && spiralDistanceHorizontalCurrent == spiralDistanceHorizontalMax)
                {
                    spiralDistanceVerticalMax++;
                }
                int valueForCoords = valueAtCoordinates.FindAll(x => Math.Abs(x.y-spiralDistanceVerticalCurrent) <= 1 && Math.Abs(x.x- spiralDistanceHorizontalCurrent) <= 1).Sum(x => x.value);
                if (valueForCoords > 325489)
                {
                    result = valueForCoords;
                    break;
                }
                Console.WriteLine("Adding new Node: " + spiralDistanceVerticalCurrent + " " + spiralDistanceHorizontalCurrent + " " + valueForCoords);
                valueAtCoordinates.Add(new Node(spiralDistanceVerticalCurrent, spiralDistanceHorizontalCurrent, valueForCoords));
            }
            return result;
        }
    }
    /*
    class Day3TwoStars
    {
        static int spiralDistanceHorizontalMax = 1;
        static int spiralDistanceVerticalMax = 1;
        static int spiralDistanceHorizontalCurrent = 0;
        static int spiralDistanceVerticalCurrent = 0;
        enum direction
        {
            HORIZONTALPLUS = 0,
            VERTICALPLUS = 1,
            HORIZONTALMINUS = 2,
            VERTICALMINUS = 3
        }
        static direction currentDirection = direction.HORIZONTALPLUS;
        static List<Node> valueAtCoordinates = new List<Node>();
        public static int calculateDistance()
        {
            int result = 0;
            valueAtCoordinates.Add(new Node(0, 0, 1));
            for(int i = 1; i < 325489; i++)
            {
                switch (currentDirection)
                {
                    case direction.HORIZONTALMINUS:
                        {
                            spiralDistanceHorizontalCurrent--;
                            break;
                        }
                    case direction.HORIZONTALPLUS:
                        {
                            spiralDistanceHorizontalCurrent++;
                            if (spiralDistanceVerticalCurrent == 0 && spiralDistanceHorizontalCurrent == 1)
                            {
                                currentDirection = (direction)(((int)currentDirection + 1) % 4);
                            }
                            break;
                        }
                    case direction.VERTICALMINUS:
                        {
                            spiralDistanceVerticalCurrent--;
                            break;
                        }
                    case direction.VERTICALPLUS:
                        {
                            spiralDistanceVerticalCurrent++;
                            break;
                        }
                }
                if (Math.Abs(spiralDistanceVerticalCurrent) == Math.Abs(spiralDistanceVerticalMax) &&
                    Math.Abs(spiralDistanceHorizontalCurrent) == Math.Abs(spiralDistanceHorizontalMax))
                {
                    currentDirection = (direction)(((int)currentDirection + 1) % 4);
                }
                if (spiralDistanceVerticalCurrent == -spiralDistanceVerticalMax && spiralDistanceHorizontalCurrent == -spiralDistanceHorizontalMax)
                {
                    spiralDistanceHorizontalMax++;
                }
                if (spiralDistanceVerticalCurrent == -spiralDistanceVerticalMax && spiralDistanceHorizontalCurrent == spiralDistanceHorizontalMax)
                {
                    spiralDistanceVerticalMax++;
                }
                int valueForCoords = valueAtCoordinates.FindAll(x => Math.Abs(x.y - spiralDistanceHorizontalCurrent) >= 1 && Math.Abs(x.x - spiralDistanceVerticalCurrent) >= 1).Sum(x => x.value);
                if(valueForCoords > 325489)
                {
                    result = valueForCoords;
                    break;
                }
                valueAtCoordinates.Add(new Node(spiralDistanceVerticalCurrent, spiralDistanceHorizontalCurrent, valueForCoords));
            }
            return result;
        }
    }
    */
    class Node
    {
        public int x, y, value;

        public Node(int y, int x, int value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
        }
    }
}
