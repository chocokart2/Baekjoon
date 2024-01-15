using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1547try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            bool[] cups = new bool[3];
            cups[0] = true;

            for (int i = 0; i < count; ++i)
            {
                string nums = Console.ReadLine();

                bool temp = cups[nums[0] - '1'];
                cups[nums[0] - '1'] = cups[nums[2] - '1'];
                cups[nums[2] - '1'] = temp;
            }

            for (int i = 0; i < 3; ++i)
            {
                if (cups[i]) Console.WriteLine(i + 1);
            }
        }
    }
}
