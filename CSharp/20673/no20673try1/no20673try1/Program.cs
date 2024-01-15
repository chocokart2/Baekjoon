using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no20673try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int newCases = int.Parse(Console.ReadLine());
            int hospitalizations = int.Parse(Console.ReadLine());

            if (newCases <= 50 && hospitalizations <= 10) Console.WriteLine("White");
            else if (hospitalizations > 30) Console.WriteLine("Red");
            else Console.WriteLine("Yellow");
        }
    }
}
