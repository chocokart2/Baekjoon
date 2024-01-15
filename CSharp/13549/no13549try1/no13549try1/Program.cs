using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no13549try1
{
    internal class Program
    {
        class Heap<T>
        {
            // 작은 값일수록 우선순위가 높습니다.

            private Comparison<T> IsLeftGreatherThenRight;
            private T[] data;
            public int count { get; private set; }

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

        struct SStep
        {
            public int locationIndex;
            public int stepCount; // 만약 locationIndex이 같은데 stepCount가 크다면 개같이 무시합니다.
        }

        const int INFINITY = -1;
        const int SIZE = 100_001;
        
        static int[] stepData;

        static bool IsNeedUpdate(SStep one)
        {
            if (one.locationIndex < 0 || one.locationIndex >= SIZE) return false;
            return (stepData[one.locationIndex] == INFINITY) || (stepData[one.locationIndex] > one.stepCount);
        }

        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');
            int startIndex = int.Parse(recvLine[0]);
            int finishIndex = int.Parse(recvLine[1]);


            // stepData중에서 가장 낮은 값을 선택해줍니다.
            Heap<SStep> selecter = new Heap<SStep>(SIZE * 3, delegate (SStep a, SStep b) { return a.stepCount - b.stepCount; });

            // selecter에 값을 넣을 때, stepData를 확인하여 갱신할 필요가 있는지 확인합니다.
            stepData = new int[SIZE];
            for (int index = 0; index < stepData.Length; ++index)
                stepData[index] = INFINITY;
            stepData[startIndex] = 0;
            selecter.Push(new SStep() { locationIndex = startIndex, stepCount = 0 });

            while (selecter.count > 0)
            {
                SStep one = selecter.Pop();

                SStep back = new SStep() { stepCount = one.stepCount + 1, locationIndex = one.locationIndex - 1 };
                if (IsNeedUpdate(back))
                {
                    stepData[back.locationIndex] = back.stepCount;
                    selecter.Push(back);
                }
                SStep forward = new SStep() { stepCount = one.stepCount + 1, locationIndex = one.locationIndex + 1 };
                if (IsNeedUpdate(forward))
                {
                    stepData[forward.locationIndex] = forward.stepCount;
                    selecter.Push(forward);
                }
                SStep teleport = new SStep() { stepCount = one.stepCount, locationIndex = one.locationIndex * 2 };
                if (IsNeedUpdate(teleport))
                {
                    stepData[teleport.locationIndex] = teleport.stepCount;
                    selecter.Push(teleport);
                }
            }

            Console.WriteLine(stepData[finishIndex]);
        }
    }
}
