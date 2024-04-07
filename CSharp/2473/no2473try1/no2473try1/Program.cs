using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2473try1
{
    internal class Program
    {
        static int[] MergeSortAscendingRecursive(int[] array)
        {
            if (array.Length < 2) return array;

            int middleIndex = array.Length / 2;
            int leftIndex = 0;
            int rightIndex = 0;
            int resultIndex = 0;
            int[] result = new int[array.Length];
            int[] left = new int[middleIndex];
            int[] right = new int[array.Length - middleIndex];
            for (int index = 0; index < middleIndex; index++)
            {
                left[index] = array[index];
            }
            for (int index = middleIndex; index < array.Length; index++)
            {
                right[index - middleIndex] = array[index];
            }
            left = MergeSortAscendingRecursive(left);
            right = MergeSortAscendingRecursive(right);

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex] > right[rightIndex])
                {
                    result[resultIndex++] = right[rightIndex++];
                }
                else
                {
                    result[resultIndex++] = left[leftIndex++];
                }
            }
            while (leftIndex < left.Length)
            {
                result[resultIndex++] = left[leftIndex++];
            }
            while (rightIndex < right.Length)
            {
                result[resultIndex++] = right[rightIndex++];
            }
            return result;
        }

        static void Main(string[] args)
        {
            int[] nums = new int[int.Parse(Console.ReadLine())];

            string[] recvLine = Console.ReadLine().Split(' ');
            for (int index = 0; index < recvLine.Length; index++)
            {
                nums[index] = int.Parse(recvLine[index]);
            }

            nums = MergeSortAscendingRecursive(nums);

            int sumAbsolute = int.MaxValue;
            string answer = ""; // format = $"{a} {b} {c}";


            // 1개의 원소를 선택한 상황에서 투 포인터 알고리즘을 실행한다.

            for (int index = 0; index < nums.Length - 2; ++index)
            {
                int target = nums[index];
                int headIndex = index + 1;
                int rearIndex = index + 2;

                while (headIndex < nums.Length - 1)
                {
                    int oneSum = nums[headIndex] + nums[rearIndex];
                }
            }

        }
    }
}
