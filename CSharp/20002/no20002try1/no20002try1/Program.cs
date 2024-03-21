using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no20002try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 소작농인 형곤이는 오늘도 악독한 신영이때문에 웁니다.

            int size = int.Parse(Console.ReadLine());
            int[,] sums = new int[size + 1, size + 1];

            for (int y = 0; y < size; y++)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                for (int x = 0; x < size; ++x)
                {
                    sums[x + 1, y + 1] = int.Parse(recvLine[x]) + sums[x + 1, y] + sums[x, y + 1] - sums[x, y];
                }
            }

            int max = int.MinValue;
            for (int x1 = 0; x1 < size; ++x1)
            {
                for (int y1 = 0; y1 < size; ++y1)
                {
                    for (int k = 1; k <= size; ++k)
                    {
                        if (x1 + k > size) break;
                        if (y1 + k > size) break;
                        int one = sums[x1 + k, y1 + k] - sums[x1 + k, y1] - sums[x1, y1 + k] + sums[x1, y1];
                        if (one > max) max = one;
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}
