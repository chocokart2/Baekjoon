using System;

namespace no8370try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] num = Console.ReadLine().Split(' ');
            Console.WriteLine($"{int.Parse(num[0]) * int.Parse(num[1]) + int.Parse(num[2]) * int.Parse(num[3])}");
        }
    }
}
