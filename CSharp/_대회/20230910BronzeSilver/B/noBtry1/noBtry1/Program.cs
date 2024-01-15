using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int testCase = 1; testCase <= count; testCase++)
            {
                int rank = int.Parse(Console.ReadLine());
                Console.Write($"Case #{testCase}: ");
                if (rank > 4500) Console.WriteLine("Round 1");
                else if (rank > 1000) Console.WriteLine("Round 2");
                else if (rank > 25) Console.WriteLine("Round 3");
                else Console.WriteLine("World Finals");
            }
        }
    }
}
