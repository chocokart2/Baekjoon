using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        // 상황 : 기지의 상황, 해당 층 파괴 여부. 병장의 전투력
        // 한 기지를 격파를 완료한 각각의 상황 중에서 가장 높은 값만 저장합니다.
        //

        class Heap<T>
        {
            // 숫자 : 작은 값일수록 우선순위가 높습니다.

            private Comparison<T> IsLeftGreatherThenRight;
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
            public int GetCount() => count; 

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


        const long ITEM = -1;
        const bool BROKEN = true;

        class Situation
        {
            public long[] power;
            public bool[] cleared;
            public ulong attack;
            // 몇번째 기지인지 여부는 외부에서 저장합니다
        }

        static void Main(string[] args)
        {

            // 가장 약한 적부터 격파하고, 현재 시점에서 가장 약한 적이 현재 전투력보다 세면 아이템을 쓴다. 만약 아아템이 바닥나면 종료.



            int buildingCount;
            int buildingStoryCount;
            ulong maximumAttack; // 다음 기지에 도착하기전 가장 강할때의 공격력
            
            
            
            Situation[] situations;

            string[] recvLineNMP = Console.ReadLine().Split(' ');
            buildingCount = int.Parse(recvLineNMP[0]);
            buildingStoryCount = int.Parse(recvLineNMP[1]);
            maximumAttack = ulong.Parse(recvLineNMP[2]);
            //Heap<ulong> sorter = new Heap<ulong>(buildingStoryCount,
            //    delegate (ulong left, ulong right)
            //    {
            //        ulong result = left - right;
            //        if (result > 0) return 1;
            //        else if (result < 0) return -1;
            //        else return 0;
            //    });
            for (int i = 0; i < buildingCount; ++i)
            {
                string[] mapString = Console.ReadLine().Split(' ');

                int itemCount = 0;
                List<ulong> list = new List<ulong>();

                for (int index = 0; index < mapString.Length; ++index)
                {
                    //Console.WriteLine($">> DEBUG : 문자열 숫자 : {mapString[index]}");
                    if (mapString[index].Equals("-1"))
                    {
                        itemCount++;
                        continue;
                    }
                    //sorter.Push(ulong.Parse(mapString[index]));
                    list.Add(ulong.Parse(mapString[index]));
                }
                list.Sort();
                while (list.Count > 0)
                {
                    //ulong one = sorter.Pop();
                    ulong one = list[0];
                    list.RemoveAt(0);
                    //Console.WriteLine($">> DEBUG : one = {one}");
                    //Console.WriteLine($">> DEBUG : maximumAttack = {maximumAttack}");


                    if (one > maximumAttack)
                    {
                        while (one > maximumAttack)
                        {
                            if (itemCount <= 0)
                            {
                                Console.WriteLine(0);
                                return;
                            }

                            maximumAttack <<= 1;
                            --itemCount;
                        }
                    }
                    maximumAttack += one;
                }
                for (int item = 0; item < itemCount; ++item) maximumAttack <<= 1; 
            }
            Console.WriteLine(1);

        }
    }
}
