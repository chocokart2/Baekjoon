using System;

namespace no1try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m_x = int.Parse(Console.ReadLine().Split(' ')[1]);
            string[] pricesString = Console.ReadLine().Split(' ');
            int[] prices = new int[pricesString.Length];
            for (int index = 0; index < pricesString.Length; ++index)
                prices[index] = int.Parse(pricesString[index]);

            int min = int.MaxValue;
            for (int index = 1; index < prices.Length; ++index)
            {
                int sum = prices[index - 1] + prices[index];
                if (min > sum) min = sum;
            }

            Console.WriteLine($"{min * m_x}");
        }
    }
}
