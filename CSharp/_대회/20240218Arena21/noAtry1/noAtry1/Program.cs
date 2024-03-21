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
            StringBuilder result = new StringBuilder();
            for (int i = int.Parse(Console.ReadLine()); i > 0; --i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int termA = int.Parse(recvLine[0]);
                int termB = int.Parse(recvLine[1]);
                int CountA = int.Parse(recvLine[2]);
                int CountB = int.Parse(recvLine[3]);
                int sumA = termA * CountA;
                int sumB = termB * CountB;
                int one = Math.Max(sumA, sumB);
                while(sumA > sumB && sumA > termA)
                {
                    sumA -= termA;
                    sumB += termA;
                    one = Math.Min(one, Math.Max(sumA, sumB));
                }
                result.Append($"{one}\n");
            }
            Console.Write(result);

        }
    }
}
