using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2693try1
{
    internal class Program
    {
        static T[] MergeSortRecursive<T>(T[] array, Func<T, T, bool> isRightFirst)
        {
            if (array.Length < 2) return array;

            int middleIndex = array.Length / 2;
            int leftIndex = 0;
            int rightIndex = 0;
            int resultIndex = 0;
            T[] result = new T[array.Length];
            T[] left = new T[middleIndex];
            T[] right = new T[array.Length - middleIndex];
            for (int index = 0; index < middleIndex; index++)
            {
                left[index] = array[index];
            }
            for (int index = middleIndex; index < array.Length; index++)
            {
                right[index - middleIndex] = array[index];
            }
            left = MergeSortRecursive(left, isRightFirst);
            right = MergeSortRecursive(right, isRightFirst);

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (isRightFirst(left[leftIndex], right[rightIndex]))
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
            StringBuilder answer = new StringBuilder();

            for (int t = int.Parse(Console.ReadLine()); t > 0; t--)
            {
                string[] numStr = Console.ReadLine().Split(' ');
                int[] nums = new int[10];
                for (int index = 0; index < numStr.Length; index++)
                {
                    nums[index] = int.Parse(numStr[index]);
                }
                nums = MergeSortRecursive(nums, delegate (int left, int right) { return left < right; });

                answer.Append($"{nums[2]}\n");
            }

            Console.Write(answer);

        }
    }
}
