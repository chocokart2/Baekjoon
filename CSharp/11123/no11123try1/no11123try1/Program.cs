using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace no11123try1
{
    internal class Program
    {
        class Map2D<T>
        {
            public int xSize { private set; get; }
            public int ySize { private set; get; }
            public T[,] Data { private set; get; }

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
        static bool[,] footPrint;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                int oneResult = 0;
                Map2D<bool> map = new Map2D<bool>();

                map.InitSize();
                map.InitDataByChar(
                    new Dictionary<char, bool>
                    { { '.', false }, { '#', true } }
                    );
                

                (int x, int y)[] queueNextPosition = new (int x, int y)[map.xSize * map.ySize + 1];
                int queueHead = 0;
                int queueTail = 0;
                footPrint = map.GetNewTraceArray();

                for (int x = 0; x < map.xSize; ++x)
                {
                    for (int y = 0; y < map.ySize; ++y)
                    {
                        if (map.Data[x, y] == false) continue;
                        if (footPrint[x, y] == true) continue;

                        queueNextPosition[queueHead] = (x, y);
                        queueHead++;
                        oneResult++;
                        //Console.WriteLine($">> DEBUG : ({x}, {y}) => {oneResult}");
                        while (queueHead > queueTail)
                        {
                            if (queueTail >= queueNextPosition.Length) throw new FormatException();
                            (int x, int y) one = queueNextPosition[queueTail];
                            queueTail++;

                            //Console.WriteLine($">> DEBUG : while 문 내의 one = ({one.x}, {one.y})");

                            (int x, int y)[] newStep = map.GetAroundIndex(one.x, one.y,
                                delegate (int xPos, int yPos)
                                {
                                    return (map.Data[xPos, yPos] == true) && (footPrint[xPos, yPos] == false);
                                }
                            );
                            for (int index = 0; index < newStep.Length; ++index)
                            {
                                queueNextPosition[queueHead] = newStep[index];
                                queueHead++;
                                footPrint[newStep[index].x, newStep[index].y] = true;
                            }
                            //Console.WriteLine($">> DEBUG : while 문 tail = {queueTail}, head = {queueHead}");

                        }




                    }
                }

                Console.WriteLine(oneResult);
            }

        }
    }
}
