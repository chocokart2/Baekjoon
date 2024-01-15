using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no3053try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            Console.WriteLine(radius * radius * Math.PI);
            Console.WriteLine(radius * radius * 2);

        }
    }
}
