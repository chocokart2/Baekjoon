using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1609try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] sum = new int[size + 1, size + 1];

            int BestX1 = 0;
            int BestX2 = 0;
            int BestY1 = 0;
            int BestY2 = 0;

            for (int y = 0; y < size; y++)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                for (int x = 0; x < size; ++x)
                {
                    sum[x + 1, y + 1] = sum[x + 1, y] + sum[x, y + 1] - sum[x, y] + int.Parse(recvLine[x]);
                }
            }

            for (int x1 = 1; x1 < size; ++x1)
            {
                for (int x2 = x1 + 1; x2 <= size; ++x2)
                {

                }
            }
            

        }
    }
}
