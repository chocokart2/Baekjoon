using System;

namespace no2292try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int result = 0;
            
            for (int i = 1; i < num;)
            {
                ++result;
                i += result * 6;
            }
            ++result;

            Console.WriteLine(result);
        }
    }
}
