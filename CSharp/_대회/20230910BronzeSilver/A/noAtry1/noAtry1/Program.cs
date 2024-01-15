using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numAB = Console.ReadLine().Split(' ');
            string[] numKX = Console.ReadLine().Split(' ');
            int k = int.Parse(numKX[0]);
            int x = int.Parse(numKX[1]);

            int result = 1 + Math.Min(int.Parse(numAB[1]), k + x) - Math.Max(int.Parse(numAB[0]), k - x);

            Console.WriteLine(result > 0 ? $"{result}" : "IMPOSSIBLE");
        }
    }
}
