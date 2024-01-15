using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no28438try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] sizes = Console.ReadLine().Split(' ');
            int xSize = int.Parse(sizes[1]);
            int ySize = int.Parse(sizes[0]);
            int queryCount = int.Parse(sizes[2]);

            int[] ySum = new int[ySize]; // 해당 행의 합
            int[] xSum = new int[xSize]; // 해당 열의 합

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < queryCount; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                int index = int.Parse(recvLine[1]) - 1;
                int value = int.Parse(recvLine[2]);

                if (recvLine[0][0] == '1')
                {
                    ySum[index] += value;
                }
                else
                {
                    xSum[index] += value;
                }
            }

            for (int y = 0; y < ySize; ++y)
            {
                result.Append((xSum[0] + ySum[y]));
                for (int x = 1; x < xSize; ++x)
                {
                    result.Append($" {xSum[x] + ySum[y]}");
                }
                result.Append('\n');
            }

            Console.Write(result);
        }
    }
}
