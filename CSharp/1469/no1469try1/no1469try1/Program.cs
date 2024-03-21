using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1469try1
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
            // 사이즈를 얻는다.
            // 숫자를 받고, 오름차순으로 숫자를 정렬한다.

            // 만약 여러 개일 경우 사전 순으로 가장 빠른 것을 출력한다 --> 백트래킹
            // 숫자가 가장 작은것부터 왼쪽에 배치합니다.
            // num[x]에 K를 배치했다면, num[x + 1 + k]에도 K를 배치해야 합니다.
            // 시간도 널널하네요.

            // 1. 배치에 성공함. => 다음 위치에 숫자를 놓음
            // 2. 이전 배치에 실패

            // 다음 자리에 숫자를 놓을 수 있음(다음 인덱스에 숫자가 있으면 그 옆 자리를 찾으면 됨.)
            // 숫자를 놓을 수 없음. => 숫자를 놓지 않고, 다음 숫자를 놓음
            // 숫자가 가득함 => 종료.

            int size = Console.ReadLine()[0] - '0';
            string[] recvLine = Console.ReadLine().Split(' ');
            int[] nums = new int[recvLine.Length];
            Heap<int> sorter = new Heap<int>(size, delegate (int left, int right) { return left - right; });
            for (int strIndex = 0; strIndex < size; ++strIndex)
            {
                sorter.Push(int.Parse(recvLine[strIndex]));
            }
            for (int strIndex = 0; strIndex < size; ++strIndex)
            {
                nums[strIndex] = sorter.Pop();
            }


            int[] slot = new int[size * 2];
            bool[] isFilledSlot = new bool[size * 2];
            bool[] isTailSlot = new bool[size * 2];
            // slot[3]에 6이 설정된다면, isTailSlot[3] = false이고,
            // isTailSlot[10]에 6이 설정되고, isTailSlot[10] = true로 설정된다.

            // 백트레킹용 변수
            bool successed = true;
            int lastNumIndex = -1; // 다음 숫자를 구하려면, 인덱스로 얻어야 할 것 같다.

            int slotIndex = 0;

            while (true)
            {
                if (slotIndex == slot.Length)
                {
                    for (int resultIndex = 0; resultIndex < slot.Length; ++resultIndex)
                    {
                        Console.Write($"{slot[slotIndex]} ");
                    }

                    return;
                }
                if (slotIndex == 0 && lastNumIndex == size)
                {
                    break;
                }
                // 만약 더이상 후퇴할 수 없는경우 -> -1 리턴


                successed = false;

                // 숫자 놓을 곳 찾기 (가장 첫번째로 빈칸인 곳)
                for (int placeIndex = 0; placeIndex < size * 2; placeIndex++)
                {

                }


            }

            Console.WriteLine(-1);
        }
    }
}
