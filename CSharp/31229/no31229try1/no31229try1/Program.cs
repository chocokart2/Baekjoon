using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no31229try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                result.Append($"{(i + 1) * (i + 1)} ");
            }
            Console.WriteLine(result);

        }
    }
}
