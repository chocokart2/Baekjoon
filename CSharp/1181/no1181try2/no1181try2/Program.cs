using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1181try2
{
    internal class Program
    {
        static int Compare(string left, string right)
        {
            if (left.Length < right.Length) return 1;
            else if (left.Length > right.Length) return -1;
            else
            {
                for (int index = 0; index < left.Length; ++index)
                {
                    if (left[index] < right[index]) return 1;
                    else if (left[index] > right[index]) return -1;
                }
                return 0;
            }
        }

        static string[] MergeSort(string[] target)
        {
            if (target.Length < 2) return target;

            string[] result = new string[target.Length];
            int middleIndex = target.Length / 2;
            string[] left = new string[middleIndex];
            string[] right = new string[target.Length - middleIndex];
            for (int index = 0; index < middleIndex; ++index) left[index] = target[index];
            for (int index = 0; index < target.Length - middleIndex; ++index) right[index] = target[index + middleIndex];
            left = MergeSort(left);
            right = MergeSort(right);

            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while(leftIndex < left.Length && rightIndex < right.Length)
            {
                switch (Compare(left[leftIndex], right[rightIndex]))
                {
                    case -1:
                        result[resultIndex] = right[rightIndex];
                        ++resultIndex;
                        ++rightIndex;
                        break;
                    case 1:
                    case 0:
                        result[resultIndex] = left[leftIndex];
                        ++resultIndex;
                        ++leftIndex;
                        break;
                    default:
                        break;
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

        static string[] Press(string[] target, int length)
        {
            string[] result = new string[length];
            for (int index = 0; index < length; ++index)
                result[index] = target[index];
            return result;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string[] words = new string[count];
            int wordLength = 0;
            for (int i = 0; i < count; ++i)
            {
                string receiveWord = Console.ReadLine();
                bool isExistWord = false;
                for (int searchIndex = 0; searchIndex < wordLength; ++searchIndex)
                {
                    if (words[searchIndex].Equals(receiveWord))
                        isExistWord = true;
                }
                if (isExistWord == false)
                {
                    words[wordLength] = receiveWord;
                    ++wordLength;
                }
            }

            words = MergeSort(Press(words, wordLength));

            StringBuilder result = new StringBuilder();
            for (int index = 0; index < words.Length; ++index)
                result.Append($"{words[index]}\n");
            Console.Write(result);
        }
    }
}
