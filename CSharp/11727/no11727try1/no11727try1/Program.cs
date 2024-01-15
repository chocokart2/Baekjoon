using System;

namespace no11727try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] result = new int[1001];
            result[1] = 1;
            result[2] = 3;

            for (int index = 3; index < 1001; ++index)
            {
                result[index] = (result[index - 1] % 10007 + (result[index - 2] * 2 % 10007)) % 10007;
            }

            Console.WriteLine(result[int.Parse(Console.ReadLine())]);
        }
    }
}
