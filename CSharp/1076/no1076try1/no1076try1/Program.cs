using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1076try1
{
    internal class Program
    {
        static long GetNum(string str)
        {
            switch (str)
            {
                case "black": return 0;
                case "brown": return 1;
                case "red": return 2;
                case "orange": return 3;
                case "yellow": return 4;
                case "green": return 5;
                case "blue": return 6;
                case "violet": return 7;
                case "grey": return 8;
                case "white": return 9;
                default: return 0;
            }
        }

        static void Main(string[] args)
        {
            long result =
                (GetNum(Console.ReadLine()) * 10 +
                GetNum(Console.ReadLine())) * (long)Math.Pow(10, GetNum(Console.ReadLine()));

            Console.WriteLine(result);
        }
    }
}
