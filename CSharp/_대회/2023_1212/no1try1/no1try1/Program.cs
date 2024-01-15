using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());

            long result = 1;

            for (long i = 0; i < 5; i++)
            {
                result *= (n - i);
            }
            result /= 5 * 4 * 3 * 2;
            Console.WriteLine(result);
        }
    }
}
