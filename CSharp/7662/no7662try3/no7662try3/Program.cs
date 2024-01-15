using System;
using System.Text;

namespace no7662try3
{
    internal class Program
    {
        const int MAX_HEAP = 0;
        const int MIN_HEAP = 1;
        const bool DEBUG = true;
        const bool RELEASE = false;
        const bool STATUS = RELEASE;

        // 최소 힙과 최대 힙을 활용하고 원소에는 각 힙의 인덱스 번호를 가지고 있도록 하자.
        class HeapElement
        {
            public int data;
            public int[] heapIndex;

            public override string ToString()
            {
                return $"{{data : {data}, index : [{heapIndex[0]}, {heapIndex[1]}] }}";
            }
        }

        static StringBuilder result;
        static HeapElement[,] heap;
        static int heapSize;

        static void Init()
        {
            heap = new HeapElement[2, 1_000_001];
            heapSize = 0;
        }
        static void PrintHeap()
        {

            Console.Write("Max heap : ");

            for (int index = 1, x = 1; index <= heapSize; ++index)
            {
                if (x < index + 1)
                {
                    Console.WriteLine();
                    x <<= 1;
                }
                Console.Write($"{heap[MAX_HEAP, index]} ");
            }
            Console.WriteLine();
            Console.Write("Min heap : ");

            for (int index = 1, x = 1; index <= heapSize; ++index)
            {
                if (x < index + 1)
                {
                    Console.WriteLine();
                    x <<= 1;
                }
                Console.Write($"{heap[MIN_HEAP, index]} ");
            }
            Console.WriteLine();
        }
        // Swap은 잘못 없어.
        static void Swap(int targetHeap, int leftIndex, int rightIndex)
        {
            HeapElement temp = heap[targetHeap, leftIndex];
            heap[targetHeap, leftIndex] = heap[targetHeap, rightIndex];
            heap[targetHeap, rightIndex] = temp;
            heap[targetHeap, leftIndex].heapIndex[targetHeap] = leftIndex;
            heap[targetHeap, rightIndex].heapIndex[targetHeap] = rightIndex;
        }
        // very suspicious!
        static void Pop(int targetHeap)
        {
            if (STATUS)
            {
                Console.WriteLine($"Pop({targetHeap}) : 호출됨");
            }

            // 해당 힙의 머리 원소 제거
            // 그다음 옆의 힙의 해당 위치의 원소 제거
            // 각 heap Heapify 진행 -> 빈곳에 가장 마지막의 원소 넣기(가장 00에서 반대이므로) -> 새로 채워진 그 원소가 자식 원소와 교체할 수 있는가 여부 판단

            if (heapSize < 1)
            {
                return;
            }

            if (STATUS)
            {
                Console.WriteLine($"Pop({targetHeap}) : heapify 이전 힙의 상황");
                PrintHeap();
                Console.WriteLine($"Pop({targetHeap}) : heapify 진행");
                Console.WriteLine($"Pop({targetHeap}) : 힙에서 제거될 원소 : {heap[targetHeap, 1]}");
                Console.WriteLine($"Pop({targetHeap}) : 최대 힙에서 빈칸을 대체할 원소 : {heap[MAX_HEAP, heapSize]}");
                Console.WriteLine($"Pop({targetHeap}) : 최소 힙에서 빈칸을 대체할 원소 : {heap[MIN_HEAP, heapSize]}");
            }

            
            HeapElement temp = heap[targetHeap, 1];
            int minHeapIndex = temp.heapIndex[MIN_HEAP];
            int maxHeapIndex = temp.heapIndex[MAX_HEAP];
            --heapSize;


            // 빈칸을 채우는 경우 heapify를 두번 해야 함. 빈칸에서 자식까지, 혹은 빈칸에서 부모까지

            // min heap heapify
            Swap(MIN_HEAP, minHeapIndex, heapSize + 1);
            
            // heapify : 빈칸에서 자식의 말단까지 heapify
            for (int index = minHeapIndex; (index << 1) <= heapSize;)
            {
                int compareChildIndex = (index << 1);
                if (compareChildIndex + 1 <= heapSize)
                {
                    if (heap[MIN_HEAP, compareChildIndex].data > heap[MIN_HEAP, compareChildIndex + 1].data)
                    {
                        ++compareChildIndex;
                    }
                }

                if (heap[MIN_HEAP, index].data > heap[MIN_HEAP, compareChildIndex].data)
                {
                    Swap(MIN_HEAP, index, compareChildIndex);
                    index = compareChildIndex;
                }
                else break;
            }
            // heapify : 빈칸에서 부모 노드의 끝까지 heapify
            // push의 heapify와 동일합니다.
            for (int index = minHeapIndex; (index >> 1) > 0; index >>= 1)
            {
                if (heap[MIN_HEAP, index].data >= heap[MIN_HEAP, index >> 1].data) break;

                Swap(MIN_HEAP, index, index >> 1);
            }

            // 최대 힙 상황 : 큰 수 -> 빈칸 -> 작은 수
            // max heap heapify
            Swap(MAX_HEAP, maxHeapIndex, heapSize + 1);

            // heapify : 두가지의 문제 상황중 하나가 발생하게 됨 : 큰 수인 빈칸의 부모 - 빈 칸 - 작은 수인 빈칸의 자식일때
            // 빈칸의 부모보다 큰 숫자인 빈칸이거나, 빈칸의 자식보다 작은 숫자인 빈칸인 경우 중 하나 문제 상황을 해결해야 한다.
            // heapify : 빈칸 -> 작은수 관계에서 빈칸이 자식의 작은 수보다 작은 문제 상황을 해결하는 루프문
            for (int index = maxHeapIndex; (index << 1) <= heapSize;)
            {
                int compareChildIndex = index << 1;
                if (compareChildIndex + 1 <= heapSize)
                {
                    if (heap[MAX_HEAP, compareChildIndex].data < heap[MAX_HEAP, compareChildIndex + 1].data)
                    {
                        ++compareChildIndex;
                    }
                }

                if (heap[MAX_HEAP, index].data < heap[MAX_HEAP, compareChildIndex].data)
                {
                    Swap(MAX_HEAP, index, compareChildIndex);
                    index = compareChildIndex;
                }
                else break;
            }
            // heapify : 큰 수 -> 빈칸 관계에서 빈칸이 자신의 부모보다 더 큰 수인 문제 상황을 해결하는 루프문
            for (int index = maxHeapIndex; (index >> 1) > 0; index >>= 1)
            {
                if (heap[MAX_HEAP, index].data <= heap[MAX_HEAP, index >> 1].data) break;

                Swap(MAX_HEAP, index, index >> 1);
            }


            if (STATUS)
            {
                Console.WriteLine($"Pop({targetHeap}) : heapify 이후의 힙의 상황");
                PrintHeap();
                Console.WriteLine($"Pop({targetHeap}) : 종료됨");
            }

        }
        static void Push(int _data)
        {
            // 새로운 원소 생성 후 각 힙에 넣기
            ++heapSize;
            HeapElement newElement = new HeapElement()
            {
                data = _data,
                heapIndex = new int[] { heapSize, heapSize }
            };
            heap[MIN_HEAP, heapSize] = newElement;
            heap[MAX_HEAP, heapSize] = newElement;
            
            for (int index = heapSize; (index >> 1) > 0; index >>= 1)
            {
                if (heap[MIN_HEAP, index].data >= heap[MIN_HEAP, (index >> 1)].data) // 부모와 자식의 크기 관계가 적절한 상태입니다.
                {
                    break; // 만약 조건을 불만족하면 즉시 루프 탈출
                }

                // 스왑
                Swap(MIN_HEAP, index, index >> 1);
            }
            for (int index = heapSize; (index >> 1) > 0; index >>= 1)
            {
                if (heap[MAX_HEAP, index].data <= heap[MAX_HEAP, (index >> 1)].data) // 부모와 자식의 크기 관계가 적절한 상태입니다.
                {
                    break; // 만약 조건을 불만족하면 즉시 루프 탈출
                }

                // 스왑
                Swap(MAX_HEAP, index, index >> 1);
            }
        }
        // 아무래도 잘못이 없는 것 같다.
        static void Print()
        {
            if (heapSize < 1)
            {
                result.AppendLine("EMPTY");
            }
            else
            {
                result.AppendLine($"{heap[MAX_HEAP, 1].data} {heap[MIN_HEAP, 1].data}");
            }
        }

        static void Main(string[] args)
        {
            result = new StringBuilder();

            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; ++i)
            {
                Init();
                int k = int.Parse(Console.ReadLine());

                for (int j = 0; j < k; ++j)
                {
                    string[] commandLine = Console.ReadLine().Split(' ');
                    switch (commandLine[0])
                    {
                        case "I":
                            Push(int.Parse(commandLine[1]));
                            break;
                        case "D":
                            if (commandLine[1].Equals("1")) Pop(MAX_HEAP);
                            else Pop(MIN_HEAP);
                            break;
                        default:
                            break;
                    }
                }

                if (STATUS)
                {
                    Console.WriteLine("연산 종료 이후 힙의 상황");
                    PrintHeap();
                }

                Print();
            }

            Console.Write(result);
        }
    }
}
