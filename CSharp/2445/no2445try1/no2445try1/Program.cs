using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2445try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int y = -(count - 1); y < count; y++)
            {
                int one = Math.Abs(y);

                for (int x = count; x > 0; --x)
                {
                    Console.Write((x > one) ? '*' : ' ');
                }
                for (int x = 1; x < count + 1; ++x)
                {
                    Console.Write((x > one) ? '*' : ' ');
                }
                Console.WriteLine();
            }

        }
    }
}
