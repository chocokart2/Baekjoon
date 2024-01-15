using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no15807try1
{
    internal class Program
    {

        static bool IsAllInside(params int[] val)
        {
            for (int index = 0; index < val.Length; index++)
            {
                if (val[index] < 0 || val[index] > 3000) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            // 뭐지 이 미친 스토커는


            // 자기 자신 + 1 => 위쪽 오른쪽으로 그리고 위쪽 왼쪽으로 값 복사 표시(라이트에 한정하여) : 값이 있으면 추가
            // 일단 처음에 false였다가 광원을 만나면 true로 바뀌고 카운트 시작.
            // 표시한대로 위로 업데이트 만약 값이 있으면 추가

            // 3000 * 3000 * 3 + 100_000 = 27_000_000 + 100_000 = 27_100_000

            int size = 3_001;
            int zero = 1_500;
            bool[,] isLightOrigin = new bool[size, size];
            int[,] light = new int[size, size];
            int[,] lightOrigin = new int[size, size];
            int[,] lightLeftUp = new int[size, size]; // origin은 제외
            int[,] lightRightUp = new int[size, size]; // origin은 제외

            int lightCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < lightCount; i++)
            {
                string[] one = Console.ReadLine().Split(' ');
                int x = zero + int.Parse(one[0]);
                int y = zero + int.Parse(one[1]);

                isLightOrigin[x, y] = true;
                lightOrigin[x, y]++;
            }

            // 대각선으로 카운트 시작
            int startY = 1;
            int startX = 0;
            for (startY = 1; startY < size; ++startY)
            {
                // 오른쪽 위로
                bool hasFoundOrigin = false;
                for (int x = startX, y = startY, nextX = x + 1, nextY = y + 1; IsAllInside(x, y, nextX, nextY); ++x, ++y, ++nextX, ++nextY)
                {
                    if (isLightOrigin[x, y])
                    {
                        hasFoundOrigin = true;
                    }
                    if (hasFoundOrigin == false) continue;
                    lightRightUp[nextX, nextY] += lightOrigin[x, y] + lightRightUp[x, y];
                }
            }
            startX = size - 1;
            for (startY = 1; startY < size; ++startY)
            {
                // 왼쪽 위로
                bool hasFoundOrigin = false;
                for (int x = startX, y = startY, nextX = x - 1, nextY = y + 1; IsAllInside(x, y, nextX, nextY); --x, ++y, --nextX, ++nextY)
                {
                    if (isLightOrigin[x, y])
                    {
                        hasFoundOrigin = true;
                    }
                    if (hasFoundOrigin == false) continue;
                    lightLeftUp[nextX, nextY] += lightOrigin[x, y] + lightLeftUp[x, y];
                }
            }
            startY = 0;
            for (startX = 0; startX < size; ++startX)
            {
                // 오른쪽 위로
                bool hasFoundOrigin = false;
                for (int x = startX, y = startY, nextX = x + 1, nextY = y + 1; IsAllInside(x, y, nextX, nextY); ++x, ++y, ++nextX, ++nextY)
                {
                    if (isLightOrigin[x, y])
                    {
                        hasFoundOrigin = true;
                    }
                    if (hasFoundOrigin == false) continue;
                    lightRightUp[nextX, nextY] += lightOrigin[x, y] + lightRightUp[x, y];
                }
            }
            for (startX = 0; startX < size; ++startX)
            {
                // 왼쪽 위로
                bool hasFoundOrigin = false;
                for (int x = startX, y = startY, nextX = x - 1, nextY = y + 1; IsAllInside(x, y, nextX, nextY); --x, ++y, --nextX, ++nextY)
                {
                    if (isLightOrigin[x, y])
                    {
                        hasFoundOrigin = true;
                    }
                    if (hasFoundOrigin == false) continue;
                    lightLeftUp[nextX, nextY] += lightOrigin[x, y] + lightLeftUp[x, y];
                }
            }

            for (int y = 0; y < size; ++y)
            {
                for (int x = 0; x < size; ++x)
                {
                    light[x, y] += lightLeftUp[x, y] + lightRightUp[x, y] + lightOrigin[x, y];
                }
            }
            for (int x = 0; x < size; ++x)
            {
                for (int y = 0; y + 1 < size; ++y)
                {
                    light[x, y + 1] += light[x, y];
                }
            }

            StringBuilder result = new StringBuilder();
            int queryCount = int.Parse(Console.ReadLine());
            for (int q = 0; q < queryCount; ++q)
            {
                string[] one = Console.ReadLine().Split(' ');
                int x = zero + int.Parse(one[0]);
                int y = zero + int.Parse(one[1]);

                result.AppendLine($"{light[x, y]}");
            }
            Console.Write(result);
        }
    }
}
