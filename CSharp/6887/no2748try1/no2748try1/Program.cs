using System;

namespace no2748try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Int64[] fibo = new Int64[91];
            fibo[0] = 0;
            fibo[1] = 1;
            Int64 target = Int64.Parse(Console.ReadLine());
            for (int i = 2; i <= target; ++i)
            {
                fibo[i] = fibo[i - 1] + fibo[i - 2];
            }
            Console.WriteLine(fibo[target]);
        }
    }
}
