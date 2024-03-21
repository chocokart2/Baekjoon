using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15921try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float i = float.Parse(Console.ReadLine());

            if (i == 0)
            {
                Console.WriteLine("divide by zero");
                return;
            }
            float sum = 0;
            string[] nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < i; ++index)
            {
                sum += float.Parse(nums[index]);
            }

            Console.WriteLine("1.00");
        }
    }
}
