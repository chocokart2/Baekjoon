using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2444try1
{
    internal class Program
    {
        static int Absolute(int value) => (value > 0) ? value : -value;

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int y = -(size - 1); y < size; y++)
            {
                for (int x = -(size - 1); x < size - Absolute(y); x++)
                {
                    result.Append((Absolute(x) + Absolute(y) < size) ? '*' : ' ');
                }
                result.Append('\n');
            }
            Console.Write(result);
        }
    }
}
