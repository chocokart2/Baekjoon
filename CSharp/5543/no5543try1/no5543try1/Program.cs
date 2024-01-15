using System;

namespace no5543try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] price = new int[5]
            {
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine())
            };
            Console.WriteLine($"{Math.Min(Math.Min(price[0], price[1]), price[2]) + Math.Min(price[3], price[4]) - 50}");
        }
    }
}
