using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1964try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 1;
            for (int i = int.Parse(Console.ReadLine()); i > 0; i--)
            {
                result = (result + i * 3 + 1) % 45678;
            }
            Console.WriteLine(result);
        }
    }
}
