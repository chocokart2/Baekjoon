using System;

namespace no8393try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int result = 0;
            for (int i = 1; i <= num; i++) result += i;
            Console.WriteLine(result);
        }
    }
}
