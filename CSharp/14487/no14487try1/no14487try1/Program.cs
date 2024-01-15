using System;

namespace no14487try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] numString = Console.ReadLine().Split(' ');
            int result = 0;
            int maxCost = 0;
            for (int index = 0; index < numString.Length; ++index)
            {
                int one = int.Parse(numString[index]);
                result += one;
                if (maxCost < one) maxCost = one;
            }
            Console.WriteLine($"{result - maxCost}");
        }
    }
}
