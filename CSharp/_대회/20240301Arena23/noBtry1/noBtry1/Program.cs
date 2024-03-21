using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            for (int i = int.Parse(Console.ReadLine()); i > 0; i--)
            {
                int size = int.Parse(Console.ReadLine());

                if (size == 1) result.AppendLine("0");
                else if (size == 2) result.AppendLine("11");
                else if (size == 3) result.AppendLine("121");
                else
                {
                    result.Append("11");
                    for (int x = 0; x < size - 4; x++)
                    {
                        result.Append("0");
                    }
                    result.Append("11\n");
                }
            }

            Console.WriteLine(result);
        }
    }
}
