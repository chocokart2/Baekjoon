using System;

namespace no2588try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int whole = int.Parse(Console.ReadLine());
            string integer = Console.ReadLine();
            int result = 0;
            for (int i = 2; i > -1; --i)
            {
                int multiple = whole * int.Parse(integer[i].ToString());
                Console.WriteLine(multiple);
                result += (int)Math.Pow(10, 2 - i) * multiple;
            }
            Console.WriteLine(result);
        }
    }
}
