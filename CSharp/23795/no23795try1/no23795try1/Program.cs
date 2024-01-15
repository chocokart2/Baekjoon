using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no23795try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            while (true)
            {
                int one = int.Parse(Console.ReadLine());
                if (one == -1) break;
                sum += one;
            }
            Console.WriteLine(sum);
        }
    }
}
