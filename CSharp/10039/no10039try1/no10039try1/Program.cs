using System;

namespace no10039try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 5; ++i)
                sum += (int)Math.Max(int.Parse(Console.ReadLine()), 40);
            Console.Write(sum / 5);
        }
    }
}
