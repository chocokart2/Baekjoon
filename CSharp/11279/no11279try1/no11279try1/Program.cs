using System;
using System.Text;

namespace no11279try1
{
    internal class Program
    {
        static int[] heapData = new int[100_000];
        static int heapSize = 0;

        static void Push(int item)
        {
            ++heapSize;
            heapData[heapSize] = item;
            
            // heapify
            for (int index = heapSize; (index >> 1) > 0;)
            {
                if (heapData[index] > heapData[index >> 1])
                {
                    Swap(index, index >> 1);
                    index >>= 1;
                }
                else break;
            }    
        }
        static int Pop()
        {
            if (heapSize < 1) return 0;
            int result = heapData[1];
            heapData[1] = heapData[heapSize];
            --heapSize;

            // heapify
            for (int index = 1; index << 1 <= heapSize;)
            {
                //
                int maxChildIndex = index << 1;
                if (maxChildIndex + 1 <= heapSize)
                {
                    if (heapData[maxChildIndex] < heapData[maxChildIndex + 1])
                    {
                        ++maxChildIndex;
                    }
                }

                if (heapData[maxChildIndex] > heapData[index])
                {
                    Swap(maxChildIndex, index);
                    index = maxChildIndex;
                }
                else
                {
                    break;
                }
            }

            return result;
        }
        static void Swap(int indexA, int indexB)
        {
            int temp = heapData[indexA];
            heapData[indexA] = heapData[indexB];
            heapData[indexB] = temp;
        }
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; ++i)
            {
                string recvLine = Console.ReadLine();
                if (recvLine.Equals("0"))
                {
                    result.Append($"{Pop()}\n");
                }
                else
                {
                    Push(int.Parse(recvLine));
                }
            }
            Console.WriteLine(result);
        }
    }
}
