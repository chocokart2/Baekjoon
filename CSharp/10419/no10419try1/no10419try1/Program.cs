using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10419try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = int.Parse(Console.ReadLine()); i > 0; --i)
            {
                int d = int.Parse(Console.ReadLine());
                
                for (int t = 0; ; t++)
                {
                    if (t * (t + 1) > d)
                    {
                        Console.WriteLine($"{t - 1}");
                        break;
                    }
                }
            }


        }
    }
}
