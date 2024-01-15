using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5596try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] score1 = Console.ReadLine().Split(' ');
            string[] score2 = Console.ReadLine().Split(' ');
            int sum1 = 0;
            int sum2 = 0;
            for (int index = 0; index < 4; ++index)
            {
                sum1 += int.Parse(score1[index]);
                sum2 += int.Parse(score2[index]);
            }
            Console.WriteLine((sum1 > sum2) ? sum1 : sum2);
        }
    }
}
