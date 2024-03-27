using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no14567try1
{
    internal class Program
    {
        interface IDistinguishable<TKey>
        {
            // This member is responsible for identifying objects.
            TKey Key { get; }
        }

        class Heap<TObject, TKey> where TObject : IDistinguishable<TKey>
        {
            // 숫자 : 작은 값일수록 우선순위가 높습니다.
            private Comparison<TObject> IsLeftPrecedence; // 왼쪽이 우선이면 함수의 리턴값은 양수가 아님.
            private TObject[] data;
            private int count;
            private Dictionary<TKey, int> keyToIndex; // 키 값을 넣으면 인덱스 값을 리턴합니다.

            const int NOT_FOUND = -1;

            /// <summary>
            ///     배열 기반 Heap을 초기화합니다.
            /// </summary>
            /// <param name="size"></param>
            /// <param name="function">
            ///     (왼쪽 변수의 우선순위 - 오른쪽 변수의 우선순위)이며, 우선순위 값이 낮을수록 힙에 먼저 빠져나갑니다
            /// </param>
            public Heap(int size, Comparison<TObject> function)
            {
                data = new TObject[size + 1];
                count = 0;
                IsLeftPrecedence = function;
            }
            public void Push(TObject item)
            {
                ++count;
                data[count] = item;
                M_Heapify(count);
            }
            public TObject Peek()
            {
                if (count < 1) return default;
                return data[1];
            }
            public TObject Pop()
            {
                if (count < 1) return default;
                TObject result = data[1];
                data[1] = data[count];
                count--;
                M_Heapify(1);
                return result;
            }
            public void Refresh()
            {
                Heap<TObject, TKey> result = new Heap<TObject, TKey>(data.Length, IsLeftPrecedence);
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
                TObject temp = data[leftIndex];
                data[leftIndex] = data[rightIndex];
                data[rightIndex] = temp;

                keyToIndex[data[leftIndex].Key] = leftIndex;
                keyToIndex[data[rightIndex].Key] = rightIndex;
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
            protected bool M_IsLeftPriority(TObject left, TObject right)
                => IsLeftPrecedence(left, right) <= 0;
        }
        class Node : IDistinguishable<int>
        {
            public List<Node> next;
            public HashSet<Node> prev;
            public HashSet<int> nextSet;

            public int Key { get; private set; }

            public Node(int key)
            {
                Key = key;
            }
        }

        static void Main(string[] args)
        {
            string[] recvLineNM = Console.ReadLine().Split(' ');
            int classCount = int.Parse(recvLineNM[0]);
            int edgeCount = int.Parse(recvLineNM[1]);
            Node[] classList = new Node[classCount];
            for (int index = 0; index < classCount; ++index)
            {
                classList[index] = new Node(index + 1);
            }
            for (int i = 0; i < edgeCount; ++i)
            {
                string[] recvLineStartEnd = Console.ReadLine().Split(' ');
                int start = int.Parse(recvLineStartEnd[0]);
                int end = int.Parse(recvLineStartEnd[1]);

                classList[start].next.Add(classList[end]);
                classList[start].nextSet.Add(classList[end].Key);

                classList[end].prev.Add(classList[start]);
            }

            // 위상 정렬 진행
            Queue<Node> one
            for (int answer = 1; true; answer++)
            {



            }
        }
    }
}
