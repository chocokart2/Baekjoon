using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10409try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int limit = int.Parse(Console.ReadLine().Split(' ')[1]);
            string[] nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < nums.Length; ++index)
            {
                int one = int.Parse(nums[index]);
                if (limit < one) break;
                limit -= one;
                result++;
            }
            Console.WriteLine(result);
        }
    }
}
