using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1764try1
{
    internal class Program
    {
        static int Compare(string left, string right)
        {
            if (left.Length > right.Length) return -1;
            else if (right.Length > left.Length) return 1;
            else
            {
                for (int index = 0; index < left.Length; ++index)
                {
                    if (left[index] > right[index]) return -1;
                    else if (left[index] < right[index]) return 1;
                }
                return 0;
            }
        }

        static string[] MergeSortOpt(string[] target)
        {
            // 대상을 sort하지 않고 인덱스를 sort함.

        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();





            string[] names;
            string[] nums = Console.ReadLine().Split(' ');
            int count = int.Parse(nums[0]);
            names = new string[count];

            for (int index = 0; index < count; ++index)
            {
                names[index] = Console.ReadLine();
            }

            int secondCount = int.Parse(nums[1]);
            for (int )
        }
    }
}
