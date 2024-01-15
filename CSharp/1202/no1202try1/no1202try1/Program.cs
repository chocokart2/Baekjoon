using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1202try1
{
    internal class Program
    {
        class Item
        {
            public long value;
            public long weight;
        }
        class Heap<T>
        {
            // 숫자 : 작은 값일수록 우선순위가 높습니다.
            private Comparison<T> IsLeftPrecedence; // 왼쪽이 우선이면 음수가 아님.
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
        class LinkedArray<T>
        {
            class Element
            {
                public int index;
                public T value;
                public Element next;
            }

            public int Count
            {
                get => count;
            }

            Element[] data;
            Element start;
            Element end;
            Element current;
            Element prev;
            int count;

            public LinkedArray(T[] input)
            {
                int size = input.Length;
                data = new Element[size];
                count = size;
                for (int index = 0; index < size; ++index)
                {
                    data[index] = new Element();
                    data[index].index = index;
                    data[index].value = input[index];
                }
                for (int index = 0; index < size - 1; ++index)
                {
                    data[index].next = data[index + 1];
                }

                if (input.Length > 0)
                {
                    start = data[0];
                    end = data[count - 1];
                    current = data[0];
                }

                prev = null;
            }

            public T GetCurrent()
            {
                if (current == null) return default;
                return current.value;
            }
            public void HideNow()
            {
                if (prev == null)
                {
                    start = current.next;
                    current = current.next;
                }
                else
                {
                    prev.next = current.next;
                    current = current.next;
                }
                count--;
            }
            public bool GoBegin()
            {
                if (start == null) return false;
                current = start;
                prev = null;
                return true;
            }
            public bool GoNext()
            {
                // 마지막을 지나쳤다면 false를 리턴
                if (current == null) return false;
                if (current.next == null) return false;
                current = current.next;
                return true;
            }
        }

        static void Main(string[] args)
        {
            const long EMPTY = -1;
            
            string[] recvLineNK = Console.ReadLine().Split(' ');
            int diamondCount = int.Parse(recvLineNK[0]);
            int bagCount = int.Parse(recvLineNK[1]);
            Heap<Item> diamonds = new Heap<Item>(diamondCount, delegate (Item left, Item right)
            {
                if (right.value < left.value) return -1;
                if (right.value > left.value) return 1;
                return 0;
            });


            Heap<Item> bagsSorter = new Heap<Item>(bagCount, delegate (Item left, Item right)
            {
                if (left.weight < right.weight) return -1;
                if (left.weight > right.weight) return 1;
                return 0;
            });
            // 배열을 써서 문제였구만.
            // 물건이 들어간 가방은 백솔터에서 빼내고, 가방을 뒤지는 과정에서 제외된 가방은 임시 저장소에 넣어두고,
            // 다음 물건이 들어오면 임시 저장소에 있던 가방을 다시 힙에 넣기ㅣ

            Item[] bags = new Item[bagCount];

            // diamonds initate
            for (int i = 0; i < diamondCount; ++i)
            {
                string[] recvLineDiamond = Console.ReadLine().Split(' ');
                diamonds.Push(new Item() { weight = long.Parse(recvLineDiamond[0]), value = long.Parse(recvLineDiamond[1]) });
            }

            //Item[] diamondsArr = new Item[diamondCount];
            //for (int index = 0; index < diamondCount; ++index)
            //{
            //    diamondsArr[index] = diamonds.Pop();
            //    //Console.WriteLine($">> [{index}] = (val = {diamondsArr[index].value}, weight = {diamondsArr[index].weight})");
            //}
            //foreach (Item one in diamondsArr)
            //{
            //    diamonds.Push(one);
            //}

            for (int i = 0; i < bagCount; ++i)
            {
                bagsSorter.Push(new Item()
                {
                    weight = long.Parse(Console.ReadLine()),
                    value = EMPTY
                });
            }
            for (int index = 0; index < bags.Length; ++index)
            {
                bags[index] = bagsSorter.Pop();
            }
            LinkedArray<Item> emptyBags = new LinkedArray<Item>(bags);
            long sum = 0;

            for (int i = 0; i < diamondCount; ++i)
            {
                Item one = diamonds.Pop();

                if (emptyBags.Count == 0) break;

                emptyBags.GoBegin();
                // 아무 가방에 쑤셔넣음
                while (emptyBags.Count > 0)
                {
                    if (emptyBags.GetCurrent() == null)
                    {
                        Console.WriteLine("이거 널 값임");
                        return;
                    }
                    if (emptyBags.GetCurrent().weight < one.weight)
                    {
                        //Console.WriteLine($">>> 가방이 너무 작아서 넣을 수 없습니다. bags[{index}].weight = {bags[index].weight}");
                        if (emptyBags.GoNext()) continue;
                        break;
                    }

                    sum += one.value;
                    emptyBags.HideNow();
                    break;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
