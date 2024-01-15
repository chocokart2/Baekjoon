using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2443try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine()) - 1;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < size; ++i)
            {
                for (int l = 0; l < i; ++l)
                {
                    result.Append(' ');
                }
                for (int m = i; m < size; ++m)
                {
                    result.Append('*');
                }
                result.Append('*');
                for (int m = i; m < size; ++m)
                {
                    result.Append('*');
                }
                result.Append('\n');
            }
            for (int i = 0; i < size; ++i)
            {
                result.Append(' ');
            }
            result.Append('*');
            Console.WriteLine(result);
        }
    }
}
