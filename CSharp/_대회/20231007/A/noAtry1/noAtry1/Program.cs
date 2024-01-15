using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int divide = int.Parse(Console.ReadLine().Split(' ')[1]);
            string[] nums = Console.ReadLine().Split(' ');
            int sum = 0;
            for (int index = 0; index < nums.Length; ++index) sum += int.Parse(nums[index]);
            Console.WriteLine((sum % divide == 0) ? "1" : "0");

        }
    }
}
