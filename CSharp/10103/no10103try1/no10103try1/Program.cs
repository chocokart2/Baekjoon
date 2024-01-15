using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10103try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int a = 100;
            int b = 100;

            for (int i = 0; i < count; ++i)
            {
                string nums = Console.ReadLine();
                int dice1 = nums[0] - '0';
                int dice2 = nums[2] - '0';
                
                if (dice1 > dice2)
                {
                    b -= dice1;
                }
                if (dice1 < dice2)
                {
                    a -= dice2;
                }
            }
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
