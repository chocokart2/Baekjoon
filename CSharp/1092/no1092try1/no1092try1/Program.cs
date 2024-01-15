using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace no1092try1
{
    internal class Program
    {
        class Heap<T>
        {
            private Comparison<T> IsLeftGreatherThenRight;
            private T[] data;
            private int count;

            const int NOT_FOUND = -1;


            public Heap(int size, Comparison<T> function)
            {
                data = new T[size + 1];
                count = 0;
                IsLeftGreatherThenRight = function;
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

            private void M_Swap(int leftIndex, int rightIndex)
            {
                T temp = data[leftIndex];
                data[leftIndex] = data[rightIndex];
                data[rightIndex] = temp;
            }

            private void M_Heapify(int targetIndex)
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
            private int M_FindMotherIndex(int targetIndex) => (targetIndex < 2) ? NOT_FOUND : targetIndex >> 1;
            private int M_FindDaughterIndex(int targetIndex)
            {
                int result = NOT_FOUND;
                if ((targetIndex << 1) > count) return result;
                result = (targetIndex << 1);
                if (result + 1 > count) return result;
                if (M_IsLeftPriority(data[result], data[result + 1])) return result;
                return result + 1;
            }
            private bool M_IsLeftPriority(T left, T right)
                => IsLeftGreatherThenRight(left, right) <= 0;
        }

        static void Main(string[] args)
        {
            int crainCount = int.Parse(Console.ReadLine());
            string[] crainCapacityString = Console.ReadLine().Split();
            int[] crainCapacityArray = new int[crainCount];
            int boxCount = int.Parse(Console.ReadLine());
            string[] boxWeightString = Console.ReadLine().Split();
            int[] boxWeightArray = new int[boxCount];
            int[] crainQuota = new int[crainCount]; // 만약 가장 센 크레인의 커페시티보다 큰 박스의 등장인 경우 즉시 -1을 리턴.
            Heap<int> sorter = new Heap<int>(10_000, delegate (int left, int right) { return left - right; });

            for (int index = 0; index < crainCapacityString.Length; ++index)
            {
                sorter.Push(int.Parse(crainCapacityString[index]));
            }
            for (int index = 0; index < crainCapacityArray.Length; ++index)
            {
                crainCapacityArray[index] = sorter.Pop();
            }
            for (int index = 0; index < boxWeightString.Length; ++index)
            {
                sorter.Push(int.Parse(boxWeightString[index]));
            }
            for (int index = 0; index < boxWeightArray.Length; ++index)
            {
                boxWeightArray[index] = sorter.Pop();
            }

            bool isImpossible = false;
            for (int boxIndex = 0, crainIndex = 0;
                boxIndex < boxWeightArray.Length;
                )
            {
                Console.WriteLine($"boxWeightArray[boxIndex] = {boxWeightArray[boxIndex]}");
                Console.WriteLine($"crainCapacityArray[crainIndex] = {crainCapacityArray[crainIndex]}");

                if (boxWeightArray[boxIndex] > crainCapacityArray[crainIndex])
                {
                    ++crainIndex;
                    if (crainIndex < crainCapacityArray.Length) continue;
                    else
                    {
                        isImpossible = true;
                        break;
                    }
                }
                crainQuota[crainIndex]++;
                ++boxIndex;
            }

            if (isImpossible)
            {
                Console.WriteLine(-1);
                return;
            }

            // 일단 가장 짐이 많아보이는 크레인을 선택합니다.
            // 왼쪽의 크레인의 짐을 바로 다음 칸의 크레인에게 떠넘깁니다. 이를 반복합니다.
            // 크레인의 짐이 더이상 옮길수 없으면 그만둡니다. 왼쪽 크레인이 오른쪽 크레인의 짐 차이가 1이거나 0이면 동등하게 할당되었다고 간주합니다.
        }
    }
}
