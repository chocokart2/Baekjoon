using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no25704try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stamp = int.Parse(Console.ReadLine());
            int price = int.Parse(Console.ReadLine());

            int[] value = new int[4]
            {
                price - 500,
                (price / 10) * 9,
                price - 2000,
                (price / 4) * 3
            };
            int min = price;
            for (int cost = 5; cost <= stamp && cost < 25; cost += 5)
            {
                if (min > value[cost / 5 - 1]) min = value[cost / 5 - 1];
            }
            if (min < 0) min = 0;

            Console.WriteLine(min);
        }
    }
}
