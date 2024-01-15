using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noRtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            int count = int.Parse(Console.ReadLine());
            string[] planStr = Console.ReadLine().Split(' ');
            string[] actStr = Console.ReadLine().Split(' ');
            
            for (int index = 0; index < count; ++index)
            {
                if (int.Parse(planStr[index]) <= int.Parse(actStr[index])) result++;
            }

            Console.WriteLine(result);
        }
    }
}
