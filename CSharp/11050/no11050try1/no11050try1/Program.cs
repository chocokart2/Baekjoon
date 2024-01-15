using System;

namespace no11050try1
{
    internal class Program
    {
        static int GetFactorial(int i)
        {
            int result = 1;
            for (int a = i; a > 0; --a) result *= a;
            return result;
        }

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int n = int.Parse(nums[0]);
            int k = int.Parse(nums[1]);
            Console.WriteLine(GetFactorial(n) / (GetFactorial(n - k) * GetFactorial(k)));
        }
    }
}
