using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2035try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            bool isAdd = Console.ReadLine()[0] == '+';
            string b = Console.ReadLine();

            if (isAdd)
            {
                if (a.Length != b.Length)
                {
                    int max = Math.Max(a.Length, b.Length);
                    int min = Math.Min(a.Length, b.Length);
                    for (int i = max; i > 0; --i)
                    {
                        Console.Write(i == max || i == min ? "1" : "0");
                    }
                }
                else
                {
                    Console.Write(2);
                    for (int i = 0; i < a.Length - 1; ++i) Console.Write(0);
                }
            }
            else
            {
                int count = a.Length + b.Length - 2;
                Console.Write(1);
                for (int i = 0; i < count; i++) { Console.Write(0); }
            }
        }
    }
}
