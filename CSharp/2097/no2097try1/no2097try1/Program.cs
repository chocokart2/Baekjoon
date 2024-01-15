using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace no2097try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cobblestone = int.Parse(Console.ReadLine());
            if (cobblestone < 3)
            {
                Console.WriteLine(4);
                return;
            }

            for (int n = 2; ; n++)
            {
                if (cobblestone > n * n)
                {
                    continue;
                }

                if (cobblestone <= n * (n - 1))
                {
                    //Console.WriteLine($"{n} * {n - 1}");

                    Console.WriteLine($"{(n * 2 - 3) * 2}");
                }
                else
                {
                    //Console.WriteLine(n);

                    Console.WriteLine($"{(n - 1) * 4}");
                }
                break;
            }
        }
    }
}
