using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2495try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; ++i)
            {
                string recvLine = Console.ReadLine();
                char a = '*';
                int lengthMax = 1;
                int length = 0;
                for (int index = 0; index < recvLine.Length; ++index)
                {
                    if (recvLine[index] == a)
                    {
                        length++;
                        if (length > lengthMax) lengthMax = length;
                    }
                    else
                    {
                        length = 1;
                        a = recvLine[index];
                    }
                }
                Console.WriteLine(lengthMax);
            }

        }
    }
}
