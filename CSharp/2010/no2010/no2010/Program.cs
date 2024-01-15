using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2010
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int sum = 1;
            for (int i = 0; i < count; i++)
            {
                sum += int.Parse(Console.ReadLine()) - 1;
            }
            Console.WriteLine(sum);
        }
    }
}
