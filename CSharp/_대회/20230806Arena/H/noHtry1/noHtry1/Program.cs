using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noHtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] SizeAndCount = Console.ReadLine().Split(' ');
            int x = int.Parse(SizeAndCount[1]);
            int y = int.Parse(SizeAndCount[0]);
            int count = int.Parse(SizeAndCount[2]);

            int[,] matrix = new int[x, y];

            for (int q = 0; q < count; ++q)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int point = int.Parse(recvLine[1]) - 1;
                int value = int.Parse(recvLine[2]);

                if (recvLine[0][0] == '1')
                {
                    for (int i = 0; i < x; ++i)
                    {
                        matrix[i, point] += value;
                    }
                }
                else
                {
                    for (int i = 0; i < y; ++i)
                    {
                        matrix[point, i] += value;
                    }
                }
            }

            StringBuilder result = new StringBuilder();

            for (int yIndex = 0; yIndex < y; ++yIndex)
            {
                result.Append(matrix[0, yIndex]);
                for (int xIndex = 1; xIndex < x; ++xIndex)
                {
                    result.Append($" {matrix[xIndex, yIndex]}");
                }
                result.Append('\n');
            }
            Console.Write(result);
        }
    }
}
