using System;
namespace _6159try1
{
    internal class Program
    {
        static int[] MergeSort(int[] target)
        {
            if (target.Length < 2) return target;

            int middleIndex = target.Length >> 1;
            int[] result = new int[target.Length];
            int[] left = new int[middleIndex];
            int[] right = new int[target.Length - middleIndex];
            for (int index = 0; index < middleIndex; ++index) left[index] = target[index];
            for (int index = 0; index < target.Length - middleIndex; ++index) right[index] = target[index + middleIndex];
            int indexResult = 0;
            int indexLeft = 0;
            int indexRight = 0;
            left = MergeSort(left);
            right = MergeSort(right);

            while (indexLeft < left.Length && indexRight < right.Length)
            {
                if (right[indexRight] < left[indexLeft])
                {
                    result[indexResult] = right[indexRight];
                    ++indexResult;
                    ++indexRight;
                }
                else
                {
                    result[indexResult] = left[indexLeft];
                    ++indexResult;
                    ++indexLeft;
                }
            }
            while (indexRight < right.Length)
            {
                result[indexResult] = right[indexRight];
                ++indexResult;
                ++indexRight;
            }
            while (indexLeft < left.Length)
            {
                result[indexResult] = left[indexLeft];
                ++indexResult;
                ++indexLeft;
            }
            return result;
        }

        static void Main(string[] args)
        {
            int result = 0;

            string[] recvNum = Console.ReadLine().Split(' ');
            int[] cows = new int[int.Parse(recvNum[0])];
            int size = int.Parse(recvNum[1]);
            for (int index = 0; index < cows.Length; ++index)
            {
                cows[index] = int.Parse(Console.ReadLine());
            }

            cows = MergeSort(cows);

            for (int indexCowFirst = 0; indexCowFirst < cows.Length - 1; ++indexCowFirst)
            {
                for (int indexCowSecond = indexCowFirst + 1; indexCowSecond < cows.Length; ++indexCowSecond)
                {
                    if (cows[indexCowFirst] + cows[indexCowSecond] > size) break;
                    ++result;
                }
            }

            Console.WriteLine(result);
        }
    }
}
