using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2579try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] prevOneStep = new int[size];
            int[] prevTwoStep = new int[size];
            
            for (int i = 0; i < size; i++)
            {
                int one = int.Parse(Console.ReadLine());

                if (i == 0)
                {
                    prevOneStep[i] = one;
                    prevTwoStep[i] = one;
                }
                else if (i == 1)
                {
                    prevOneStep[i] = prevOneStep[i - 1] + one;
                    prevTwoStep[i] = one;
                }
                else
                {
                    prevOneStep[i] = prevTwoStep[i - 1] + one;
                    prevTwoStep[i] = Math.Max(prevTwoStep[i - 2] + one, prevOneStep[i - 2] + one);
                }
                //Console.WriteLine($"prevOneStep[{i}] = {prevOneStep[i]},\tprevTwoStep[{i}] = {prevTwoStep[i]}");
            }

            Console.WriteLine($"{Math.Max(prevOneStep[size - 1], prevTwoStep[size - 1])}");
        }
    }
}
