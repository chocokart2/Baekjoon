using System;

namespace no1225try1
{
    internal class Program
    {
        static long Convert(char c)
        {
            switch (c)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                default: return -1;
            }
        }

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            long result = 0;

            for (int index1 = 0; index1 < nums[0].Length; ++index1)
            {
                for (int index2 = 0; index2 < nums[1].Length; ++index2)
                {
                    result += Convert(nums[0][index1]) * Convert(nums[1][index2]);
                }
            }
            Console.WriteLine(result);
        }
    }
}
