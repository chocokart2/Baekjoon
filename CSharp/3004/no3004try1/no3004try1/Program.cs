using System;
namespace no3004try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int result = (1 + (count >> 1)) * (1 + (count - (count >> 1)));

            Console.WriteLine(result);
        }
    }
}
