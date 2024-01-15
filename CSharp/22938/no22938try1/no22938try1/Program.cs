using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no22938try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] points1 = Console.ReadLine().Split(' ');
            string[] points2 = Console.ReadLine().Split(' ');

            ulong x = (ulong)Math.Abs(long.Parse(points1[0]) - long.Parse(points2[0]));
            ulong y = (ulong)Math.Abs(long.Parse(points1[1]) - long.Parse(points2[1]));
            ulong r = ulong.Parse(points1[2]) + ulong.Parse(points2[2]);
            x *= x;
            y *= y;
            r *= r;

            if (r > x + y) Console.WriteLine("YES");
            else Console.WriteLine("NO");
        }
    }
}
