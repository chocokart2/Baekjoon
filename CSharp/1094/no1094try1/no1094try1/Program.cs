using System;

namespace no1094try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int result = 0;

            for (int i = 0; i < 7; ++i)
            {
                if ((length & (1 << i)).Equals(1 << i)) ++result;
            }

            Console.WriteLine(result);
        }
    }
}
