using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2630try1
{
    internal class Program
    {
        static bool[,] paper; // true는 파란색, false는 하얀색입니다.

        static (int blue, int white) GetPaper(int x, int y, int size)
        {
            //Console.WriteLine($"static (int blue, int white) GetPaper({x}, {y}, {size}) 호출됨");

            // x와 y는 인덱스 숫자이며, 가장 왼쪽 상단의 포지션입니다.

            int resultBlue = 0;
            int resultWhite = 0;

            // 순수하면 리턴
            bool isPure = true;
            for (int yIndex = y; yIndex < y + size; ++yIndex)
            {
                for (int xIndex = x; xIndex < x + size; ++xIndex)
                {
                    if (paper[yIndex, xIndex] != paper[y, x])
                    {
                        isPure = false;
                        break;
                    }
                }
                if (isPure == false) break;
            }



            if (isPure)
            {
                if (paper[y, x] == true) resultBlue = 1;
                else resultWhite = 1;

                //Console.WriteLine($"static (int blue, int white) GetPaper({x}, {y}, {size}) = ({resultBlue}, {resultWhite})");

                return (resultBlue, resultWhite);
            }

            // 아니면 슬라이스(재귀 호출)
            // 슬라이스 하고 난 뒤의 값을 각각 더함
            size >>= 1;

            (int blue, int white) receveValue = GetPaper(x, y, size);
            resultBlue += receveValue.blue;
            resultWhite += receveValue.white;
            receveValue = GetPaper(x + size, y, size);
            resultBlue += receveValue.blue;
            resultWhite += receveValue.white;
            receveValue = GetPaper(x, y + size, size);
            resultBlue += receveValue.blue;
            resultWhite += receveValue.white;
            receveValue = GetPaper(x + size, y + size, size);
            resultBlue += receveValue.blue;
            resultWhite += receveValue.white;

            // 리턴
            //Console.WriteLine($"static (int blue, int white) GetPaper({x}, {y}, {size}) = ({resultBlue}, {resultWhite})");
            return (resultBlue, resultWhite);
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            paper = new bool[count, count];

            for (int y = 0; y < count; ++y)
            {
                string[] nums = Console.ReadLine().Split(' ');

                for (int x = 0; x < count; ++x)
                {
                    paper[y, x] = (nums[x].Equals("1"));
                }
            }

            (int blue, int white) result = GetPaper(0, 0, count);
            Console.WriteLine($"{result.white}\n{result.blue}");
        }
    }
}
