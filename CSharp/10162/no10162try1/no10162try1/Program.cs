using System;

namespace no10162try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int time = int.Parse(Console.ReadLine());
            int[] result = { 0, 0, 0 };
            if (time % 10 != 0)
            {
                Console.WriteLine(-1);
                return;
            }

            result[0] = time / 300;
            time %= 300;
            result[1] = time / 60;
            time %= 60;
            result[2] = time / 10;

            Console.WriteLine($"{result[0]} {result[1]} {result[2]}");
        }
    }
}
