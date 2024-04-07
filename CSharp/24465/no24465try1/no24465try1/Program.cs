using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no24465try1
{
    internal class Program
    {
        static int Convert(string format)
        {
            string[] recvLine = format.Split(' ');
            return (int.Parse(recvLine[0]) - 1) * 31 + int.Parse(recvLine[1]);
        }

        static int[] termStart = new int[13] // 염소자리부터 시작
        {
            Convert("1 1"), // 염소자리 시작
            Convert("1 20"), // 물병자리 시작
            Convert("2 19"), // 물고기자리 시작
            Convert("3 21"), // 양자리 시작
            Convert("4 20"),
            Convert("5 21"),
            Convert("6 22"),
            Convert("7 23"),
            Convert("8 23"),
            Convert("9 23"),
            Convert("10 23"),
            Convert("11 23"),
            Convert("12 22")
        };

        static int ConvertToIndex(string format)
        {
            int day = Convert(format);

            for (int index = 12; index > 0; --index)
            {
                if (day >= termStart[index])
                {
                    return index % 12;
                }
            }
            return -1;
        }

        struct Day
        {
            public string original;
            public int day;
        }
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
            bool[] slot = new bool[12];
            for (int i = 0; i < 7; ++i)
            {
                slot[ConvertToIndex(Console.ReadLine())] = true;
            }

            
            
        }
    }
}
