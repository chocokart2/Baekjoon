using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] nums = Console.ReadLine().Split(' ');
            int[] ints = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                ints[i] = int.Parse(nums[i]);
            }

            // 0, 1, 4, 6, 8, 9 >> 소수가 아님
            Console.WriteLine("YES");

            if (nums[0][0] == '0')
            {
                Console.WriteLine("0");
                return;
            }
            else if (nums[0][0] == '1')
            {
                Console.WriteLine("111");
                return;
            }
            else
            {
                Console.WriteLine($"{nums[0][0]}{nums[0][0]}");
            }
        }
    }
}
