using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace no23740try1
{
    internal class Program
    {
        class Line
        {
            public int start;
            public int end;
            public int cost;
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

        static int CompareLine(Line left, Line right)
        {
            // 1. 가장 출발점이 가까운 녀석이 우선
            // 2. 가장 도착점이 먼 녀석이 우선
            if (left.start != right.start)
            {
                return (left.start < right.start) ? -1 : 1;
            }
            return (right.end > left.end) ? 1 : -1;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Heap<Line> sorter = new Heap<Line>(count, CompareLine);
            Line[] array = new Line[count];
            int current = 0;
            for (int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                sorter.Push(
                    new Line()
                    {
                        start = int.Parse(recvLine[0]),
                        end = int.Parse(recvLine[1]),
                        cost = int.Parse(recvLine[2])
                    });
            }

            array[0] = sorter.Pop();

            for (int i = 1; i < count; ++i)
            {
                Line one = sorter.Pop();
                //Console.WriteLine($">> one [{one.start} ~ {one.end}], ${one.cost}");


                // 새로 집어넣기
                if (array[current].end < one.start)
                {
                    //Console.WriteLine(">> 새로 집어넣기");
                    current++;
                    array[current] = one;
                    continue;
                }

                if (array[current].end < one.end) array[current].end = one.end;
                if (array[current].cost > one.cost) array[current].cost = one.cost;
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine($"{current + 1}");
            for (int index = 0; index <= current; ++index)
            {
                Line one = array[index];
                result.AppendLine($"{one.start} {one.end} {one.cost}");
            }
            Console.Write(result);
        }
    }
}
