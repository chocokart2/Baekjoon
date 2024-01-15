using System;
using System.Collections.Generic;

namespace no1550try1
{
    internal class Program
    {
        static Dictionary<char, int> converter = new Dictionary<char, int>()
        {
            { '0', 0 },
            { '1', 1 },
            { '2', 2 },
            { '3', 3 },
            { '4', 4 },
            { '5', 5 },
            { '6', 6 },
            { '7', 7 },
            { '8', 8 },
            { '9', 9 },
            { 'A', 10 },
            { 'B', 11 },
            { 'C', 12 },
            { 'D', 13 },
            { 'E', 14 },
            { 'F', 15 },
        };

        static void Main(string[] args)
        {
            int result = 0;
            
            string recv = Console.ReadLine();
            
            for (int index = 0; index < recv.Length; ++index)
            {
                result += (converter[recv[index]] << (4 * (recv.Length - index - 1)));
            }

            Console.WriteLine(result);
        }
    }
}
