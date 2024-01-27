using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no13711try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] arrangeA = Console.ReadLine().Split(' ');
            int[] numToIndex = new int[arrangeA.Length + 1]; // nums[숫자] -> arrangeA의 인덱스
            for (int index = 0; index < arrangeA.Length; index++)
            {
                numToIndex[int.Parse(arrangeA[index])] = index + 1;
            }
            string[] arrangeB = Console.ReadLine().Split(' ');
            int[] nums = new int[arrangeB.Length + 1];
            for (int index = 0; index < arrangeB.Length; index++)
            {
                nums[index + 1] = numToIndex[int.Parse(arrangeB[index])];
            }

            //nums의 Lis 구하기
            int[] longestSize = new int[nums.Length + 1];
            int[] lisSizeToMinimumNums = new int[nums.Length + 1];
            int sizeLIS = 0;

            for (int index = 1; index < nums.Length; ++index)
            {
                int one = nums[index];

                int binarySearchMin = 0;
                int binarySearchMax = sizeLIS;

                while (true)
                {
                    int binarySearchMiddle = (binarySearchMin + binarySearchMax) / 2;

                    if (lisSizeToMinimumNums[binarySearchMiddle] >= one)
                    {
                        binarySearchMax = binarySearchMiddle - 1;
                        continue;
                    }
                    if (binarySearchMiddle == sizeLIS)
                    {
                        lisSizeToMinimumNums[binarySearchMiddle + 1] = one;
                        longestSize[index] = binarySearchMiddle + 1;
                        sizeLIS++;
                        break;
                    }
                    if (lisSizeToMinimumNums[binarySearchMiddle + 1] >= one)
                    {
                        lisSizeToMinimumNums[binarySearchMiddle + 1] = one;
                        longestSize[index] = binarySearchMiddle + 1;
                        break;
                    }
                    else
                    {
                        binarySearchMin = binarySearchMiddle + 1;
                        continue;
                    }
                }
            }
        }
    }
}
