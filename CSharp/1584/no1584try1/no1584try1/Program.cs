using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace no1584try1
{
    internal class Program
    {
        enum block
        {
            safe,
            danger,
            death
        }

        class Map2D<T>
        {
            public int xSize { private set; get; }
            public int ySize { private set; get; }
            public T[,] Data { set; get; }

            private bool isSizeInited;

            readonly (int x, int y)[] nearDeltaIndex = new (int x, int y)[4]
            {
                (1, 0),
                (-1, 0),
                (0, 1),
                (0, -1),
            };

            public Map2D()
            {
                Data = null;
                isSizeInited = false;
            }

            public void Init(T[,] value)
            {
                if (Data == null)
                {
                    Data = value;
                    xSize = value.GetLength(0);
                    ySize = value.GetLength(1);
                    isSizeInited = true;
                }
            }
            public void InitSize(string size, bool isXyReversed = true, char spliter = ' ')
            {
                string[] nums = size.Split(spliter);
                int num1 = int.Parse(nums[0]);
                int num2 = int.Parse(nums[1]);

                isSizeInited = true;
                if (isXyReversed)
                {
                    xSize = num2;
                    ySize = num1;
                }
                else
                {
                    xSize = num1;
                    ySize = num2;
                }

                Data = new T[xSize, ySize];
            }
            public void InitSize(bool isXyReversed = true, char spliter = ' ')
            {
                InitSize(Console.ReadLine(), isXyReversed, spliter);
            }
            public void InitDataByChar(Dictionary<char, T> converter)
            {
                if (isSizeInited == false)
                {
                    Console.WriteLine($">> DEBUG : Init size first");
                    return;
                }

                for (int y = 0; y < ySize; ++y)
                {
                    string oneLine = Console.ReadLine();
                    if (oneLine == null)
                    {
                        Console.WriteLine(">> DEBUG : Line in Console is empty.");
                        Data = null;
                        return;
                    }
                    for (int x = 0; x < xSize; ++x)
                    {
                        Data[x, y] = converter[oneLine[x]];
                    }
                }
            }
            public string ToString(string interval = "")
            {
                StringBuilder result = new StringBuilder();
                for (int y = 0; y < ySize; ++y)
                {
                    if (xSize > 0)
                        result.Append(Data[0, y].ToString());
                    for (int x = 1; x < xSize; ++x)
                    {
                        result.Append($"{interval}{Data[x, y]}");
                    }
                    result.Append('\n');
                }
                return result.ToString();
            }
            public int[] InitByNumString(string[] recvLines, params T[] format)
            {
                // 숫자와 줄바꿈, 공백으로 이루어진 문자열의 배열을 2차원 배열로 만듭니다.
                int[] result = new int[format.Length];
                for (int y = 0; y < recvLines.Length; ++y)
                {
                    string[] oneLine = recvLines[y].Split(' ');
                    for (int x = 0; x < oneLine.Length; ++x)
                    {
                        int one = int.Parse(oneLine[x]);
                        Data[x, y] = format[one];
                        result[one]++;
                    }
                }
                return result;
            }
            public (int x, int y)[] GetAroundIndex(int x, int y, Func<int, int, bool> IsApproachableElement)
            {
                List<int> approachAbleIndex = new List<int>();

                (int x, int y)[] result;

                for (int index = 0; index < nearDeltaIndex.Length; ++index)
                {
                    int oneX = x + nearDeltaIndex[index].x;
                    int oneY = y + nearDeltaIndex[index].y;

                    if (IsInsideRange(oneX, oneY))
                        if (IsApproachableElement(oneX, oneY))
                            approachAbleIndex.Add(index);
                }

                result = new (int x, int y)[approachAbleIndex.Count];
                for (int index = 0; index < approachAbleIndex.Count; ++index)
                {
                    result[index] =
                        (x + nearDeltaIndex[approachAbleIndex[index]].x,
                        y + nearDeltaIndex[approachAbleIndex[index]].y);
                }

                return result;
            }
            public bool[,] GetNewTraceArray() => new bool[Data.GetLength(0), Data.GetLength(1)];

            public bool IsInsideRange(int xIndex, int yIndex)
                => (0 <= xIndex) && (xIndex < xSize) && (0 <= yIndex) && (yIndex < ySize);
        }
        class Heap<T>
        {
            // 숫자 : 작은 값일수록 우선순위가 높습니다.
            private Comparison<T> IsLeftPrecedence; // 왼쪽이 우선이면 음수가 아님.
            private T[] data;
            public int count { private set; get; }

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
        class Step
        {
            public int x;
            public int y;
            public int cost;
        }
        
        // return minX, minY, maxX, maxY
        static (int x1, int x2, int y1, int y2) Convert(string args)
        {
            string[] nums = args.Split(' ');
            int x1 = int.Parse(nums[0]);
            int x2 = int.Parse(nums[2]);
            int y1 = int.Parse(nums[1]);
            int y2 = int.Parse(nums[3]);
            return
                (
                Math.Min(x1, x2),
                Math.Max(x1, x2),
                Math.Min(y1, y2),
                Math.Max(y1, y2)
                );
        }

        static void Main(string[] args)
        {
            // 맵 만들기
            Map2D<block> map = new Map2D<block>();
            Map2D<int> minCost = new Map2D<int>();
            map.Init(new block[501, 501]);
            minCost.Init(new int[501, 501]);
            for (int y = 0; y < 501; ++y)
            {
                for (int x = 0; x < 501; ++x)
                {
                    map.Data[x, y] = block.safe;
                    minCost.Data[x, y] = int.MaxValue;
                }
            }
            int dangerCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < dangerCount; ++i)
            {
                (int x1, int x2, int y1, int y2) = Convert(Console.ReadLine());
                for (int x = x1; x <= x2; ++x)
                {
                    for (int y = y1; y <= y2; ++y)
                    {
                        map.Data[x, y] = block.danger;
                    }
                }
            }
            int deathCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < deathCount; ++i)
            {
                (int x1, int x2, int y1, int y2) = Convert(Console.ReadLine());
                for (int x = x1; x <= x2; ++x)
                {
                    for (int y = y1; y <= y2; ++y)
                    {
                        map.Data[x, y] = block.death;
                    }
                }
            }
            // 데이크스트라
            Heap<Step> selecter = new Heap<Step>(
                502 * 502 * 2,
                delegate (Step a, Step b)
                {
                    return a.cost - b.cost;
                });
            selecter.Push(new Step() { x = 0, y = 0, cost = 0 });
            minCost.Data[0, 0] = 0;
            while (selecter.count > 0)
            {
                Step one = selecter.Pop();

                //Console.WriteLine($">> DEBUG : one = ({one.x}, {one.y}) cost = {minCost.Data[one.x, one.y]}");


                (int x, int y)[] nextSteps = map.GetAroundIndex(one.x, one.y,
                    delegate (int _x, int _y)
                    {
                        if (map.Data[_x, _y] == block.death) return false;
                        return true;
                    }
                    );

                for (int index = 0; index < nextSteps.Length; ++index)
                {
                    int nextCost = minCost.Data[one.x, one.y];
                    if (map.Data[nextSteps[index].x, nextSteps[index].y] == block.danger) nextCost++;
                    if (minCost.Data[nextSteps[index].x, nextSteps[index].y] <= nextCost) continue;

                    selecter.Push(new Step() { x = nextSteps[index].x, y = nextSteps[index].y, cost = nextCost });
                    minCost.Data[nextSteps[index].x, nextSteps[index].y] = nextCost;
                }
            }
            //Console.WriteLine("AAA");
            //Console.WriteLine(minCost.ToString("\t"));
            if (minCost.Data[500, 500] == int.MaxValue) Console.WriteLine(-1);
            else Console.WriteLine(minCost.Data[500, 500]);
        }
    }
}
