using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17390try1
{
    internal class Program
    {
        static int[] MergeSort(int[] nums)
        {
            if (nums.Length < 2) return nums;

            int middleIndex = nums.Length / 2;
            int leftIndex = 0;
            int rightIndex = 0;
            int resultIndex = 0;
            int[] left = new int[middleIndex];
            int[] right = new int[nums.Length - middleIndex];
            int[] result = new int[nums.Length];
            for (int index = 0; index < left.Length; ++index)
            {
                left[index] = nums[index];
            }
            for (int index = 0; index < right.Length; ++index)
            {
                right[index] = nums[index + middleIndex];
            }
            left = MergeSort(left);
            right = MergeSort(right);

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
            int query = int.Parse(Console.ReadLine().Split(' ')[1]);
            string[] recvLine = Console.ReadLine().Split(' ');
            int[] nums = new int[recvLine.Length];
            for (int index = 0; index < recvLine.Length; index++)
            {
                nums[index] = int.Parse(recvLine[index]);
            }
            nums = MergeSort(nums);
            int[] sum = new int[nums.Length + 1];
            for (int index = 0; index < nums.Length; index++)
            {
                sum[index + 1] = sum[index] + nums[index];
            }
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < query; ++i)
            {
                string[] one = Console.ReadLine().Split(' ');

                result.AppendLine((sum[int.Parse(one[1])] - sum[int.Parse(one[0]) - 1]).ToString());
            }
            Console.Write(result);
        }
    }
}
