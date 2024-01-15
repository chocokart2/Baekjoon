using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2236try1
{
    internal class Program
    {
        class Component
        {
            public int value;
            public int index;
            public bool isConnected;
        }

        static Component[] MergeSort(Component[] target)
        {
            if (target.Length < 2) return target;

            int middleIndex = target.Length / 2;
            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;
            Component[] result = new Component[target.Length];
            Component[] left = new Component[middleIndex];
            Component[] right = new Component[target.Length - middleIndex];
            int index = 0;
            for (; index < middleIndex; ++index)
            {
                left[index] = target[index];
            }
            for (; index < target.Length; ++index)
            {
                right[index - middleIndex] = target[index];
            }
            left = MergeSort(left);
            right = MergeSort(right);

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex].value < right[rightIndex].value)
                {
                    result[resultIndex++] = right[rightIndex++];
                }
                else
                {
                    result[resultIndex++] = left[leftIndex++];
                }
            }
            while(leftIndex < left.Length)
            {
                result[resultIndex++] = left[leftIndex++];
            }
            while(rightIndex < right.Length)
            {
                result[resultIndex++] = right[rightIndex++];
            }

            return result;
        }

        static void Main(string[] args)
        {
            List<int> connectedID = new List<int>(); // 전원에 연결될 부품의 목록입니다.
            int capacity = int.Parse(Console.ReadLine().Split(' ')[1]);

            string[] nums = Console.ReadLine().Split(' ');
            Component[] array = new Component[nums.Length];

            for (int index = 0; index < nums.Length; ++index)
            {
                array[index] = new Component()
                {
                    value = int.Parse(nums[index]),
                    index = index,
                    isConnected = false
                };
            }
            array = MergeSort(array);

            StringBuilder result = new StringBuilder();
            int lineNum = 0;
            for (; lineNum < array.Length && lineNum < capacity; ++lineNum)
            {
                result.AppendLine($"{array[lineNum].index + 1}");
                array[lineNum].isConnected = true;
            }
            for (; lineNum < capacity; ++lineNum)
            {
                result.AppendLine("0");
            }

            Component[] array2 = new Component[array.Length];
            for (int index = 0; index < array.Length; ++index)
            {
                array2[array[index].index] = array[index];
            }

            for (int index = 0; index < array2.Length; ++index)
            {
                result.AppendLine(array2[index].isConnected ? $"{array2[index].index + 1}" : "0");
            }
            Console.Write(result);
        }
    }
}
