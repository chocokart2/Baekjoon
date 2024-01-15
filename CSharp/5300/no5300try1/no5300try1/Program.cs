using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5300try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int piratesBuddy = 0;
            for (int i = 1; count > 0; --count, ++piratesBuddy, ++i)
            {
                if (piratesBuddy % 6 == 0 && piratesBuddy > 0)
                {
                    Console.Write("Go! ");
                }

                Console.Write($"{piratesBuddy + 1} ");


            }

            if (piratesBuddy > 0) Console.Write("Go!");
        }
    }
}
