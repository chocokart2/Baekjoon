using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no7try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            string[] nums = Console.ReadLine().Split(' ');
            int max = 0;
            for (int index = 0; index < nums.Length; ++index)
            {
                int one = int.Parse(nums[index]);
                if (one > max) max = one;
            }
            Console.WriteLine($"{max + count - 1}");
        }
    }
}
