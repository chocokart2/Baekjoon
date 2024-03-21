using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no27932try1
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
            string[] recvLineNK = Console.ReadLine().Split(' ');
            int[] array = new int[int.Parse(recvLineNK[0])];

            if (array.Length < 2)
            {
                Console.WriteLine(0);
                return;
            }

            int limit = int.Parse(recvLineNK[1]);
            if (limit == array.Length)
            {
                Console.WriteLine(0);
                return;
            }

            string[] nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < nums.Length; index++)
            {
                int one = int.Parse(nums[index]);
                array[index] = Math.Max(
                    (index > 0 ? Math.Abs(one - int.Parse(nums[index - 1])) : 0),
                    (index < nums.Length - 1 ? Math.Abs(one - int.Parse(nums[index + 1])) : 0)
                    );
            }

            array = MergeSortRecursive(array, delegate (int left, int right) { return left < right; });

            Console.WriteLine(array[limit]);
        }
    }
}
