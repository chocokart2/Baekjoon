using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10474try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] nums = Console.ReadLine().Split(' ');

                if (nums[1].Equals("0")) break;
                int a = int.Parse(nums[0]);
                int b = int.Parse(nums[1]);

                Console.WriteLine($"{a/b} {a%b} / {b}");
            }


        }
    }
}
