using System;

namespace no16486try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double d1 = double.Parse(Console.ReadLine());
            double d2 = double.Parse(Console.ReadLine());

            Console.WriteLine($"{d1 * 2 + d2 * 2 * 3.141592}");
        }
    }
}
