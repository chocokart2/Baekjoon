using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10808try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] result = new int[26];
            string recvLine = Console.ReadLine();
            for (int index = 0; index < recvLine.Length; ++index)
                result[recvLine[index] - 'a']++;
            Console.Write(result[0]);
            for (int index = 1; index < result.Length; ++index) Console.Write($" {result[index]}");
        }
    }
}
