using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2167try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(' ');
            int ySize = int.Parse(size[0]);
            int[,] sum = new int[int.Parse(size[1]) + 1, ySize + 1];

            for (int yIndex = 0; yIndex < ySize; ++yIndex)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                for (int xIndex = 0; xIndex < recvLine.Length; ++xIndex)
                {
                    sum[xIndex + 1, yIndex + 1] =
                        sum[xIndex + 1, yIndex] + sum[xIndex, yIndex + 1] + int.Parse(recvLine[xIndex])
                        - sum[xIndex, yIndex];
                }
            }

            int query = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            for (int i = 0; i <  query; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int startX = int.Parse(nums[1]) - 1;
                int startY = int.Parse(nums[0]) - 1;
                int endX = int.Parse(nums[3]);
                int endY = int.Parse(nums[2]);
                int one = sum[endX, endY] - sum[startX, endY] - sum[endX, startY] + sum[startX, startY];
                result.AppendLine(one.ToString());
            }
            Console.Write(result);
        }
    }
}
