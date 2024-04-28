using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2399try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ulong[] nums = new ulong[int.Parse(Console.ReadLine())];
            string[] str = Console.ReadLine().Split(' ');
            ulong result = 0;

            for (int index = 0; index < nums.Length; index++)
            {
                nums[index] = ulong.Parse(str[index]);
            }
            for (int indexL = 0; indexL < nums.Length; ++indexL)
            {
                for (int indexR = 0; indexR < nums.Length; ++indexR)
                {
                    result +=
                        Math.Max(nums[indexL], nums[indexR]) - Math.Min(nums[indexL], nums[indexR]);
                }
            }

            Console.WriteLine(result);
        }
    }
}
