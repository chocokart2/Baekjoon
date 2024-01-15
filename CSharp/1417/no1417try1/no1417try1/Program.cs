using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1417try1
{
    internal class Program
    {
        class MaxHeap
        {
            const int NOT_FOUND = -1;

            HeapElement[] data;
            int dasomIndex = 1;
            int cursor = 1;

            // 다솜의 위치 값
            // peek 하여 
            
            public MaxHeap()
            {
                int count = int.Parse(Console.ReadLine());
                data = new HeapElement[count + 1];

                for (int index = 1; index < data.Length; ++index)
                {
                    Push(new HeapElement() { voteCount = int.Parse(Console.ReadLine()) });
                }
            }


            // 힙 정렬이 된 대상중 유독 한 대상만 Heapify가 되지 않았습니다.
            public int Control()
            {
                int cost = 0;
                while (dasomIndex > 1)
                {
                    ++cost;
                    data[1].voteCount--;
                    data[dasomIndex].voteCount++;
                    Heapify(1);
                    Heapify(dasomIndex);

                    //Console.WriteLine($"1등 후보자의 지지자 1명을 매수했습니다.");
                    //Print();
                }

                int daughterIndex = TryGetDaughter(dasomIndex);
                if (daughterIndex != -1)
                {
                    if (data[dasomIndex].voteCount == data[daughterIndex].voteCount)
                    {
                        ++cost;
                    }
                }
                return cost;
            }
            private void Push(HeapElement item)
            {
                data[cursor] = item;
                Heapify(cursor);
                ++cursor;
            }
            private void Heapify(int index)
            {
                for (int currentIndex = index, daughterIndex = TryGetDaughter(index);
                    daughterIndex != NOT_FOUND;
                    currentIndex = daughterIndex, daughterIndex = TryGetDaughter(daughterIndex))
                {
                    if (data[currentIndex].voteCount >= data[daughterIndex].voteCount) break;
                    Swap(currentIndex, daughterIndex);
                }
                for (int currentIndex = index, motherIndex = TryGetMother(index);
                    motherIndex != NOT_FOUND;
                    currentIndex = motherIndex, motherIndex = TryGetMother(motherIndex))
                {
                    if (data[currentIndex].voteCount <= data[motherIndex].voteCount) break;
                    Swap(currentIndex, motherIndex);
                }
            }
            private int TryGetMother(int index) => (index < 2) ? NOT_FOUND : index >> 1;
            private int TryGetDaughter(int index)
            {
                int result = NOT_FOUND;
                if ((index << 1) > cursor - 1) return result;
                result = (index << 1);
                if (result + 1 > cursor - 1) return result;
                if (data[result].voteCount < data[result + 1].voteCount) return result + 1;
                return result;
            }
            private void Swap(int leftIndex, int rightIndex)
            {
                HeapElement temp = data[leftIndex];
                data[leftIndex] = data[rightIndex];
                data[rightIndex] = temp;
                if (leftIndex == dasomIndex) dasomIndex = rightIndex;
                else if (rightIndex == dasomIndex) dasomIndex = leftIndex;
            }
            private void Print()
            {
                for (int index = 1; index < data.Length; ++index)
                    Console.WriteLine($"후보자 득표수 : {data[index].voteCount} {((index == dasomIndex) ? "<-- 얘 다솜이" : "")}");
            }
        }

        class HeapElement
        {
            public int voteCount; // 해당 사람에 투표하려는 사람의 수
        }

        static void Main(string[] args)
        {
            MaxHeap votePool = new MaxHeap();
            Console.WriteLine(votePool.Control());
        }
    }
}
