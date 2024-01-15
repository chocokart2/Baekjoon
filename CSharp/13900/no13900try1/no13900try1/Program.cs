using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace no13900try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bufferSize = 600_000;
            StreamReader reader = new StreamReader(Console.OpenStandardInput(bufferSize));


            reader.ReadLine();

            string[] nums = reader.ReadLine().Split(' ');
            long sum = 0;
            long result = 0;
            for (int index = nums.Length - 1; index >= 0; index--)
            {
                long one = long.Parse(nums[index]);
                if (index < nums.Length - 1)
                {
                    result += one * sum;
                }
                sum += one;
            }

            Console.WriteLine(result);
            reader.Close();
        }
    }
}
