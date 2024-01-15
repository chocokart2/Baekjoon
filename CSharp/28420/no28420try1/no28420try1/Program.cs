using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no28420try1
{
    internal class Program
    {
        static int GetRect(int[,] array, int x1, int y1, int x2, int y2)
        {
            return array[x2, y2] - array[x2, y1] - array[x1, y2] + array[x1, y1];
        }

        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(' ');
            int sizeX = int.Parse(size[1]);
            int sizeY = int.Parse(size[0]);
            string[] numAbc = Console.ReadLine().Split(' ');
            int sizeA = int.Parse(numAbc[0]);
            int sizeB = int.Parse(numAbc[1]);
            int sizeC = int.Parse(numAbc[2]);

            int min = int.MaxValue;


            int[,] sum = new int[sizeX + 1, sizeY + 1];
            for (int y = 0; y < sizeY; y++)
            {
                string[] oneLineNums = Console.ReadLine().Split(' ');
                for (int x = 0; x < sizeX; x++)
                {
                    sum[x + 1, y + 1]
                        = sum[x + 1, y] + sum[x, y + 1] + int.Parse(oneLineNums[x]) - sum[x, y];
                }
            }

            // 세팅 끝, 3개의 루프를 돕니다.
            // 1. [x, y] ~ [x + b + c, y + a]
            // 2. [x, y] ~ [x + c, y + a] + [x + c, y + a] ~ [x + c + a, y + a + b]
            // 3. [x, y] ~ [x + b, y + a] + [x + b, y + a] ~ [x + b + a, y + a + c]

            for (int y = 0; y < sizeY + 1 - sizeA; y++)
            {
                for (int x = 0; x < sizeX + 1 - sizeB - sizeC; x++)
                {
                    min = Math.Min(min, GetRect(sum, x, y, x + sizeB + sizeC, y + sizeA));
                }
            }
            
            for (int y = 0; y < sizeY + 1 - sizeA - sizeB; y++)
            {
                for (int x = 0; x < sizeX + 1 - sizeC - sizeA; x++)
                {
                    min = Math.Min(min, GetRect(sum, x, y, x + sizeC, y + sizeA) + GetRect(sum, x + sizeC, y + sizeA, x + sizeC + sizeA, y + sizeA + sizeB));
                }
            }
            
            for (int y = 0; y < sizeY + 1 - sizeA - sizeC; y++)
            {
                for (int x = 0; x < sizeX + 1 - sizeB - sizeA; x++)
                {
                    min = Math.Min(min, GetRect(sum, x, y, x + sizeB, y + sizeA) + GetRect(sum, x + sizeB, y + sizeA, x + sizeB + sizeA, y + sizeA + sizeC));
                }
            }

            Console.WriteLine(min);
        }
    }
}
