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
            string[] hamCheese = Console.ReadLine().Split();
            int result = (Math.Min(int.Parse(hamCheese[0]) - 1, int.Parse(hamCheese[1])) * 2) + 1;
            if (result < 0) result = 0;
            Console.WriteLine(result);
        }
    }
}
