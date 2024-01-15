using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noGtry1
{
    internal class Program
    {
        class Heap<T>
        {
            // 높은 값일수록 우선순위가 높습니다.

            private Comparison<T> IsLeftGreatherThenRight;
            private T[] data;
            private int count;

            const int NOT_FOUND = -1;

            public Heap(int size, Comparison<T> function)
            {
                data = new T[size + 1];
                count = 0;
                IsLeftGreatherThenRight = function;
            }
            public void Push(T item)
            {
                ++count;
                data[count] = item;
                M_Heapify(count);
            }
            public T Peek()
            {
                if (count < 1) return default;
                return data[count];
            }
            public T Pop()
            {
                if (count < 1) return default;
                T result = data[1];
                data[1] = data[count];
                count--;
                M_Heapify(1);
                return result;
            }

            private void M_Swap(int leftIndex, int rightIndex)
            {
                T temp = data[leftIndex];
                data[leftIndex] = data[rightIndex];
                data[rightIndex] = temp;
            }

            private void M_Heapify(int targetIndex)
            {
                for (int currentIndex = targetIndex, daughterIndex = M_FindDaughterIndex(targetIndex);
                    daughterIndex != NOT_FOUND;
                    currentIndex = daughterIndex, daughterIndex = M_FindDaughterIndex(daughterIndex))
                {
                    if (M_IsLeftPriority(data[currentIndex], data[daughterIndex])) break; // 정상화가 된 상태입니다.
                    M_Swap(currentIndex, daughterIndex);
                }
                for (int currentIndex = targetIndex, motherIndex = M_FindMotherIndex(targetIndex);
                    motherIndex != NOT_FOUND;
                    currentIndex = motherIndex, motherIndex = M_FindMotherIndex(motherIndex))
                {
                    if (M_IsLeftPriority(data[motherIndex], data[currentIndex])) break; // 정상화가 된 상태입니다.
                    M_Swap(motherIndex, currentIndex);
                }
            }
            private int M_FindMotherIndex(int targetIndex) => (targetIndex < 2) ? NOT_FOUND : targetIndex >> 1;
            private int M_FindDaughterIndex(int targetIndex)
            {
                int result = NOT_FOUND;
                if ((targetIndex << 1) > count) return result;
                result = (targetIndex << 1);
                if (result + 1 > count) return result;
                if (M_IsLeftPriority(data[result], data[result + 1])) return result;
                return result + 1;
            }
            private bool M_IsLeftPriority(T left, T right)
                => IsLeftGreatherThenRight(left, right) <= 0;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            string[] pCountString = Console.ReadLine().Split(' ');
            int[] pCount = new int[5];
            for (int index = 0; index < 5; ++index) pCount[index] = int.Parse(pCountString[index]);

            Comparison<int> comparior = delegate (int a, int b) { return a - b; };
            Heap<int>[] problems = new Heap<int>[5];
            for (int i = 0; i < 5; ++i) problems[i] = new Heap<int>(count, comparior);

            for (int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                problems[int.Parse(recvLine[0]) - 1].Push(int.Parse(recvLine[1]));
            }

            int result = -60;
            int prevTime = 0;
            for (int level = 0; level < 5; ++level)
            {
                for (int solveCount = 0; solveCount < pCount[level]; ++solveCount)
                {
                    int one = problems[level].Pop();

                    if (solveCount == 0) result += 60;
                    else result += one - prevTime;

                    result += one;
                    //Console.WriteLine($">> one = {one}, result = {result}");
                    prevTime = one;
                }
            }

            Console.WriteLine(result);
        }
    }
}
