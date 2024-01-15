using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no29790try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            if (int.Parse(nums[0]) >= 1000)
            {
                if (int.Parse(nums[1]) >= 8000 || int.Parse(nums[2]) >= 260)
                {
                    Console.WriteLine("Very Good");
                }
                else
                {
                    Console.WriteLine("Good");
                }
            }
            else
            {
                Console.WriteLine("Bad");
            }
        }
    }
}
