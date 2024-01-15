using System;

namespace no2420try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            Console.Write(Math.Abs(long.Parse(numbers[0]) - long.Parse(numbers[1])));
        }
    }
}
