using System;
namespace no10872try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 1;
            int count = int.Parse(Console.ReadLine());

            for (int num = 1; num <= count; ++num)
            {
                result *= num;
            }
            Console.WriteLine(result);
        }
    }
}
