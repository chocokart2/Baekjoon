using System;

namespace no3009try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;
            for (int i = 0; i < 3; ++i)
            {
                string[] numbers = Console.ReadLine().Split(' ');
                x ^= int.Parse(numbers[0]);
                y ^= int.Parse(numbers[1]);
            }
            Console.WriteLine($"{x} {y}");
        }
    }
}
