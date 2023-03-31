using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            int min = int.MaxValue;
            int max = int.MinValue;
            
            foreach(string one in Console.ReadLine().Split(' '))
            {
                int num = int.Parse(one);
                if (num < min) min = num;
                if (num > max) max = num;
            }

            Console.WriteLine($"{min} {max}");
        }
    }
}
