using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1028try1
{
    internal class Program
    {
        static int ySize;
        static int xSize;
        static bool isInside(int min, int max, int val) => (max >= val) && (val >= min);
        static bool isAvailableIndex(int x, int y)
        {
            return isInside(0, xSize - 1, x)
                && isInside(0, ySize - 1, y);
        }

        static void Main(string[] args)
        {
            int result = 0;

            string[] recvLineYX = Console.ReadLine().Split(' ');
            xSize = int.Parse(recvLineYX[1]);
            ySize = int.Parse(recvLineYX[0]);

            char[,] map = new char[xSize, ySize];

            int[,] rightUpCount = new int[xSize, ySize];
            int[,] leftUpCount = new int[xSize, ySize];

            int[,] rightDownCount = new int[xSize, ySize];
            int[,] leftDownCount = new int[xSize, ySize];

            for (int y = 0; y < ySize; y++)
            {
                string line = Console.ReadLine();
                for (int x = 0; x < xSize; x++)
                {
                    map[x, y] = line[x];

                    if (map[x, y] == '0') continue;

                    // 왼쪽 위가 해당 범위 내인경우 + 왼쪽 위가 0이 아닌경우
                    leftUpCount[x, y] = 1;
                    if (isAvailableIndex(x - 1, y - 1))
                    {
                        leftUpCount[x, y] += leftUpCount[x - 1, y - 1];
                    }
                    rightUpCount[x, y] = 1;
                    if (isAvailableIndex(x + 1, y - 1))
                    {
                        rightUpCount[x, y] += rightUpCount[x + 1, y - 1];
                    }
                }
            }

            for (int y = ySize - 1; y > -1; --y)
            {
                for (int x = 0; x < xSize; ++x)
                {
                    if (map[x, y] == '0') continue;

                    // 왼쪽 위가 해당 범위 내인경우 + 왼쪽 위가 0이 아닌경우

                    leftDownCount[x, y] = 1;
                    if (isAvailableIndex(x - 1, y + 1))
                    {
                        leftDownCount[x, y] += leftDownCount[x - 1, y + 1];
                    }
                    rightDownCount[x, y] = 1;
                    if (isAvailableIndex(x + 1, y + 1))
                    {
                        rightDownCount[x, y] += rightDownCount[x + 1, y + 1];
                    }
                }
            }

            for (int y = 0; y < ySize; ++y)
            {
                for (int x = 0; x < xSize; ++x)
                {
                    for (int size = 1, bottomY = y + (size - 1) * 2; bottomY < ySize; ++size, bottomY = y + (size - 1) * 2)
                    {
                        if (rightDownCount[x, y] >= size &&
                            leftDownCount[x, y] >= size &&
                            rightUpCount[x, bottomY] >= size &&
                            leftUpCount[x, bottomY] >= size)
                        {
                            result = Math.Max(result, size);
                        }
                    }
                }
            }
            if (false)
            {
                Console.WriteLine();
                StringBuilder[] sb = new StringBuilder[4];
                for (int index = 0; index < 4; ++index)
                {
                    sb[index] = new StringBuilder();
                }
                for (int y = 0; y < ySize; ++y)
                {
                    for (int x = 0; x < xSize; ++x)
                    {
                        sb[0].Append(rightUpCount[x, y]);
                        sb[1].Append(leftUpCount[x, y]);

                        sb[2].Append(rightDownCount[x, y]);
                        sb[3].Append(leftDownCount[x, y]);

                    }
                    sb[0].Append('\n');
                    sb[1].Append('\n');
                    sb[2].Append('\n');
                    sb[3].Append('\n');
                }
                Console.WriteLine("right up");
                Console.WriteLine(sb[0]);
                Console.WriteLine("left up");
                Console.WriteLine(sb[1]);
                Console.WriteLine("right down");
                Console.WriteLine(sb[2]);
                Console.WriteLine("left down");
                Console.WriteLine(sb[3]);
            }
            Console.WriteLine(result);
        }
    }
}
