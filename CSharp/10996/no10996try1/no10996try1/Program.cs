using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10996try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int size = int.Parse(Console.ReadLine());

            if (size == 0)
            {
                Console.WriteLine("*");
                return;
            }

            for (int y = 0; y < size * 2; ++y)
            {
                for (int x = 0; x < size; ++x)
                {
                    result.Append(((x + y) % 2 == 0 ? "*" : " "));
                }
                result.Append('\n');
            }
            Console.Write(result);
        }
    }
}
