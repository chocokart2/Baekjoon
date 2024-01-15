using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int minPoint = int.MaxValue;
            string min = "";
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                string val = Console.ReadLine();
                string[] nums = val.Split(' ');

                int y = int.Parse(nums[1]);
                if (y < minPoint)
                {
                    minPoint = y;
                    min = val;
                }
            }
            Console.WriteLine(min);
        }
    }
}
