using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2206try2
{
    internal class Program
    {
        class Map2D<T> // 2D 직사각형 격자형 그래프입니다
        {
            public int xSize { private set; get; }
            public int ySize { private set; get; }

            public T[,] Data { private set; get; }
            public T this[int x, int y]
            {
                get
                {
                    return Data[x, y];
                }
                private set
                {
                    Data[x, y] = value;
                }
            }


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
            public string ToStringAdvanced(string dataDefault, Dictionary<T, string> dataToString, string interval = "")
            {
                string m_ToString(T value) => dataToString.ContainsKey(value) ? dataToString[value] : dataDefault;

                StringBuilder result = new StringBuilder();
                for (int y = 0; y < ySize; ++y)
                {
                    if (xSize > 0)
                        result.Append(m_ToString(Data[0, y]));
                    for (int x = 1; x < xSize; ++x)
                    {
                        result.Append($"{interval}{m_ToString(Data[x, y])}");
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

        static void Main(string[] args)
        {
            // 0. 지도는 2개 준비. 하나는 폭탄 안쓴거, 다른거는 쓴거
            // 1. 너비 우선 탐색을 하면서, 도달할 수 있는 지역를 모두 표시1한다
            // 2. 도달할 수 있는 지역의 인접한 벽중, 주변 4칸에 도달할 수 없는 벽에 대해서 표시2한다.
            // 3. 2번에 표시한 벽을 하나씩 출발지점으로 선정하여,
            // "새롭게 혹은 더 빨리"도달 가능 지역에 대한 너비 우선 탐색을 한다. 이때, 벽은 한번만 뚫으므로, 뚫을 수 있는 벽이라도 건너면 안된다. 

            Map2D<>

            string[] size = Console.ReadLine().Split(' ');
            int sizeY = int.Parse(size[0]);
            int sizeX = int.Parse(size[1]);



        }
    }
}
