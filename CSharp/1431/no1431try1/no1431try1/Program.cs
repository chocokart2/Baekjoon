using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1431try1
{
    internal class Program
    {
        static bool IsRightFirst(string left, string right)
        {
            if (left.Length > right.Length) return true;
            if (left.Length < right.Length) return false;

            int leftSum = 0, rightSum = 0;
            for (int index = 0; index < left.Length; index++)
            {
                if ('0' < left[index] && left[index] <= '9')
                {
                    leftSum += left[index] - '0';
                }
                if ('0' < right[index] && right[index] <= '9')
                {
                    rightSum += right[index] - '0';
                }
            }
            if (leftSum > rightSum) return true;
            if (leftSum < rightSum) return false;

            for (int index = 0; index < left.Length; ++index)
            {
                if (left[index] > right[index]) return true;
                if (left[index] < right[index]) return false;
            }
            return false;
        }

        static string[] MergeSort(string[] array)
        {
            if (array.Length < 2) return array;

            int middleIndex = array.Length / 2;
            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;
            string[] result = new string[array.Length];
            string[] left = new string[middleIndex];
            string[] right = new string[array.Length - middleIndex];
            int index = 0;
            for (; index < middleIndex; ++index)
            {
                left[index] = array[index];
            }
            for (; index < array.Length; ++index)
            {
                right[index - middleIndex] = array[index];
            }
            left = MergeSort(left);
            right = MergeSort(right);

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (IsRightFirst(left[leftIndex], right[rightIndex]))
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
            string[] array = new string[int.Parse(Console.ReadLine())];
            for (int index = 0; index <  array.Length; ++index)
            {
                array[index] = Console.ReadLine();
            }
            array = MergeSort(array);
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < array.Length; ++index)
            {
                result.AppendLine(array[index]);
            }
            Console.Write(result);
        }
    }
}
