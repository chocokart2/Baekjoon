using System;

namespace no1925try1
{
    internal class Program
    {
        struct Point
        {
            public long x;
            public long y;
        }

        static bool IsItTriangle(Point a, Point b, Point c)
        {
            // 점 a와 점 b를 지나는 직선의 방정식을 만들고, 점 c가 그 방정식에 맞는다면 false를 리턴합니다.
            // 점 a와 점 b가 동일하다면, 모든 기울기를 만족하므로 항상 false를 리턴합니다.

            bool isEqualX = a.x == b.x;
            bool isEqualY = a.y == b.y;

            // 얼리 리턴 패턴
            if (isEqualX && isEqualY) return false;
            else if (isEqualX) return c.x != a.x; // x = a.x라는 직선의 방정식
            else if (isEqualY) return c.y != a.y; // y = a.y라는 직선의 방정식
            else return (b.x - a.x) * (c.y - a.y) != (b.y - a.y) * (c.x - a.x);
        }
        static long GetLengthSquare(Point a, Point b) => (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);

        static void Main(string[] args)
        {
            string[] recvLineA = Console.ReadLine().Split(' ');
            Point a = new Point() { x = long.Parse(recvLineA[0]), y = long.Parse(recvLineA[1]) };
            string[] recvLineB = Console.ReadLine().Split(' ');
            Point b = new Point() { x = long.Parse(recvLineB[0]), y = long.Parse(recvLineB[1]) };
            string[] recvLineC = Console.ReadLine().Split(' ');
            Point c = new Point() { x = long.Parse(recvLineC[0]), y = long.Parse(recvLineC[1]) };

            if (IsItTriangle(a, b, c) == false)
            {
                Console.WriteLine("X");
                return;
            }

            long lengthSquareA = GetLengthSquare(b, c);
            long lengthSquareB = GetLengthSquare(a, c);
            long lengthSquareC = GetLengthSquare(a, b);

            if (lengthSquareA == lengthSquareB && lengthSquareB == lengthSquareC)
            {
                Console.WriteLine("JungTriangle");
                return;
            }

            long lengthSquareMax = Math.Max(Math.Max(lengthSquareA, lengthSquareB), lengthSquareC);

            long checkValue = lengthSquareMax * 2 - lengthSquareA - lengthSquareB - lengthSquareC;

            if (checkValue > 0) Console.Write("Dunkak");
            else if (checkValue == 0) Console.Write("Jikkak");
            else Console.Write("Yeahkak");

            if (lengthSquareA == lengthSquareB || lengthSquareB == lengthSquareC || lengthSquareC == lengthSquareA)
            {
                Console.Write("2");
            }
            Console.WriteLine("Triangle");
        }
    }
}
