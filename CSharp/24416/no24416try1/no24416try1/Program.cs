using System;

namespace no24416try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] functionCalledCount = new int[40];
            functionCalledCount[0] = 1;
            functionCalledCount[1] = 1;
            for (int i = 2; i < 40; ++i)
            {
                functionCalledCount[i] = functionCalledCount[i - 1] + functionCalledCount[i - 2];
            }

            Console.WriteLine($"{functionCalledCount[n - 1]} {n - 2}");

        }
    }
}
