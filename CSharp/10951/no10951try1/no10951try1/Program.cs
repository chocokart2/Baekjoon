using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10951try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string receiveLine = Console.ReadLine();
                if (receiveLine == null) break; // EOF
                Console.WriteLine(int.Parse(receiveLine[0].ToString()) + int.Parse(receiveLine[2].ToString()));
            }
        }
    }
}
