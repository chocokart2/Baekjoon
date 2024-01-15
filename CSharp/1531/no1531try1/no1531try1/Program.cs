using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1531try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLineCountLimit = Console.ReadLine().Split(' ');
            int count = int.Parse(recvLineCountLimit[0]);
            int limit = int.Parse(recvLineCountLimit[1]);
            int[,] paint = new int[100, 100];

            int result = 0;

            for (int i = 0; i < count; ++i)
            {
                string[] one = Console.ReadLine().Split(' ');
                int startX = int.Parse(one[0]);
                int startY = int.Parse(one[1]);
                int endX = int.Parse(one[2]);
                int endY = int.Parse(one[3]);

                for (int y = startY - 1; y < endY; ++y)
                {
                    for (int x = startX - 1; x < endX; ++x)
                    {
                        paint[x, y]++;
                    }
                }
            }
            
            for (int x = 0; x < 100; ++x)
            {
                for (int y = 0; y < 100; ++y)
                {
                    if (paint[x, y] > limit) result++;
                }
            }

            Console.WriteLine(result);
        }
    }
}
