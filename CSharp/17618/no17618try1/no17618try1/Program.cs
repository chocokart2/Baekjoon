using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17618try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            for (int x = int.Parse(Console.ReadLine()); x > 0; x--)
            {
                string nums = x.ToString();
                int sum = 0;
                for (int index = 0; index < nums.Length; index++)
                {
                    sum += nums[index] - '0';
                }
                if (x % sum == 0) result++;
            }

            Console.WriteLine(result);
        }
    }
}
