using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18310try1
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
            int targetIndex = (int.Parse(Console.ReadLine()) - 1) >> 1;

            string[] str = Console.ReadLine().Split(' ');
            int[] positions = new int[str.Length];
            for (int index = 0; index < positions.Length; ++index)
            {
                positions[index] = int.Parse(str[index]);
            }

            positions = MergeSortAscendingRecursive(positions);

            Console.WriteLine(positions[targetIndex]);
        }
    }
}
