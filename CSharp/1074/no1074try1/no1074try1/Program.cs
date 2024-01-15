using System;

// 인간은 왜 존재해야 하는가?
// 내가 자살하지 않는 이유는 내가 미쳤기 때문이지. 인간들도 마찬가지야.
// 우리는 그것을 의미라고 부른다. 인생의 의미라고도 하고, 가치관이라고도 볼 수 있지.
// 근데 그게 없으면 인생은 쾌락, 고통, 아니만 아무것도 아닌 것밖에 남지 않는 무의미의 연속이야.
// 그런 의미에서 Stessie - Atmosphere를 들어보는건 어떨까요?

namespace no1074try1
{
    internal class Program
    {
        static long GetPosition(long x, long y) // 리처드 파인만에게 죄송합니다만 재귀함수는 아닙니다. for 문 쓸겁니다.
        {
            //Console.WriteLine($"GetPosition({x}, {y})");
            long result = 0; // 리턴할 값입니다.

            long xPiviot = 1 << 14; // x 좌표의 중심점입니다.
                                    // 현재 x 좌표가 피벗x보다 작지 않으면 result += scale, pivot += scale
                                    // 아니면 pivot -= scale
            long yPiviot = 1 << 14; // y 좌표의 중심점입니다.
                                    // 현재 y 좌표가 y좌표보다 작지 않으면 result += scale * 2, pivot += scale
                                    // 현재 y 좌표가 y좌표보다 작으면 pivot -= scale
            long scale = 1 << (2 * 14); // 4^N
            long pivotScale = 1 << 13;

            for (long N = 0; N < 15; ++N)
            {
                //Console.WriteLine($"loop : result = {result}\t{{Pivot : ({xPiviot}, {yPiviot}), scale = {scale}, pivotScale = {pivotScale} }}");

                if (x < xPiviot)
                {
                    //Console.Write("x 작다 ");
                    xPiviot -= pivotScale;
                }
                else
                {
                    //Console.Write("x 크다 ");
                    xPiviot += pivotScale;
                    result += scale;
                }

                if (y < yPiviot)
                {
                    //Console.WriteLine("y 작다");
                    yPiviot -= pivotScale;
                }
                else
                {
                    //Console.WriteLine("y 크다");
                    yPiviot += pivotScale;
                    result += (scale * 2);
                }
                scale >>= 2;
                pivotScale >>= 1;

            }

            return result;
        }

        static void Main(string[] args)
        {
            string[] num = Console.ReadLine().Split(' ');
            Console.WriteLine(GetPosition(int.Parse(num[2]), int.Parse(num[1])));
        }
    }
}
