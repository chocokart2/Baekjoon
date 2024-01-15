using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no18870try1
{
    internal class Program
    {
        static int BinarySearch(int[] sourceNumbers, int size, int target)
        {
            int result = -1;

            int firstIndex = 0;
            int lastIndex = size - 1;
            
            while (firstIndex <= lastIndex)
            {
                int middleIndex = (firstIndex + lastIndex) >> 1;
                if (sourceNumbers[middleIndex] == target) return middleIndex;
                else if (sourceNumbers[middleIndex] > target)
                {
                    lastIndex = middleIndex - 1;
                }
                else
                {
                    firstIndex = middleIndex + 1;
                }
            }

            return result;
        }
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
            // 배열에 값 넣기. 중복되는 값은 넣지 않음 / 배열내 내용은 정렬된 상태로 유지
            // 숫자를 보고 인덱스를 리턴하는 이분 탐색 함수 구현 log()

            // 일단 숫자로 된 원본 배열 넣기.
            // 그 다음 합병 정렬 진행
            // 그 다음 전부 탐색하여 동일한 숫자를 제외한 숫자의 개수 세기
            // 그 다음 중복되는 숫자를 제외하고 하나씩 숫자 넣기
            StringBuilder result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());
            string[] numbers = Console.ReadLine().Split(' ');
            int[] parsed = new int[numbers.Length];
            int[] pressedNumbers = new int[numbers.Length];
            for (int index = 0; index < numbers.Length; ++index)
            {
                parsed[index] = int.Parse(numbers[index]);
            }

            //foreach (int one in parsed) Console.WriteLine($"debug : {one}");

            parsed = MergeSort(parsed);

            int numCount = 0;
            int maxNum = int.MinValue;
            for (int index = 0; index < parsed.Length; ++index)
            {
                if (parsed[index] > maxNum)
                {
                    maxNum = parsed[index];
                    pressedNumbers[numCount] = maxNum;
                    ++numCount;
                }
            }

            //foreach (int one in parsed) Console.WriteLine($"debug : {one}");
            //foreach (int one in pressedNumbers) Console.WriteLine($"debug : {one}");

            result.Append(BinarySearch(pressedNumbers, numCount, int.Parse(numbers[0])));
            for (int index = 1; index < parsed.Length; ++index)
            {
                result.Append($" {BinarySearch(pressedNumbers, numCount, int.Parse(numbers[index]))}");
            }

            Console.WriteLine(result);
        }
    }
}
