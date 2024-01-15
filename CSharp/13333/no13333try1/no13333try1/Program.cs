using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace no13333try1
{
    internal class Program
    {
        class Heap<T>
        {
            // 숫자 : 작은 값일수록 우선순위가 높습니다.
            private Comparison<T> IsLeftPrecedence; // 왼쪽이 우선이면 음수가 아님.
            private T[] data;
            private int count;

            const int NOT_FOUND = -1;

            /// <summary>
            ///     배열 기반 Heap을 초기화합니다.
            /// </summary>
            /// <param name="size"></param>
            /// <param name="function">
            ///     (왼쪽 변수의 우선순위 - 오른쪽 변수의 우선순위)이며, 우선순위 값이 낮을수록 힙에 먼저 빠져나갑니다
            /// </param>
            public Heap(int size, Comparison<T> function)
            {
                data = new T[size + 1];
                count = 0;
                IsLeftPrecedence = function;
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
            public void Refresh()
            {
                Heap<T> result = new Heap<T>(data.Length, IsLeftPrecedence);
                while (count > 0)
                {
                    result.Push(Pop());
                }
                count = result.count;
                data = result.data;
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
                => IsLeftPrecedence(left, right) <= 0;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string[] nums = Console.ReadLine().Split(' ');
            int[] quotes = new int[count];
            Heap<int> sorter = new Heap<int>(count, delegate (int left, int right) { return left - right; });

            for (int i = 0; i < count; ++i)
            {
                sorter.Push(int.Parse(nums[i]));
            }
            for (int i = 0; i < count; ++i)
            {
                quotes[i] = sorter.Pop();
            }
            
            for (int k = 0; ; ++k)
            {

                int high = 0;
                int down = 0;
                for (int index = 0; index < quotes.Length; ++index)
                {
                    if (quotes[index] > k) high++;
                    if (quotes[index] <= k) down++;
                }
                Console.WriteLine($">> DEBUG : k = {k}, n - k = {count - k}, high = {high}, down = {down}");

                if (down == (count - k) &&
                    high >= k)
                {
                    Console.WriteLine(k);
                    return;
                }
            }
        }
    }
}
