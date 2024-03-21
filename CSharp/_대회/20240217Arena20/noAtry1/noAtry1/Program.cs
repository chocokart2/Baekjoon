using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noAtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int half = (count + 1) / 2;
            string[] recvLine = Console.ReadLine().Split(' ');

            int[] value = new int[100_001];
            for (int index = 0; index < recvLine.Length; ++index)
            {
                value[int.Parse(recvLine[index])]++;
            }
            for (int index = 0; index < 100_001; ++index)
            {
                if (value[index] > half)
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
