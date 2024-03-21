using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace no2628try1
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
        static Func<int, int, int> myFunc = delegate (int left, int right) { return left - right; };

        static void Main(string[] args)
        {
            string[] sizeStr = Console.ReadLine().Split(' ');
            int sizeX = int.Parse(sizeStr[0]);
            int sizeY = int.Parse(sizeStr[1]);
            int inputCount = int.Parse(Console.ReadLine());
            Heap<int> vertical = new Heap<int>(sizeX, delegate (int left, int right) { return left - right; } );
            vertical.Push(sizeX);
            Heap<int> horizontal = new Heap<int>(sizeY, delegate (int left, int right) { return left - right; });
            horizontal.Push(sizeY);
            for (int i = 0; i < inputCount; ++i)
            {
                string oneLine = Console.ReadLine();
                if (oneLine[0] == '1')
                {
                    vertical.Push(int.Parse(oneLine.Split(' ')[1]));
                }
                else
                {
                    horizontal.Push(int.Parse(oneLine.Split(' ')[1]));
                }
            }

            int termX = 0;
            int termY = 0;
            int prevX = 0;
            int prevY = 0;
            while (vertical.Count > 0)
            {
                int one = vertical.Pop();
                termX = Math.Max(termX, one - prevX);
                prevX = one;

            }
            while (horizontal.Count > 0)
            {
                int one = horizontal.Pop();
                termY = Math.Max(termY, one - prevY);
                prevY = one;
            }
            Console.WriteLine(termX * termY);
        
        }
    }
}
