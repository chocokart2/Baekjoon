using System;

namespace no11726try3
{
    internal class Program
    {
        static int[] fibo;

        static void Init()
        {
            fibo = new int[1001];
            fibo[1] = 1;
            fibo[2] = 2;

            for (int i = 3; i < 1001; ++i)
            {
                fibo[i] = (fibo[i - 1] + fibo[i - 2]) % 10_007;
            }
        }

        static void Main(string[] args)
        {
            Init();
            Console.WriteLine(fibo[int.Parse(Console.ReadLine())]);
        }
    }
}
