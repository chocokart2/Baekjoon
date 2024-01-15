using System;

namespace no10768try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int month = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            if (month > 2) Console.WriteLine("After");
            else if (month < 2) Console.WriteLine("Before");
            else
            {
                if (day < 18) Console.WriteLine("Before");
                else if (day > 18) Console.WriteLine("After");
                else Console.WriteLine("Special");
            }

        }
    }
}
