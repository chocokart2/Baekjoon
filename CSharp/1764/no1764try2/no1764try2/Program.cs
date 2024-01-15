using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1764try2
{
    internal class Program
    {
        static string[] MergeSort(string[] target)
        {
            if (target.Length < 2) return target;

            string[] result = new string[target.Length];
            int middleIndex = target.Length >> 1;
            string[] left = new string[middleIndex];
            string[] right = new string[target.Length - middleIndex];
            for (int index = 0; index < middleIndex; ++index) left[index] = target[index];
            for (int index = 0; index < target.Length - middleIndex; ++index) right[index] = target[middleIndex + index];
            left = MergeSort(left);
            right = MergeSort(right);
            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (Compare(left[leftIndex], right[rightIndex]) == 1)
                {
                    result[resultIndex] = right[rightIndex];
                    ++rightIndex;
                    ++resultIndex;
                }
                else
                {
                    result[resultIndex] = left[leftIndex];
                    ++leftIndex;
                    ++resultIndex;
                }
            }
            while (leftIndex < left.Length)
            {
                result[resultIndex] = left[leftIndex];
                ++leftIndex;
                ++resultIndex;
            }
            while (rightIndex < right.Length)
            {
                result[resultIndex] = right[rightIndex];
                ++rightIndex;
                ++resultIndex;
            }

            return result;
        }

        static int Compare(string a, string b)
        {
            for (int i = 0; ; ++i)
            {
                if (a.Length == i && b.Length == i) return 0;
                if (a.Length == i) return -1;
                if (b.Length == i) return 1;

                if (a[i] > b[i]) return 1; 
                if (a[i] < b[i]) return -1;
            }
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            HashSet<string> names = new HashSet<string>();
            string[] doubleCalledName = new string[500_000];
            int size = 0;

            string[] nums = Console.ReadLine().Split(' ');
            int n = int.Parse(nums[0]);
            int m = int.Parse(nums[0]);
            for (int i = 0; i < n; ++i)
                names.Add(Console.ReadLine());
            for (int i = 0; i < m; ++i)
            {
                string oneName = Console.ReadLine();
                if (names.Contains(oneName))
                {
                    doubleCalledName[size] = oneName;
                    ++size;
                }
            }

            // 이제 doubleCalledName를 사전순으로 정렬하는 함수를 만들면 된다.
            string[] copyOfDoubleCalledName = new string[size];
            for (int index = 0; index < size; ++index) copyOfDoubleCalledName[index] = doubleCalledName[index];
            copyOfDoubleCalledName = MergeSort(copyOfDoubleCalledName);
            for (int index = 0; index < size; ++index) result.Append($"{copyOfDoubleCalledName[index]}\n");
            Console.WriteLine(size);
            Console.WriteLine(result);
        }
    }
}
