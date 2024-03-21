using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no14219try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(' ');

            Console.WriteLine((int.Parse(size[0]) * int.Parse(size[1]) % 3 == 0) ? "YES" : "NO");

        }
    }
}
