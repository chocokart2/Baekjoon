using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().ToUpper().Split(' ');

                int index = 0;
                while (recvLine[0][index] != 'X')
                {
                    index++;
                }

                result.Append(recvLine[1][index]);
            }
            Console.WriteLine(result);
        }
    }
}
