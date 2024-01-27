using System;

namespace no1748try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int limit = 9;
            int[] count = new int[9]; //100,000,000
            for (int index = 0; index < 9; ++index)
            {
                if (N < limit)
                {
                    count[index] = N;
                    break;
                }

                count[index] = limit;
                N -= limit;
                limit *= 10;
            }
            int result = 0;
            for (int index = 0; index < count.Length; ++index)
            {
                result += count[index] * (index + 1);
            }

            Console.WriteLine(result);
        }
    }
}
