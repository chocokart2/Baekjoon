using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string numA = Console.ReadLine();
            string numB = Console.ReadLine();
            string numC = Console.ReadLine();


            Console.WriteLine(int.Parse(numA) + int.Parse(numB) - int.Parse(numC));
            Console.WriteLine(int.Parse($"{numA}{numB}") - int.Parse(numC));



        }
    }
}
