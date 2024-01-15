using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2953try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int max = -1;
            int maxVal = 0;
            for (int i = 1; i < 6; ++i)
            {
                string str = Console.ReadLine();
                int one = str[0] + str[2] + str[4] + str[6] - ('0' * 4);
                if (maxVal < one)
                {
                    maxVal = one;
                    max = i;
                }
            }
            Console.WriteLine($"{max} {maxVal}");
        }
    }
}
