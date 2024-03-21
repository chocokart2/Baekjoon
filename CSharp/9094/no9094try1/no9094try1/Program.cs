using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9094try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = int.Parse(Console.ReadLine()); i > 0; i--)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int n = int.Parse(recvLine[0]);
                int m = int.Parse(recvLine[1]);
                int result = 0;

                for (int a = 1; a < n - 1; a++)
                {
                    for (int b = a + 1; b < n; b++)
                    {
                        if ((a * a + b * b + m) % (a * b) == 0) result++;
                    }
                }

                Console.WriteLine(result);
            }


        }
        
    }
}
