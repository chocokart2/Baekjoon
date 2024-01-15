using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string recvLine = Console.ReadLine();
            int[] words = new int[5];
            for (int index = 0; index < recvLine.Length; index++)
            {
                char one = recvLine[index];

                if (one == 'u') words[0]++;
                if (one == 'o') words[1]++;
                if (one == 's') words[2]++;
                if (one == 'p') words[3]++;
                if (one == 'c') words[4]++;
            }
            int result = words[0];
            for (int index = 1; index < 5; ++index)
            {
                result = Math.Min(result, words[index]);
            }
            Console.WriteLine(result);
        }
    }
}
