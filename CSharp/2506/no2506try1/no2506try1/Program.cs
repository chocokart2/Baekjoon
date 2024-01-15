using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2506try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int stack = 1;
            Console.ReadLine();
            string[] recvLine = Console.ReadLine().Split(' ');
            
            for (int index = 0; index < recvLine.Length; index++)
            {
                if (recvLine[index][0] == '1')
                {
                    score += stack;
                    stack++;
                }
                else
                {
                    stack = 1;
                }
            }
            Console.WriteLine(score);
        }
    }
}
