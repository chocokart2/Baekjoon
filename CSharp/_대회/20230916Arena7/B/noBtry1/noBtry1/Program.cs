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
            Console.ReadLine();
            int count = 0;
            int max = 0;
            string[] recvLine = Console.ReadLine().Split(' ');
            for (int index = 0; index < recvLine.Length; ++index)
            {
                count++;
                if (recvLine[index][0] == '0')
                    count = 0;
                if (count > max) max = count;
            }
            Console.WriteLine(max);
        }
    }
}
