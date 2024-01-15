using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noPAtry1
{
    internal class Program
    {
        static ulong Factorial(ulong value)
        {
            ulong result = 1;
            for (; value > 1; value--) result *= value;
            return result;
        }

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            ulong[] cars = new ulong[nums.Length];
            for (int index = 0; index < nums.Length; index++)
            {
                cars[index] = ulong.Parse(nums[index]);
            }
            ulong result = Factorial(cars[0]) / (Factorial(cars[1]) * Factorial(cars[2]) * Factorial(cars[3]));
            Console.WriteLine(result);
        }
    }
}
