
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10026try1
{
    internal class Program
    {
        // 함수형 도전
        static (bool[,] newTrace, int newBlob) GraphSearch(int size, char[,] paint, bool[,] trace, char[] searching)
        {
            int newBlob = 0;
            int[] deltaX = { 1, -1, 0, 0 };
            int[] deltaY = { 0, 0, 1, -1 };

            bool M_IsAvailAble(int x, int y)
            {
                if (x < 0 || x >= size) return false;
                if (y < 0 || y >= size) return false;
                if (trace[x, y]) return false;
                for (int index = 0; index < searching.Length; ++index)
                {
                    if (searching[index] == paint[x, y]) return true;
                }
                return false;
            }

            for (int x = 0; x < size; ++x)
            {
                for (int y = 0; y < size; ++y)
                {
                    if (M_IsAvailAble(x, y) == false) continue;

                    // 너비 우선 탐색을 진행한다.
                    (int x, int y)[] queue = new (int x, int y)[size * size];
                    int queueRear = 0;
                    int queueHead = 1;
                    queue[0] = (x, y);
                    newBlob++;

                    while (queueRear < queueHead)
                    {
                        (int x, int y) one = queue[queueRear];
                        queueRear++;

                        for (int index = 0; index < 4; ++index)
                        {
                            int newX = one.x + deltaX[index];
                            int newY = one.y + deltaY[index];

                            if (M_IsAvailAble(newX, newY) == false) continue;

                            queue[queueHead] = (newX, newY);
                            queueHead++;

                            trace[newX, newY] = true;
                        }
                    }
                }
            }

            return (trace, newBlob);
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] paint = new char[size, size];
            bool[,] colorTraceTwoColor = new bool[size, size]; 
            bool[,] colorTraceThreeColor = new bool[size, size];


            // 초기화
            for (int y = 0; y < size; y++)
            {
                string oneLine = Console.ReadLine();
                for (int x = 0; x < size; ++x)
                {
                    paint[x, y] = oneLine[x];
                }
            }

            (bool[,] newTrace, int newBlob) returnValue;

            // 파란색 카운팅
            returnValue = GraphSearch(size, paint, colorTraceTwoColor, new char[] { 'B' });
            int twoColorResult = returnValue.newBlob;
            colorTraceTwoColor = returnValue.newTrace;

            returnValue = GraphSearch(size, paint, colorTraceThreeColor, new char[] { 'B' });
            int threeColorResult = returnValue.newBlob;
            colorTraceThreeColor = returnValue.newTrace;
            //Console.WriteLine($">> 파랑이 : {returnValue.newBlob}");

            // 적록색약 카운팅
            returnValue = GraphSearch(size, paint, colorTraceTwoColor, new char[] { 'R', 'G' });
            twoColorResult += returnValue.newBlob;

            // 일반 카운팅
            returnValue = GraphSearch(size, paint, colorTraceThreeColor, new char[] { 'R' });
            colorTraceThreeColor = returnValue.newTrace;
            threeColorResult += returnValue.newBlob;
            //Console.WriteLine($">> 빨강이 : {returnValue.newBlob}");

            returnValue = GraphSearch(size, paint, colorTraceThreeColor, new char[] { 'G' });
            threeColorResult += returnValue.newBlob;
            //Console.WriteLine($">> 초록이 : {returnValue.newBlob}");

            Console.WriteLine($"{threeColorResult} {twoColorResult}");
        }
    }
}
