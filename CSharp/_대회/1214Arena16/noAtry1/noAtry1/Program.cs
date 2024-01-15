using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] nums = Console.ReadLine().Split(' ');

                int people = int.Parse(nums[0]);
                int umbrella = int.Parse(nums[1]);
                int maxPeople = int.Parse(nums[2]);

                int oneResult = 1;
                people -= umbrella * maxPeople;
                if (people <= 0)
                {
                    result.AppendLine(oneResult.ToString());
                    continue;
                }
                
                if (umbrella * maxPeople < 2)
                {
                    result.AppendLine("-1");
                    continue;
                }

                for (; people > 0;)
                {
                    people -= umbrella * maxPeople - 1;
                    oneResult++;
                }
                result.AppendLine($"{oneResult}");
            }
            Console.Write(result);


        }
    }
}
