using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2523try1
{
    internal class Program
    {
        static StringBuilder AppendLine(StringBuilder stringBuilder, int size)
        {
            for (int i = 0; i < size; ++i) stringBuilder.Append('*');
            stringBuilder.Append('\n');
            return stringBuilder;
        }
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            for (int i = 1; i < size; ++i) AppendLine(result, i);
            for (int i = size; i > 0; --i) AppendLine(result, i);
            Console.Write(result);
        }
    }
}
