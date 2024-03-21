using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15780try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine().Split(' ')[0]);
            string[] nums = Console.ReadLine().Split(' ');

            for (int index = 0; index < nums.Length; index++)
            {
                sum -= (int.Parse(nums[index]) + 1) / 2;
            }
            if (sum > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
