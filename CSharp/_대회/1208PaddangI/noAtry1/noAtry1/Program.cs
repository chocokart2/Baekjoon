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
            int time = int.Parse(Console.ReadLine());

            Console.ReadLine();

            string[] candies = Console.ReadLine().Split(' ');
            for (int index = 0; index < candies.Length; index++)
            {
                time -= int.Parse(candies[index]);
            }
            if (time > 0) Console.WriteLine("Padaeng_i Cry");
            else Console.WriteLine("Padaeng_i Happy");
        }
    }
}
