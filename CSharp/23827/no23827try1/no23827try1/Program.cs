using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no23827try1
{
    internal class Program
    {
        const ulong LIMIT = 1_000_000_007UL;

        static ulong Add(ulong left, ulong right)
            => (left + right >= LIMIT) ? (left + right) % LIMIT : left + right;
        static ulong Multiply(ulong left, ulong right)
        {
            ulong result = left * right;
            if (result >= LIMIT) return result % LIMIT;
            else return result;
        }
        static void Main(string[] args)
        {
            Console.ReadLine();

            ulong result = 0;
            ulong sum = 0;
            string[] nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < nums.Length; index++)
            {
                ulong one = ulong.Parse(nums[index]);
                if (index > 0)
                {
                    result = Add(result, Multiply(sum, one));
                }
                sum = Add(sum, one);
            }
            Console.WriteLine(result);
        }
    }
}
