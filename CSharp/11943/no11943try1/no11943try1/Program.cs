using System;

namespace no11943try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] basket1 = Console.ReadLine().Split(' ');
            string[] basket2 = Console.ReadLine().Split(' ');

            Console.WriteLine(Math.Min(int.Parse(basket1[0]) + int.Parse(basket2[1]),
                int.Parse(basket1[1]) + int.Parse(basket2[0])));
        }
    }
}
