using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no14846try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine()) + 1;
            int[,,] sums = new int[size, size, 10];
            for (int y = 1; y < size; y++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                for (int x = 1; x < size; ++x)
                {
                    int one = int.Parse(nums[x - 1]) - 1;
                    for (int num = 0; num < 10; ++num)
                    {
                        sums[x, y, num] = ((one == num) ? 1 : 0) + sums[x - 1, y, num] + sums[x, y - 1, num] - sums[x - 1, y - 1, num];
                    }
                }
            }

            int query = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int q = 0; q < query; ++q)
            {
                int count = 0;
                string[] position = Console.ReadLine().Split(' ');

                int startX = int.Parse(position[1]) - 1;
                int startY = int.Parse(position[0]) - 1;
                int endX = int.Parse(position[3]);
                int endY = int.Parse(position[2]);

                for (int num = 0; num < 10; ++num)
                {
                    if (sums[endX, endY, num] - sums[startX, endY, num] - sums[endX, startY, num] + sums[startX, startY, num] > 0)
                    {
                        count++;
                    }

                }

                result.AppendLine(count.ToString());
            }
            Console.Write(result);
        }
    }
}
