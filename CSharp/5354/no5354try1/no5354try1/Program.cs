using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5354try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; ++i)
            {
                int size = int.Parse(Console.ReadLine());

                for (int y = 0; y < size; ++y)
                {
                    for (int x = 0; x < size; ++x)
                    {
                        if (x == 0 || y == 0 || x == size - 1 || y == size - 1)
                            result.Append('#');
                        else result.Append('J');
                    }
                    result.Append('\n');
                }
                result.Append('\n');
            }
            Console.Write(result);
        }
    }
}
