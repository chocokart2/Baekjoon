using System;

namespace no1712try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            int divide = int.Parse(numbers[2]) - int.Parse(numbers[1]);
            if (divide > 0) Console.WriteLine(int.Parse(numbers[0]) / divide + 1);
            else Console.WriteLine(-1);
        }
    }
}
