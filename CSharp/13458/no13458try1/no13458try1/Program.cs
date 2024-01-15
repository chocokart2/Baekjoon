using System;

namespace no13458try1
{
    internal class Program
    {
        static long RoundUp(long dividend, long divisor)
            => (dividend < 1) ? 0 : 
            (
                (dividend % divisor) > 0 ? (dividend / divisor) + 1 : dividend / divisor
            );
        static void Main(string[] args)
        {
            long result = 0;
            int count = int.Parse(Console.ReadLine());
            string[] numsString = Console.ReadLine().Split(' ');
            string[] capacitiesString = Console.ReadLine().Split(' ');
            long[] capacities = new long[2] { long.Parse(capacitiesString[0]), long.Parse(capacitiesString[1]) };
            for (int index = 0; index < numsString.Length; ++index)
            {
                result += 1 + RoundUp(long.Parse(numsString[index]) - capacities[0], capacities[1]); 
            }
            Console.WriteLine(result);
        }
    }
}
