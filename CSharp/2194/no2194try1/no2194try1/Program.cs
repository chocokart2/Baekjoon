using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2194try1
{
    internal class Program
    {
        class BadQueue<T>
        {
            public T[] Data;
            public int Count
            {
                get { return indexHead - indexTail; }
            }
            private int indexHead;
            private int indexTail;

            public BadQueue() { }

            public void Init(int size)
            {
                Data = new T[size];
            }

            public void Push(T item)
            {
                Data[indexHead] = item;
                indexHead++;
            }
            public T Pop()
            {
                if (indexTail >= indexHead) return default;
                indexTail++;
                return Data[indexTail - 1];
            }
        }
        class Map2D<T> // 2D 직사각형 격자형 그래프입니다
        {
            public int xSize { private set; get; }
            public int ySize { private set; get; }

            public T[,] Data { set; get; }
            public T this[int x, int y]
            {
                get
                {
                    return Data[x, y];
                }
                set
                {
                    Data[x, y] = value;
                }
            }


            private bool isSizeInited;

            // 이동할 수 있는 방향입니다.
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
            public TypeNameX[,] GetNewTraceArray<TypeNameX>()
            {
                return new TypeNameX[Data.GetLength(0), Data.GetLength(1)];
            }
            public TypeNameX[,] GetNewTraceArray<TypeNameX>(TypeNameX containData)
            {
                TypeNameX[,] result = GetNewTraceArray<TypeNameX>();
                for (int y = 0; y < ySize; ++y)
                {
                    for (int x = 0; x < xSize; ++x)
                    {
                        result[x, y] = containData;
                    }
                }
                return result;
            }
            public bool IsInsideRange(int xIndex, int yIndex)
                => (0 <= xIndex) && (xIndex < xSize) && (0 <= yIndex) && (yIndex < ySize);
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
        static void Main(string[] args)
        {
            // 멥 사이즈 : N * M
            // 유닛 사이즈 : A * B
            const bool WALL = true;
            const int NOT_ACCESSABLE = int.MaxValue;

            Map2D<bool> map = new Map2D<bool>();

            string[] recvLineNMABK = Console.ReadLine().Split(' ');
            int numM = int.Parse(recvLineNMABK[0]); // Ysize1
            int numN = int.Parse(recvLineNMABK[1]); // Xsize1
            int numA = int.Parse(recvLineNMABK[2]); // Ysize2
            int numB = int.Parse(recvLineNMABK[3]); // Xsize2
            int numK = int.Parse(recvLineNMABK[4]);
            int unitPaddingX = numB - 1;
            int unitPaddingY = numA - 1;

            map.Init(new bool[numN, numM]);
            for (int i = 0; i < numK; ++i)
            {
                string[] numsPos = Console.ReadLine().Split(' ');
                map[int.Parse(numsPos[1]) - 1, int.Parse(numsPos[0]) - 1] = WALL;
            }

            // 너비 우선 탐색
            // 맵 위치는 왼쪽 위를 기준으로 합니다.
            int[,] steps = map.GetNewTraceArray(NOT_ACCESSABLE);
            BadQueue<(int x, int y)> queue = new BadQueue<(int x, int y)>();
            queue.Init(numN * numM);
            string[] startPos = Console.ReadLine().Split(' ');
            int startX = int.Parse(startPos[1]) - 1;
            int startY = int.Parse(startPos[0]) - 1;
            steps[startX, startY] = 0;
            queue.Push((startX, startY));
            string[] endPos = Console.ReadLine().Split(' ');
            int endX = int.Parse(endPos[1]) - 1;
            int endY = int.Parse(endPos[0]) - 1;
            
            while (queue.Count > 0)
            {
                (int x, int y) = queue.Pop();

                (int x, int y)[] next = map.GetAroundIndex(x, y,
                    delegate (int posX, int posY)
                    {
                        if (!map.IsInsideRange(posX, posY)) return false;
                        if (!map.IsInsideRange(posX + unitPaddingX, posY + unitPaddingY)) return false;
                        for (int indexX = posX; indexX < posX + numB; ++indexX)
                        {
                            for (int indexY = posY; indexY < posY + numA; ++indexY)
                            {
                                if (map[indexX, indexY] == WALL) return false;
                            }
                        }
                        return true;
                    }
                    );
                // 더 가까운 길이면 업데이트
                int nextSteps = steps[x, y] + 1;
                foreach ((int nextX, int nextY) in next)
                {
                    if (steps[nextX, nextY] > nextSteps)
                    {
                        queue.Push((nextX, nextY));
                        steps[nextX, nextY] = nextSteps;
                    }
                }
            }

            Console.WriteLine((steps[endX, endY] != NOT_ACCESSABLE) ? steps[endX, endY] : -1);
        }
    }
}
