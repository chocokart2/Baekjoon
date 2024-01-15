using System;
namespace no11399try1
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
            for (int index = 0; index < target.Length - middleIndex; ++index) right[index] = target[index + middleIndex];
            
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
            int result = 0;

            Console.ReadLine();
            string[] nums = Console.ReadLine().Split(' ');
            int count = nums.Length;
            int[] costTime = new int[count];
            for (int index = 0; index < count; ++index)
                costTime[index] = int.Parse(nums[index]);

            costTime = MergeSort(costTime);
            for (int index = 0; index < count; ++index)
            {
                result += costTime[index] * (count - index);
            }

            Console.WriteLine(result);
        }
    }
}
