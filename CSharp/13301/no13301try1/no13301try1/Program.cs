using System;

// f(n) = ( arr[n] + arr[n + 1] ) * 2

namespace no13301try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Int64[] fibonacci = new Int64[81];
            fibonacci[0] = 1;
            fibonacci[1] = 1;

            for (int index = 2; index < fibonacci.Length; index++)
                fibonacci[index] = fibonacci[index - 1] + fibonacci[index - 2];

            int N = int.Parse(Console.ReadLine());
            Int64 result = (fibonacci[N] + fibonacci[N - 1]) * 2;
            Console.WriteLine(result);
        }
    }
}
