using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15781try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int max = 0;
            Console.ReadLine();
            string[] recvLine = Console.ReadLine().Split(' ');
            for (int index = 0; index < recvLine.Length; index++)
            {
                int one = int.Parse(recvLine[index]);
                if (max < one)
                {
                    max = one;
                }
            }
            sum += max;
            max = 0;
            recvLine = Console.ReadLine().Split(' ');
            for (int index = 0; index < recvLine.Length; index++)
            {
                int one = int.Parse(recvLine[index]);
                if (max < one)
                {
                    max = one;
                }
            }
            sum += max;

            Console.WriteLine(sum);
        }
    }
}
