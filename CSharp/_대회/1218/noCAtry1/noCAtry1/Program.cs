using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noCAtry1
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string[] term = Console.ReadLine().Split(' ');
            long end = long.Parse(term[1]);
            long start = long.Parse(term[0]);
            string[] nums = Console.ReadLine().Split(' ');
            long numA = long.Parse(nums[0]) / 3;
            long numB = (long.Parse(nums[1]) - long.Parse(nums[3])) / 2;
            long numC = long.Parse(nums[2]) - long.Parse(nums[4]);

            long m_Function(long x)
            {
                return numA * x * x * x + numB * x * x + numC * x;
            }

            long result = m_Function(end) - m_Function(start);
            Console.WriteLine(result);
        }
    }
}
