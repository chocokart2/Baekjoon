using System;

namespace no15727try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine($"{length / 5 + ((length % 5) > 0 ? 1 : 0)}");
        }
    }
}
