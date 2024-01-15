using System;
using System.Text;

namespace no1009try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            // 가변 배열로 박살내겠습니다.
            int[][] tailNum = new int[10][] // [마지막 숫자][(곱 - 1) % tailNum.Length]
            {
                new int[] { 10 },
                new int[] { 1 },
                new int[] { 2, 4, 8, 6 },
                new int[] { 3, 9, 7, 1 },
                new int[] { 4, 6 },
                new int[] { 5 },
                new int[] { 6 },
                new int[] { 7, 9, 3, 1 },
                new int[] { 8, 4, 2, 6 },
                new int[] { 9, 1 }
            };

            int count = int.Parse(Console.ReadLine());
            for (int n = 0; n < count; ++n)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int tail = int.Parse(nums[0][nums[0].Length - 1].ToString());
                result.Append($"{tailNum[tail][(int.Parse(nums[1]) - 1) % tailNum[tail].Length]}\n");
            }

            Console.Write(result);
        }
    }
}
