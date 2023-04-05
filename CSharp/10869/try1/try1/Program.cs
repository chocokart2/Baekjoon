using System;
using System.Text;

namespace try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] receiveLine = Console.ReadLine().Split(' ');
            int numberA = int.Parse(receiveLine[0]);
            int numberB = int.Parse(receiveLine[1]);
            Console.WriteLine(numberA + numberB);
            Console.WriteLine(numberA - numberB);
            Console.WriteLine(numberA * numberB);
            Console.WriteLine(numberA / numberB);
            Console.WriteLine(numberA % numberB);
        }
    }
}
