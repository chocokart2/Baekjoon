using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9325try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            
            for (int t = int.Parse(Console.ReadLine()); t > 0; t--)
            {
                int sum = int.Parse(Console.ReadLine());
                for (int option = int.Parse(Console.ReadLine()); option > 0; option--)
                {
                    string[] nums = Console.ReadLine().Split(' ');
                    sum += int.Parse(nums[0]) * int.Parse(nums[1]);
                }
                result.AppendLine($"{sum}");
            }
            Console.Write(result);
        }
    }
}
