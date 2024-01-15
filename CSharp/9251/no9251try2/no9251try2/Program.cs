using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9251try2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            int[,] LCSCount = new int[str1.Length + 1, str2.Length + 1];
            for (int y = 0; y < str2.Length; y++)
            {
                for (int x = 0; x < str1.Length; x++)
                {
                    if (str1[x] == str2[y])
                    {
                        LCSCount[x + 1, y + 1] = LCSCount[x, y] + 1;
                    }
                    else
                    {
                        LCSCount[x + 1, y + 1] = Math.Max(LCSCount[x + 1, y], LCSCount[x, y + 1]);
                    }
                }
            }
            Console.WriteLine(LCSCount[str1.Length, str2.Length]);
        }
    }
}
