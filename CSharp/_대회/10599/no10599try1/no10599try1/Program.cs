using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10599try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string one = Console.ReadLine();
                if (one.Equals("0 0 0 0")) break;
                string[] nums = one.Split(' ');
                Console.WriteLine($"{int.Parse(nums[2]) - int.Parse(nums[1])} {int.Parse(nums[3]) - int.Parse(nums[0])}");
            }

        }
    }
}
