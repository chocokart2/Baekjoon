using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no16931try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            string[] sizeString = Console.ReadLine().Split(' ');
            int xSize = int.Parse(sizeString[1]);
            int ySize = int.Parse(sizeString[0]);
            int[,] grid = new int[xSize, ySize];
            for (int y = 0; y < ySize; ++y)
            {
                string[] oneLine = Console.ReadLine().Split(' ');
                
                for (int x = 0; x < xSize; ++x)
                {
                    grid[x, y] = int.Parse(oneLine[x]);
                    if (grid[x, y] > 0)
                    {
                        result += 2;
                    }
                    result += grid[x, y] * 4;
                    if (x > 0)
                    {
                        result -= Math.Min(grid[x - 1, y], grid[x, y]) * 2;
                    }
                    if (y > 0)
                    {
                        result -= Math.Min(grid[x, y - 1], grid[x, y]) * 2;
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
