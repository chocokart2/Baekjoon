using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2568try1
{
    internal class Program
    {
        class TwoInt
        {
            public int x;
            public int y;
            public TwoInt lisPrevNum;
        }

        static T[] SortRecursive<T>(T[] array, Func<T, T, bool> isRightFirst)
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
            left = SortRecursive(left, isRightFirst);
            right = SortRecursive(right, isRightFirst);

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
            int size = int.Parse(Console.ReadLine());

            TwoInt[] nums = new TwoInt[size];
            HashSet<int> needRemove = new HashSet<int>();
            for (int index = 0; index < size; index++)
            {
                string[] one = Console.ReadLine().Split(' ');
                nums[index] = new TwoInt()
                {
                    x = int.Parse(one[0]),
                    y = int.Parse(one[1])
                };
                needRemove.Add(int.Parse(one[0]));
            }

            // 배열을 대상으로 머지 소트를 진행합니다. O(N * LogN / Log2)
            // x 값이 기준으로 정렬됩니다.
            nums = SortRecursive(nums, delegate (TwoInt left, TwoInt right) { return right.x < left.x; });

            // 배열의 y 값만 떼와서 LIS 알고리즘을 실행합니다. O(N * LogN / Log2)
            TwoInt[] lisSourseArray = new TwoInt[nums.Length + 1];
            for (int index = 0; index < nums.Length; index++)
            {
                lisSourseArray[index + 1] = nums[index];
            }
            TwoInt[] lisSizeToMinimumNums = new TwoInt[nums.Length + 1];
            lisSizeToMinimumNums[0] = new TwoInt() { x = 0, y = 0 };
            int sizeLis = 0; // size - sizeLis 가 답이 됩니다.
            
            for (int index = 1; index < lisSourseArray.Length; ++index)
            {
                int one = lisSourseArray[index].y;

                int binarySearchMin = 0;
                int binarySearchMax = sizeLis;
                while (true)
                {
                    int middleIndex = (binarySearchMax + binarySearchMin) / 2;

                    if (lisSizeToMinimumNums[middleIndex].y >= one)
                    {
                        binarySearchMax = middleIndex - 1;
                        continue;
                    }
                    if (middleIndex == sizeLis)
                    {
                        lisSourseArray[index].lisPrevNum = lisSizeToMinimumNums[middleIndex];
                        lisSizeToMinimumNums[middleIndex + 1] = lisSourseArray[index];
                        sizeLis++;
                        break;
                    }
                    if (lisSizeToMinimumNums[middleIndex + 1].y >= one)
                    {
                        lisSourseArray[index].lisPrevNum = lisSizeToMinimumNums[middleIndex];
                        lisSizeToMinimumNums[middleIndex + 1] = lisSourseArray[index];
                        break;
                    }
                    else
                    {
                        binarySearchMin = middleIndex + 1;
                        continue;
                    }
                }
            }

            // LIS 알고리즘을 통해 배열을 얻습니다.
            // 그중에 LIS 알고리즘의 배열의 원소를 제거합니다.

            TwoInt lineStay = lisSizeToMinimumNums[sizeLis];
            for (int i = 0; i < sizeLis; ++i)
            {
                needRemove.Remove(lineStay.x);
                lineStay = lineStay.lisPrevNum;
            }
            int[] needRemoveArray = SortRecursive(needRemove.ToArray(), delegate (int left, int right) { return right < left; });
            StringBuilder result = new StringBuilder();
            result.Append($"{size - sizeLis}\n");
            for (int index = 0; index < needRemoveArray.Length; ++index)
            {
                result.Append($"{needRemoveArray[index]}\n");
            }
            Console.Write(result);
        }
    }
}
