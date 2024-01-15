using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1041try1
{
    internal class Program
    {
        // 투 사이드
        // A B, A C, A D, A E, 
        // B C, B D, E C, E D,
        // F B, F C, F D, F E
        
        // 트리플 사이드
        // A B C, A B D, A E D, A E C
        // F B C, F B D, F E D, F E C

        static void Main(string[] args)
        {
            long sizeN = long.Parse(Console.ReadLine());
            string[] sideNum = Console.ReadLine().Split(' ');
            long[] diceSide = new long[6];
            long result = 0;

            for (int index = 0; index < 6; ++index)
            {
                diceSide[index] = long.Parse(sideNum[index]);
            }

            if (sizeN == 1)
            {
                long maxSide = 0;

                for (int index = 0; index < 6; ++index)
                {
                    if (diceSide[index] > maxSide) maxSide = diceSide[index];
                    result += diceSide[index];
                }

                result -= maxSide;
                Console.WriteLine(result);
                return;
            }




            int[,] twoSideIndex = new int[12, 2]
            {
                { 0, 1 }, { 0, 2 }, { 0, 3 }, { 0, 4 },
                { 1, 2 }, { 1, 3 }, { 4, 2 }, { 4, 3 },
                { 5, 1 }, { 5, 2 }, { 5, 3 }, { 5, 4 }
            };

            int[,] tripleSideIndex = new int[8, 3]
            {
                { 0, 1, 2 }, { 0, 1, 3 }, { 0, 4, 3 }, { 0, 4, 2 },
                { 5, 1, 2 }, { 5, 1, 3 }, { 5, 4, 3 }, { 5, 4, 2 }
            };


            long minSumOneSide = long.MaxValue;
            long minSumTwoSide = long.MaxValue;
            long minSumTripleSide = long.MaxValue;



            for (int index = 0; index < 6; ++index)
            {
                if (minSumOneSide > diceSide[index]) minSumOneSide = diceSide[index];
            }
            for (int index = 0; index < 12; ++index)
            {
                long oneSum = diceSide[twoSideIndex[index, 0]] + diceSide[twoSideIndex[index, 1]];

                if (minSumTwoSide > oneSum) minSumTwoSide = oneSum;
            }
            for (int index = 0; index < 8; ++index)
            {
                long oneSum = diceSide[tripleSideIndex[index, 0]] + diceSide[tripleSideIndex[index, 1]] + diceSide[tripleSideIndex[index, 2]];

                if (minSumTripleSide > oneSum) minSumTripleSide = oneSum;
            }

            result =
                (((sizeN - 2) * (sizeN - 2) + (sizeN - 2) * (sizeN - 1) * 4) * minSumOneSide) +
                (((sizeN - 1) * 4 + (sizeN - 2) * 4) * minSumTwoSide) +
                4 * minSumTripleSide;
            Console.WriteLine(result);
        }
    }
}
