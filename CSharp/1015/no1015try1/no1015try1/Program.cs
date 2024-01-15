using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1015try1
{
    internal class Program
    {
        struct Num
        {
            public int value;
            public int originalIndex;
            public int sortedIndex;
        }
        static Num[] MergeSort(Num[] nums)
        {
            if (nums.Length < 2) return nums;

            int middleIndex = nums.Length >> 1;
            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;
            Num[] result = new Num[nums.Length];
            Num[] left = new Num[middleIndex];
            Num[] right = new Num[nums.Length - middleIndex];
            int index = 0;
            for (; index < middleIndex; ++index)
            {
                left[index] = nums[index];
            }
            for (; index < nums.Length; ++index)
            {
                right[index - middleIndex] = nums[index];
            }
            left = MergeSort(left);
            right = MergeSort(right);

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex].value > right[rightIndex].value)
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
            int size = int.Parse(Console.ReadLine());
            Num[] arrayA = new Num[size];
            string[] nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < nums.Length; ++index)
            {
                arrayA[index].value = int.Parse(nums[index]);
                arrayA[index].originalIndex = index;
            }
            arrayA = MergeSort(arrayA);
            for (int index = 0; index < arrayA.Length; ++index)
            {
                arrayA[index].sortedIndex = index;
            }
            Num[] arrayB = new Num[size]; // 소트 전으로 되돌립니다.
            for (int index = 0; index < arrayA.Length; ++index)
            {
                arrayB[arrayA[index].originalIndex] = arrayA[index];
            }
            StringBuilder result = new StringBuilder();
            result.Append($"{arrayB[0].sortedIndex}");
            for (int index = 1; index < arrayA.Length; index++)
            {
                result.Append($" {arrayB[index].sortedIndex}");
            }
            Console.WriteLine(result);
        }
    }
}
