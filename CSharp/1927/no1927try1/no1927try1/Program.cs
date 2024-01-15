using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1927try1
{
    internal class Program
    {
        static uint[] minHeapData;
        static int minHeapSize;

        static void Init()
        {
            minHeapData = new uint[100_001];
            minHeapSize = 0;
        }

        static void Push(uint num)
        {
            ++minHeapSize;
            minHeapData[minHeapSize] = num;

            // heapify
            for (int i = minHeapSize; i / 2 > 0;)
            {
                if (minHeapData[i] < minHeapData[i / 2])
                {
                    Swap(i, i / 2);
                    i >>= 1;
                }
                else break;
            }
        }

        static uint Pop()
        {
            if (minHeapSize == 0) return 0;

            uint result = minHeapData[1];
            
            // heapify
            minHeapData[1] = minHeapData[minHeapSize];
            minHeapData[minHeapSize] = 0;
            --minHeapSize;
            for (int i = 1; i * 2 <= minHeapSize;)
            {
                // 현재 커서가 가리키는 노드와, 그 노드의 자식 노드 중 가장 작은 자식 노드와 비교
                int compareNode = i * 2;
                if (i * 2 + 1 <= minHeapSize) // 두번째 자식 노드가 존재합니다.
                {
                    if (minHeapData[i * 2] > minHeapData[i * 2 + 1]) // 젓번째 자식과 두번째 자식을 비교
                    {
                        compareNode = i * 2 + 1;
                    }
                }

                if (minHeapData[i] > minHeapData[compareNode])
                {
                    Swap(i, compareNode);
                    i = compareNode;
                }
                else break;
            }
            
            return result;
        }

        static void Swap(int indexA, int indexB)
        {
            uint temp = minHeapData[indexA];
            minHeapData[indexA] = minHeapData[indexB];
            minHeapData[indexB] = temp;
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());

            Init();

            for (int i = 0; i < count; ++i)
            {
                uint recvNum = uint.Parse(Console.ReadLine());

                if (recvNum == 0)
                    result.AppendLine(Pop().ToString());
                else
                    Push(recvNum);
            }

            Console.Write(result);
        }
    }
}
