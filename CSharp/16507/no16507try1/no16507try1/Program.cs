using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no16507try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLineRCQ = Console.ReadLine().Split(' ');
            int ySize = int.Parse(recvLineRCQ[0]);
            int xSize = int.Parse(recvLineRCQ[1]);
            int querry = int.Parse(recvLineRCQ[2]);

            int[,] sum = new int[xSize + 1, ySize + 1];

            StringBuilder result = new StringBuilder();

            for (int y = 0; y < ySize; y++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                for (int x = 0; x < xSize; x++)
                {
                    int one = int.Parse(nums[x]);

                    sum[x + 1, y + 1] = sum[x + 1, y] + sum[x, y + 1] + one - sum[x, y];
                }
            }

            for (int i = 0; i < querry; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');

                int x1 = int.Parse(nums[1]) - 1;
                int y1 = int.Parse(nums[0]) - 1;
                int x2 = int.Parse(nums[3]);
                int y2 = int.Parse(nums[2]);

                int one = (sum[x2, y2] - sum[x1, y2] - sum[x2, y1] + sum[x1, y1]) / ((x2 - x1) * (y2 - y1));
                result.AppendLine(one.ToString());
            }

            Console.Write(result);
        }
    }
}
