using System;

namespace no4470try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; ++i)
                Console.WriteLine($"{i}. {Console.ReadLine()}");


        }
    }
}
