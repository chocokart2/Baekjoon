using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noCtry1
{
    internal class Program
    {
        const bool IS_DEBUGGING = false;
        class Vector2
        {
            public long position;
            public long value;

            public Vector2(long position, long value)
            {
                this.position = position;
                this.value = value;
            }
        }
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

        static long GetMin(Vector2[] data, bool isLeftStart)
        {
            long endPos = (isLeftStart) ? data[data.Length - 1].position : data[0].position;
            long endPrime = (isLeftStart) ? data[data.Length - 2].position : data[1].position; // 
            if (IS_DEBUGGING)
            {
                Console.WriteLine($">> endPos = {endPos}");
            }
            long sum = 0;
            long[] element = new long[data.Length];
            for (int index = 0; index < data.Length; index++)
            {
                element[index] = data[index].value + Math.Abs(endPos - data[index].position);
                sum += element[index];
            }
            long min = 0;
            for (int index = (isLeftStart) ? 0 : data.Length - 1; (isLeftStart) ? (index < data.Length - 1) : (index > 0);)
            {
                min += data[index].value + Math.Abs(data[index].position - endPrime);

                if (isLeftStart)
                {
                    index++;
                }
                else
                {
                    index--;
                }
            }

            for (long index = 0; index < element.Length; ++index)
            {
                long one = sum - element[index];

                if (IS_DEBUGGING)
                {
                    Console.WriteLine();
                }
                min = Math.Min(min, one);
            }
            return min;
        }

        static void Main(string[] args)
        {
            // 정보를 받고, 위치 순으로 정렬한다.
            // 가장 가장자리의 제독 물질을 제외한다. 
            // ㄴ 오른쪽과 왼쪽 가장자리를 각각 제거했을때의 상황을 가진다.
            // ㄴ 오른쪽에서 먼저 출발했을때와 왼쪽에서 먼저 출발했을때의 상황을 체크한다.
            // 각 4가지의 결과값을 얻는다.
            // 1. 일단 각각의 코스트를 구한다 1. 그 자체의 코스트 / 2. 거리가 주는 코스트

            int count = int.Parse(Console.ReadLine());
            Heap<Vector2> sorter = new Heap<Vector2>(count, delegate (Vector2 left, Vector2 right) { return (left.position - right.position < 0 ? -1 : 1); });
            for (long i = 0; i < count; ++i)
            {
                string[] one = Console.ReadLine().Split(' ');
                sorter.Push(new Vector2(long.Parse(one[0]), long.Parse(one[1])));
            }
            Vector2[] situation = new Vector2[count];
            for (int index = 0; index < count; ++index)
            {
                situation[index] = sorter.Pop();
                if (IS_DEBUGGING)
                {
                    Console.WriteLine($">> {index} = {situation[index].position}");
                }
            }

            Console.WriteLine(Math.Min(GetMin(situation, false), GetMin(situation, true)));
        }
    }
}
