using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no25191try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chicken = int.Parse(Console.ReadLine());
            string[] drinks = Console.ReadLine().Split(' ');

            Console.WriteLine(Math.Min(chicken, int.Parse(drinks[0]) / 2 + int.Parse(drinks[1])));
        }
    }
}
