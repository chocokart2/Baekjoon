using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9625try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int countA = 1;
            int tempA = 0;
            int countB = 0;
            int tempB = 0;

            for (int i = 0; i < count; i++)
            {
                tempA = countB;
                tempB = countA + countB;
                countA = tempA;
                countB = tempB;
            }
            Console.WriteLine($"{countA} {countB}");
        }
    }
}
