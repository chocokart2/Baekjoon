using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10816try1
{
    internal class Program
    {
        // A의 배열.
        // A는 힙의 인덱스를 가리키기도 하고, 숫자의 정보도 저장한다.
        // 힙은 배열의 인덱스를 가리키기도 하고, 정보도 저장합니다. (출력을 위해 인덱스를 저장해둡니다.)
        class HeapElement : IComparable<HeapElement>
        {
            /// <summary>
            /// ㅈㅈㅈ
            /// </summary>
            public int index = 0;
            public int data = 0;

            public int CompareTo(HeapElement target)
            {
                if (target.data < data) return 1;
                else if (target.data > data) return -1;
                else return 0;
            }
            
            static public bool operator<(HeapElement left, HeapElement right) => left.data < right.data;
            static public bool operator>(HeapElement left, HeapElement right) => left.data > right.data;
        }
        
        class MinHeap // 이 heap은 Min heap입니다.
        {
            public int Cursor
            {
                get;
                private set;
            }

            const int EMPTY_HEAP = 0;
            HeapElement[] data;
            //int cursor = EMPTY_HEAP; // 마지막 데이터가 들어있는 장소입니다.


            public MinHeap(int size)
            {
                data = new HeapElement[size + 1];
                Cursor = EMPTY_HEAP;
            }

            public string ToString()
            {
                StringBuilder result = new StringBuilder();
                for (int index = 1; index < Cursor + 1; ++index)
                {
                    if (index == 1) result.Append($"{data[index].data}");
                    else result.Append($" {data[index].data}");
                }
                return result.ToString();
            }

            public void Insert(HeapElement target)
            {
                ++Cursor;
                data[Cursor] = target;

                for (int index = Cursor;
                        (index != 1) && (data[index] < data[index/2]);
                        index /= 2)
                {
                    mSwap(index, index / 2);
                }
            }
            public HeapElement Pop()
            {
                if (Cursor == EMPTY_HEAP) return null;

                HeapElement result = new HeapElement() { data = data[1].data, index = data[1].index };
                data[1] = data[Cursor];
                --Cursor;

                for (int index = 1; index * 2 <= Cursor;) // 왼쪽자식 노드가 존재할 때
                {
                    // 만약에 자식 노드보다 크다면, swap합니다. 커서도 계속 따릅니다.

                    // 두번째 자식 노드를 찾습니다. 첫번째 자식이 존재한다는 것은 for 루프에서 입증되었습니다.
                    int childNodeIndex = index * 2; // 자식 노드의 인덱스입니다.
                    if (childNodeIndex + 1 <= Cursor) // 자식 노드가 두개 있습니다. => 가장 작은 자식 노드의 위치를 찾습니다
                    {
                        // 가장 작은 자식 노드를 찾습니다.
                        if (data[childNodeIndex] > data[childNodeIndex + 1]) childNodeIndex++;
                    }
                    
                    // 가장 작은 자식 노드와 부모 노드를 비교합니다
                    if ((data[index] > data[childNodeIndex]) == false)
                    {
                        break;
                    }
                    mSwap(index, childNodeIndex);
                    index = childNodeIndex;
                }

                return result;
            }
            public HeapElement Peek()
            {
                if (Cursor == EMPTY_HEAP) return null;
                return data[1];
            }

            private void mSwap(int indexLeft, int indexRight)
            {
                HeapElement temp = new HeapElement() { data = data[indexLeft].data, index = data[indexLeft].index };
                data[indexLeft] = data[indexRight];
                data[indexRight] = temp;
            }
        }

        static MinHeap sourceHeap;
        static MinHeap targetHeap;

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            sourceHeap = new MinHeap(int.Parse(Console.ReadLine()));
            string[] nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < nums.Length; ++index)
            {
                sourceHeap.Insert(new HeapElement() { data = int.Parse(nums[index]), index = index });
            }

            int[] numCounts = new int[int.Parse(Console.ReadLine())];
            targetHeap = new MinHeap(numCounts.Length);
            nums = Console.ReadLine().Split(' ');
            for (int index = 0; index < nums.Length; ++index)
            {
                targetHeap.Insert(new HeapElement() { data = int.Parse(nums[index]), index = index });
            }

            // 힙에








            Console.WriteLine($"sourceHeap : {sourceHeap.ToString()}");
            Console.WriteLine($"targetHeap : {targetHeap.ToString()}");

            int previousTargetNumber = -1;
            int previousTargetCount = 0;

            HeapElement sourceOne = null;
            HeapElement targetOne = null;

            // 이 힙들은 작은 숫자부터 큰 숫자 순으로 이어지게 될 것입니다.
            // 원본 숫자들도 힙에 들어있고, 찾는 숫자들도 힙에 들어있습니다.
            // 찾는 숫자 힙과 원본 숫자 힙을 각각 하나씩 꺼냅니다.\
            // 두개의 힙중 하나의 숫자를 뽑는 행위를 반복합니다. 찾는 숫자 힙이 완전히 바닥날때까지 반복합니다.
            // 만약 찾는 숫자 힙에서 나온 하나가 작다면, 찾는 숫자 하나를 뺍니다
            // 만약 원본 숫자 힙에서 나온 one가 작다면 원본 숫자 one를 뺍니다.


            // 여기서 문제가 발생한 것 같은데?
            while (sourceHeap.Cursor > 0 && targetHeap.Cursor > 0)
            {
                sourceOne = sourceHeap.Peek();
                targetOne = targetHeap.Peek();

                if (previousTargetNumber != targetOne.data)
                {
                    previousTargetNumber = targetOne.data;
                    previousTargetCount = 0;
                }

                if (sourceOne == null || targetOne == null) break;
                if (sourceOne.data > targetOne.data)
                {
                    //Console.WriteLine($"sourceOne.data({sourceOne.data}) > targetOne.data({targetOne.data})");
                    if (previousTargetNumber != targetOne.data) // 새로 들어온 
                    {
                        previousTargetNumber = targetOne.data;
                        previousTargetCount = 0;
                    }
                    else
                    {
                        numCounts[targetOne.index] = previousTargetCount;
                    }
                    targetOne = targetHeap.Pop();
                }
                else if (sourceOne.data < targetOne.data)
                {
                    //Console.WriteLine($"sourceOne.data({sourceOne.data}) < targetOne.data({targetOne.data})");
                    sourceOne = sourceHeap.Pop();
                }
                else
                {
                    //Console.WriteLine($"sourceOne.data({sourceOne.data}) = targetOne.data({targetOne.data})");
                    sourceOne = sourceHeap.Pop();
                    ++previousTargetCount;
                    numCounts[targetOne.index] = previousTargetCount;
                }

                Console.WriteLine();
                Console.WriteLine($"sourceHeap : {sourceHeap.ToString()}");
                Console.WriteLine($"targetHeap : {targetHeap.ToString()}");
                result = new StringBuilder();
                for (int index = 0; index < numCounts.Length; ++index)
                {
                    if (index == 0)
                        result.Append(numCounts[0]);
                    else
                        result.Append($"_{numCounts[index]}");
                }
                //Console.WriteLine($"result : {result}");
            }

            while (targetHeap.Cursor > 0)
            {
                targetOne = targetHeap.Peek();

                if (targetOne.data == previousTargetNumber)
                {
                    numCounts[targetOne.index] = previousTargetCount;
                    targetOne = targetHeap.Pop();
                }
                else
                {
                    break;
                }
            }

            for (int index = 0; index < numCounts.Length; ++index)
            {
                if (index == 0)
                    result.Append(numCounts[0]);
                else
                    result.Append($" {numCounts[index]}");
            }
            Console.WriteLine(result);
        }
    }
}
