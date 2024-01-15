using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9663try2
{
    internal class Program
    {
        // 만약 index의 차이 == value의 차이인경우 false
        // 만약 value가 같은 경우 false

        static int[] queenX;
        static int yCursor;
        static bool isNeedBacktrack;
        static int backtrackX;
        static int result;


        static bool CanPlace(int x)
        {
            for (int yIndex = 0; yIndex < yCursor; ++yIndex)
            {
                if (x == queenX[yIndex]) return false;
                if (Math.Abs(x - queenX[yIndex]) == yCursor - yIndex) return false;
            }
            return true;
        }
        static void SetQueen(int x)
        {
            queenX[yCursor] = x;
            ++yCursor;
        }
        static void Init(int size)
        {
            queenX = new int[size];
            yCursor = 0;
            result = 0;
        }


        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Init(N);

            while (true)
            {
                if (yCursor == queenX.Length) result++;

                int x = isNeedBacktrack ? backtrackX : -1;
                isNeedBacktrack = false;

                bool isFoundQueen = false;
                for (int queenPositionX = x + 1; queenPositionX < queenX.Length; ++queenPositionX)
                {
                    if (CanPlace(queenPositionX))
                    {
                        isFoundQueen = true;
                        SetQueen(queenPositionX);
                        break;
                    }
                }
                if (!isFoundQueen)
                {
                    if (yCursor == 0) break;
                    isNeedBacktrack = true;
                    backtrackX = queenX[yCursor - 1];
                    yCursor--;
                }
            }

            Console.WriteLine(result);
        }
    }
}
