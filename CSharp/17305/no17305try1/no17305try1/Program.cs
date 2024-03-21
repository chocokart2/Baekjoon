using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace no17305try1
{
    internal class Program
    {
        class Heap<T>
        {
            // 숫자 : 작은 값일수록 우선순위가 높습니다.
            private Comparison<T> IsLeftPrecedence; // 왼쪽이 우선이면 함수의 리턴값은 양수가 아님.
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
            public int Count => count;

            protected void M_Swap(int leftIndex, int rightIndex)
            {
                T temp = data[leftIndex];
                data[leftIndex] = data[rightIndex];
                data[rightIndex] = temp;
            }

            protected void M_Heapify(int targetIndex)
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
            protected int M_FindMotherIndex(int targetIndex) => (targetIndex < 2) ? NOT_FOUND : targetIndex >> 1;
            protected int M_FindDaughterIndex(int targetIndex)
            {
                int result = NOT_FOUND;
                if ((targetIndex << 1) > count) return result;
                result = (targetIndex << 1);
                if (result + 1 > count) return result;
                if (M_IsLeftPriority(data[result], data[result + 1])) return result;
                return result + 1;
            }
            protected bool M_IsLeftPriority(T left, T right)
                => IsLeftPrecedence(left, right) <= 0;
        }

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int count = int.Parse(nums[0]);
            int limit = int.Parse(nums[1]);

            Comparison<long> function = delegate (long left, long right)
            {
                long a = -left + right;
                if (a > 0) return 1;
                if (a < 0) return -1;
                return 0;
            };

            Heap<long> threeWeight = new Heap<long>(count, function);
            Heap<long> fiveWeight = new Heap<long>(count, function);

            for (int candy = 0; candy < count; ++candy)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                (recvLine[0][0] == '3' ? threeWeight : fiveWeight).Push(int.Parse(recvLine[1]));
                
            }
            long[] lightWeightCandySums = new long[threeWeight.Count + 1];
            long[] heavyWeightCandySums = new long[fiveWeight.Count + 1];

            for (int index = 1; index < lightWeightCandySums.Length; ++index)
            {
                lightWeightCandySums[index] = lightWeightCandySums[index - 1] + threeWeight.Pop();
            }
            for (int index = 1; index < heavyWeightCandySums.Length; ++index)
            {
                heavyWeightCandySums[index] = heavyWeightCandySums[index - 1] + fiveWeight.Pop();
            }
            long maxSweet = 0;
            for (int fiveCandyCount = 0; fiveCandyCount < heavyWeightCandySums.Length && fiveCandyCount * 5 <= limit; fiveCandyCount++)
            {
                int threeCandyCount = (limit - fiveCandyCount * 5) / 3;
                long one = heavyWeightCandySums[fiveCandyCount] + lightWeightCandySums[(threeCandyCount > lightWeightCandySums.Length - 1) ? lightWeightCandySums.Length - 1 : threeCandyCount];
                Console.WriteLine($">> 3 : {threeCandyCount}, 5 : {fiveCandyCount} one = {one}");

                if (maxSweet < one) maxSweet = one;
            }
            Console.WriteLine(maxSweet);

        }
    }
}
