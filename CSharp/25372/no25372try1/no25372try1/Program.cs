using System;

namespace no25372try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                int length = Console.ReadLine().Length;
                Console.WriteLine((length > 5 && length < 10) ? "yes" : "no");
            }
        }
    }
}
