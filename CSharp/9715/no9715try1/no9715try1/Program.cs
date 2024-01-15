using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9715try1
{
    internal class Program
    {
        static int GetResult()
        {
            int result = 0;

            string[] sizeString = Console.ReadLine().Split(' ');

            int ySize = int.Parse(sizeString[0]);
            int xSize = int.Parse(sizeString[1]);
            int[,] grid = new int[xSize, ySize];

            // init
            for (int y = 0; y < ySize; ++y)
            {
                string recvLine = Console.ReadLine();
                for (int x = 0; x < xSize; ++x)
                {
                    grid[x, y] = recvLine[x] - '0';
                    if (grid[x, y] > 0) result += 2; // 윗면과 아랫면을 모두 더합니다.
                    result += grid[x, y] * 4; // 만약 모든 면이 떨어져 있다고 가정합니다.
                }
            }

            // 겹치는 부위 제거
            for (int height = 1; height < 10; height++)
            {
                for (int y = 0; y < ySize; ++y)
                {
                    for (int x = 0; x < xSize; ++x)
                    {
                        if (x > 0) if (grid[x, y] >= height && grid[x - 1, y] >= height) result -= 2;
                        if (y > 0) if (grid[x, y] >= height && grid[x, y - 1] >= height) result -= 2;
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{GetResult()}");
            }
        }
    }
}
