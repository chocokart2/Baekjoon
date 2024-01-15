using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no12865try1
{
    internal class Program
    {
        struct SItem
        {
            public int weight;
            public int value;

            static public SItem operator+(SItem left, SItem right)
            {
                return new SItem()
                {
                    weight = left.weight + right.weight,
                    value = left.value + right.value
                };
            }
            static public SItem operator-(SItem left, SItem right)
            {
                return new SItem()
                {
                    weight = left.weight - right.weight,
                    value = left.value - right.value
                };
            }
        }

        static SItem[] items;
        static int capacityWeight;
        static SItem sum;
        static Stack<int> itemIndex;
        static int backtrackIndex;
        static bool isBacktrackExists;

        static (bool isFound, int index) TryFindNext(int pivotIndex)
        {
            if (pivotIndex >= items.Length) return (false, -1);
            for (int index = pivotIndex + 1; index < items.Length; ++index)
            {
                // 합해도 한계값을 초과하지 않는 경우에만 허용합니다.
                if (sum.weight + items[index].weight <= capacityWeight) return (true, index);
            }
            return (false, -1);
        }


        static void Main(string[] args)
        {
            string[] recvLineNK = Console.ReadLine().Split(' ');
            items = new SItem[int.Parse(recvLineNK[0])];
            capacityWeight = int.Parse(recvLineNK[1]);
            sum = new SItem() { weight = 0, value = 0 };
            itemIndex = new Stack<int>(101);

            int maxValue = 0;
            
            for (int index = 0; index < items.Length; ++index)
            {
                string[] recvLineOne = Console.ReadLine().Split(' ');
                items[index] = new SItem()
                {
                    weight = int.Parse(recvLineOne[0]),
                    value = int.Parse(recvLineOne[1])
                };
            }

            // 첫번째 아이템을 챙겨봅니다. 물론 챙길 수 있는 아이템이여야 합니다. 시작 인덱스는 -1 입니다. 실패한다면 조기 리턴합니다.

            (bool isFound, int index) first = TryFindNext(-1);

            if (first.isFound)
            {
                itemIndex.Push(first.index);
                sum += items[first.index];
            }
            else
            {
                Console.WriteLine(0);
                return;
            }



            while (true)
            {
                if (sum.value > maxValue) maxValue = sum.value;
                //Console.WriteLine($"가치 : 현재 합 : {sum.value}, 최대 합 : {maxValue}");
                //Console.WriteLine($"무게 : 현재 합 : {sum.weight}");

                int oneIndex = -1;

                if (isBacktrackExists)
                {
                    //Console.WriteLine($"one : 백트래킹 값 이용");
                    oneIndex = backtrackIndex;
                    isBacktrackExists = false;
                }
                else
                {
                    //Console.WriteLine($"one : Peek 값 이용");
                    oneIndex = itemIndex.Peek();
                }

                (bool isFound, int index) next = TryFindNext(oneIndex);

                if (next.isFound)
                {
                    //Console.WriteLine($"Next 물품을 찾았습니다!");
                    itemIndex.Push(next.index);
                    sum += items[next.index];
                }
                else
                {
                    if (itemIndex.Count == 0)
                    {
                        break;
                    }
                    backtrackIndex = itemIndex.Pop();
                    isBacktrackExists = true;
                    sum -= items[backtrackIndex];
                }
            }

            Console.WriteLine(maxValue);
        }
    }
}