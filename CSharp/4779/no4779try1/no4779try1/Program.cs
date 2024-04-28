using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no4779try1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string Get(int i)
            {
                if (i == 0) return "-";
                StringBuilder result = new StringBuilder();
                result.Append(Get(i - 1));
                for (int t = (int)Math.Pow(3, i - 1); t > 0; --t)
                {
                    result.Append(' ');
                }
                result.Append(Get(i - 1));
                return result.ToString();
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == null)
                {
                    break;
                }

                Console.WriteLine(Get(int.Parse(input)));
            }
        }
    }
}
