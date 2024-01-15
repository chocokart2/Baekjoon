using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17202try1
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string phoneA = Console.ReadLine();
            string phoneB = Console.ReadLine();
            StringBuilder line = new StringBuilder();
            for (int index = 0; index < 8; ++index)
            {
                line.Append(phoneA[index]);
                line.Append(phoneB[index]);
            }
            while (line.Length > 2)
            {

            }

        }
    }
}
