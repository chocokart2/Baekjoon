using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no30008try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peoples = int.Parse(Console.ReadLine().Split(' ')[0]);
            string[] nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < nums.Length; ++index)
            {
                if (index > 0) Console.Write(' ');
                int persentage = (int.Parse(nums[index]) * 100) / peoples;
                int result = 0;
                if (persentage > 96) result = 9;
                else if (persentage > 89) result = 8;
                else if (persentage > 77) result = 7;
                else if (persentage > 60) result = 6;
                else if (persentage > 40) result = 5;
                else if (persentage > 23) result = 4;
                else if (persentage > 11) result = 3;
                else if (persentage > 4) result = 2;
                else result = 1;
                Console.Write(result);
            }
        }
    }
}
