using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no8try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < size; y++)
            {
                for (int x = 1; x <= size; ++x)
                {
                    sb.Append($"{x} ");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append('\n');
            }
            Console.WriteLine(sb);
        }
    }
}
