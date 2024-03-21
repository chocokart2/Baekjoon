using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no27923try1
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
        class Vector2
        {
            public int index;
            public int colaStack;
        }
        static void Main(string[] args)
        {
            Heap<int> sorter = new Heap<int>(200_001, delegate (int left, int right) { return -left + right; });
            Heap<Vector2> sorterVec = new Heap<Vector2>(200_001, delegate (Vector2 left, Vector2 right) { return -left.colaStack + right.colaStack; });

            // 콜라가 몇번 중첩되는지를 나타내는 수
            string[] recvLine = Console.ReadLine().Split(' ');
            int burgerCount = int.Parse(recvLine[0]);
            int colaCount = int.Parse(recvLine[1]);
            int colaDuring = int.Parse(recvLine[2]);
            // 콜라 지속시간을 배열로 나타냃수 있나?
            // 200_000 ^ 2는 시간오버일 것 같다.
            // 
            // 그렇다면 콜라 지속시간은 L이니까 stack[현재] - stack[현재 - L]을 하여서 얼마나 많은 콜라가 있는지를 체크하면 되겠네!
            int[] colaStack = new int[200_001]; // 시작 인덱스는 1부터
            string[] burgerListString = Console.ReadLine().Split(' ');
            string[] colaList = Console.ReadLine().Split(' ');
            int[] sortedBurger = new int[burgerCount];
            Vector2[] sortedIndex = new Vector2[burgerCount]; // i번째 인덱스는 i번째로 많이 콜라가 겹쳐진 상황의 인덱스입니다.
            // 가장 많이 중첩된 시간에 가장 큰 햄버거를 먹이기.
            
            for (int index = 0; index < colaCount; ++index)
            {
                colaStack[int.Parse(colaList[index])]++;
            }
            for (int index = 0; index < burgerCount; ++index)
            {
                sorter.Push(int.Parse(burgerListString[index]));
            }
            for (int index = 0; index < burgerCount; ++index)
            {
                sortedBurger[index] = sorter.Pop();
            }
            
            // 가장 많이 쌓인 시점부터, 가장 적게 쌓인 시점으로 정렬하기
            // 그리고 해당 정렬대로 가장 큰 햄버거를 배치하기
        }
    }
}
