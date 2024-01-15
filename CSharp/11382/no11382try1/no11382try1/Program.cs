using System;

namespace no11382try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] num = Console.ReadLine().Split(' ');
            Console.WriteLine($"{long.Parse(num[0]) + long.Parse(num[1]) + long.Parse(num[2])}");
        }
    }
}
