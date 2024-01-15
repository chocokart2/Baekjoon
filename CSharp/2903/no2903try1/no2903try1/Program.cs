using System;

namespace no2903try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int sideDotAmount = 2;

            for (int i = 0; i < count; ++i)
                sideDotAmount += sideDotAmount - 1;

            Console.WriteLine(sideDotAmount * sideDotAmount);
        }
    }
}
