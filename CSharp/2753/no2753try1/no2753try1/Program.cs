using System;

namespace no2753try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year = int.Parse(Console.ReadLine());
            if ((year % 400).Equals(0)) Console.WriteLine(1);
            else if ((year % 100).Equals(0)) Console.WriteLine(0);
            else if ((year % 4).Equals(0)) Console.WriteLine(1);
            else Console.WriteLine(0);
        }
    }
}
