using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace no2783try1
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            List<int> nums = new List<int>();

            for (int i = 0; i < 5; ++i)
            {
                string one = Console.ReadLine();
                for (int index = 0; index < one.Length - 2; ++index)
                {
                    if (one[index] != 'F') continue;
                    if (one[index + 1] != 'B') continue;
                    if (one[index + 2] != 'I') continue;
                    nums.Add(i + 1);
                    break;
                }
            }
            if (nums.Count > 0)
            {
                Console.Write(nums[0]);
                for (int i = 1; i < nums.Count; ++i) Console.Write($" {nums[i]}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("HE GOT AWAY!");
            }



        }
    }
}
