using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.youtube.com/watch?v=karVrjJ0p8E

            int count = int.Parse(Console.ReadLine());
            int sumA = 0;
            int sumB = 0;

            string[] numsA = Console.ReadLine().Split(' ');
            string[] numsB = Console.ReadLine().Split(' ');
            for (int index = 0; index < count; ++index)
            {
                sumA += int.Parse(numsA[index]);
                sumB += int.Parse(numsB[index]);
            }
            Console.WriteLine($"{sumB} {sumA}");
        }
    }
}
