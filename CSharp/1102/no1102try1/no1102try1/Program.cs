using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1102try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lessSum = 0; // 부족한 대여소의 자전거 갯수의 합
            Console.ReadLine();
            string[] a = Console.ReadLine().Split(' ');
            string[] b = Console.ReadLine().Split(' ');

            for (int index = 0; index < a.Length; ++index)
            {
                lessSum += Math.Max(0, int.Parse(a[index]) - int.Parse(b[index]));
            }

            Console.WriteLine(lessSum);
        }
    }
}
