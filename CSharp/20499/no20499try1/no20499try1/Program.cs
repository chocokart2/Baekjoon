using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no20499try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] num = Console.ReadLine().Split('/');
            int[] score = { int.Parse(num[0]), int.Parse(num[1]), int.Parse(num[2]) };

            if (score[1] == 0 || (score[0] + score[2]) < score[1]) Console.WriteLine("hasu");
            else Console.WriteLine("gosu");
        }
    }
}
