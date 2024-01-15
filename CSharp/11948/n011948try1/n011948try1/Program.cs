using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace n011948try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] score = new int[6];
            int sum = 0;
            int minA = int.MaxValue;
            int minB = int.MaxValue;
            for (int i = 0; i < score.Length; i++)
            {
                score[i] = int.Parse(Console.ReadLine());
                sum += score[i];
            }
            for (int i = 0; i < 4; ++i)
                minA = Math.Min(minA, score[i]);
            minB = Math.Min(score[4], score[5]);

            sum -= minA;
            sum -= minB;

            Console.WriteLine(sum);
        }
    }
}
