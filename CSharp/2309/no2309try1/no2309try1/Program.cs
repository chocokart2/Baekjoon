using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2309try1
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
            int[] peopleHeight = new int[9];
            int sum = 0;
            for (int index = 0; index < peopleHeight.Length; index++)
            {
                int one = int.Parse(Console.ReadLine());

                sum += one;
                peopleHeight[index] = one;
            }
            
            // 브루트 포스를 실행
            for (int indexA = 0; indexA < peopleHeight.Length - 1; ++indexA)
            {
                for (int indexB = indexA + 1; indexB < peopleHeight.Length; ++indexB)
                {
                    if (sum - peopleHeight[indexA] - peopleHeight[indexB] == 100)
                    {
                        peopleHeight[indexA] = 0;
                        peopleHeight[indexB] = 0;

                        peopleHeight = MergeSortAscendingRecursive(peopleHeight);
                        for (int index = 2; index < 9; ++index)
                        {
                            Console.WriteLine(peopleHeight[index]);
                        }
                        return;
                    }
                }
            }
        }
    }
}
