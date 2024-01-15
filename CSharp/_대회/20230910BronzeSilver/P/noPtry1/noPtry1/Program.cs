using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noPtry1
{
    internal class Program
    {
        static int[] combineN2 = new int[10002]; // n C 2
        static int GetRightCount(int x, int n)
        {
            if (x < 0) return n + 1;
            else if (x < n) return n - x;
            else return 0;
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10001; ++i)
            {
                combineN2[i + 1] = combineN2[i] + i;
            }

            int n = int.Parse(Console.ReadLine()) + 1;
            string[] numsXYa = Console.ReadLine().Split(' ');
            string[] numsXYb = Console.ReadLine().Split(' ');

            int result = 0;
            
            int x1 = int.Parse(numsXYa[0]);
            int x2 = int.Parse(numsXYb[0]);
            int y1 = int.Parse(numsXYa[1]);
            int y2 = int.Parse(numsXYb[1]);

            bool isAvailable = false;
            int a1 = -1;
            int a2 = -1;

            // 선이 수직선에 평행한지 여부를 판단합니다.

            if (x1 == x2)
            {
                a1 = Math.Min(y1, y2);
                a2 = Math.Max(y1, y2);
                isAvailable = true;
            }
            else if (y1 == y2)
            {
                //Console.WriteLine("AAAA");
                a1 = Math.Min(x1, x2);
                a2 = Math.Max(x1, x2);
                isAvailable = true;
            }



            //Console.WriteLine($"x1 = {x1}, x2 = {x2}");
            //Console.WriteLine($"y1 = {y1}, y2 = {y2}");
            //Console.WriteLine($"a1 = {a1}, a2 = {a2}");
            //Console.WriteLine(GetRightCount(3, n));
            result = combineN2[n] * combineN2[n];
            if (isAvailable)
            {
                //Console.WriteLine(GetRightCount(a2, n));
                //Console.WriteLine(GetRightCount(a1, n));
                result += n * combineN2[GetRightCount(a1, n) - GetRightCount(a2, n)];
            }

            Console.WriteLine(result);
        }
    }
}
