using System;

namespace no1920try1
{
    internal class Program
    {
        static int[] MergeSort(int[] target)
        {
            if (target.Length < 2) return target;

            int middleIndex = target.Length / 2;
            int[] result = new int[target.Length];
            int[] left = new int[middleIndex];
            int[] right = new int[target.Length - middleIndex];
            for (int index = 0; index < middleIndex; ++index) left[index] = target[index];
            for (int index = 0; index < target.Length - middleIndex; ++index) right[index] = target[index + middleIndex];
            left = MergeSort(left);
            right = MergeSort(right);
            int resultIndex = 0;
            int rightIndex = 0;
            int leftIndex = 0;

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
        static bool SearchBinary(int[] array, int target)
        {
            int startIndex = 0;
            int endIndex = array.Length - 1;
            int middleIndex;
            while (startIndex <= endIndex)
            {
                middleIndex = (startIndex + endIndex) >> 1;

                switch (target.CompareTo(array[middleIndex]))
                {
                    case -1:
                        endIndex = middleIndex - 1;
                        break;
                    case 1:
                        startIndex = middleIndex + 1;
                        break;
                    case 0:
                        return true;
                    default:
                        break;
                }
            }
            return false;
        }

        static void Main(string[] args)
        {
            int populationCount = int.Parse(Console.ReadLine());
            string[] recv = Console.ReadLine().Split(' ');
            int[] population = new int[populationCount];
            for (int index = 0; index < populationCount; ++index)
            {
                population[index] = int.Parse(recv[index]);
            }
            population = MergeSort(population);
            int targetCount = int.Parse(Console.ReadLine());
            recv = Console.ReadLine().Split(' ');

            System.Text.StringBuilder result = new System.Text.StringBuilder();

            for (int index = 0; index < targetCount; ++index)
            {
                if(SearchBinary(population, int.Parse(recv[index])))
                {
                    result.Append("1\n");
                }
                else
                {
                    result.Append("0\n");
                }
            }

            Console.Write(result);
        }
    }
}
