using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static  ulong Get(string str)
        {
            ulong result = 0;
            for (int index = 0; index < str.Length; index++)
            {
                result |= ((ulong)str[index]) << (index * 8);
            }
            return result;
        }

        static void Main(string[] args)
        {
            ulong[,] color = new ulong[10, 10];

            for (int y = 0; y < 10; y++)
            {
                string[] one = Console.ReadLine().Split(' ');
                for (int x = 0; x < 10; ++x)
                {
                    color[x, y] = Get(one[x]);
                }
            }

            for (int y = 0; y < 10; y++)
            {
                ulong one = color[0, y];
                int x = 1;
                for (; x < 10; ++x)
                {
                    if (one != color[x, y]) break;
                }
                if (x == 10)
                {
                    Console.WriteLine(1);
                    return;
                }
            }

            for (int y = 0; y < 10; y++)
            {
                ulong one = color[y, 0];
                int x = 1;
                for (; x < 10; ++x)
                {
                    if (one != color[y, x]) break;
                }
                if (x == 10)
                {
                    Console.WriteLine(1);
                    return;
                }
            }

            Console.WriteLine(0);
        }
    }
}
