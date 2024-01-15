using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9610try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] result = new int[5]; // result[0] == axis
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                if (recvLine[0].Equals("0") || recvLine[1].Equals("0"))
                {
                    result[0]++;
                    continue;
                }

                int x = int.Parse(recvLine[0]);
                int y = int.Parse(recvLine[1]);

                if (x > 0)
                {
                    if (y > 0) result[1]++;
                    else result[4]++;
                }
                else
                {
                    if (y > 0) result[2]++;
                    else result[3]++;
                }
            }

            Console.WriteLine($"Q1: {result[1]}");
            Console.WriteLine($"Q2: {result[2]}");
            Console.WriteLine($"Q3: {result[3]}");
            Console.WriteLine($"Q4: {result[4]}");
            Console.WriteLine($"AXIS: {result[0]}");

        }
    }
}
