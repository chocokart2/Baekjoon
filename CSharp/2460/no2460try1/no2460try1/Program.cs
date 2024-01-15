using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace no2460try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int val = 0;
            int max = 0;
            for (int i = 0; i < 10; ++i)
            {
                string[] nums = Console.ReadLine().Split(' ');
                val += int.Parse(nums[1]) - int.Parse(nums[0]);
                if (val > max) max = val;
            }
            Console.WriteLine(max);
        }
    }
}
