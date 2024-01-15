using System;

namespace no11726try1
{
    internal class Program
    {
        static int[] MergeSort(int[] target)
        {
            if (target.Length < 2) return target;

            int[] result = new int[target.Length];
            int middleIndex = target.Length >> 1;
            int[] left = new int[middleIndex];
            int[] right = new int[target.Length - middleIndex];
            for (int index = 0; index < middleIndex; ++index) left[index] = target[index];
            for (int index = 0; index < target.Length - middleIndex; ++index) right[index] = target[middleIndex + index];
            left = MergeSort(left);
            right = MergeSort(right);
            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (right[rightIndex] < left[leftIndex])
                {
                    result[resultIndex] = right[rightIndex];
                    ++resultIndex;
                    ++rightIndex;
                }
                else
                {
                    result[resultIndex] = left[leftIndex];
                    ++resultIndex;
                    ++leftIndex;
                }
            }
            while (leftIndex < left.Length)
            {
                result[resultIndex] = left[leftIndex];
                ++resultIndex;
                ++leftIndex;
            }
            while (rightIndex < right.Length)
            {
                result[resultIndex] = right[rightIndex];
                ++resultIndex;
                ++rightIndex;
            }
            return result;
        }

        static void Main(string[] args)
        {
            int result = 1;
            int count = int.Parse(Console.ReadLine());
            int[] dolls = new int[count];
            string[] nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < nums.Length; ++index)
            {
                dolls[index] = int.Parse(nums[index]);
            }
            dolls = MergeSort(dolls);

            int currentStack = 1;
            int currentSize = 0;
            for (int index = 0; index < dolls.Length; ++index)
            {
                if (currentSize == dolls[index])
                {
                    ++currentStack;
                    if (result < currentStack) result = currentStack;
                }
                else
                {
                    currentSize = dolls[index];
                    currentStack = 1;
                }
            }
            Console.WriteLine(result);
        }
    }
}
