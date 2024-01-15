using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2775try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            long[,] apartment = new long[15, 15];

            for (int i = 1; i < 15; i++)
                apartment[0, i] = i;

            for (int floor = 1; floor < 15; ++floor)
            {
                for (int b = 1; b < 15; ++b)
                {
                    for (int bPrime = 1; bPrime <= b; ++bPrime)
                    {
                        apartment[floor, b] += apartment[floor - 1, bPrime];
                    }
                }
            }

            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; ++i)
            {
                int k = int.Parse(Console.ReadLine());
                int n = int.Parse(Console.ReadLine());

                result.AppendLine(apartment[k, n].ToString());
            }

            Console.Write(result);
        }
    }
}
