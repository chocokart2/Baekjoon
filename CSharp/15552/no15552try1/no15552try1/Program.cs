using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15552try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string[] numbers = Console.ReadLine().Split(' ');
                result.Append($"{int.Parse(numbers[0]) + int.Parse(numbers[1])}\n");
            }
            Console.Write(result);
        }
    }
}
