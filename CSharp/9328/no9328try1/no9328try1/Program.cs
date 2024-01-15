using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9328try1
{
    internal class Program
    {
        class Map2D<T>
        {
            public int xSize { private set; get; }
            public int ySize { private set; get; }
            public T[,] Data { set; get; }
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
            }

            public void Init(T[,] value)
            {
                if (Data == null)
                {
                    Data = value;
                    xSize = value.GetLength(0);
                    ySize = value.GetLength(1);
                }
            }
            public string ToString(string interval = "")
            {
                StringBuilder result = new StringBuilder();
                for (int y = 0; y < ySize; ++y)
                {
                    if (xSize > 1)
                        result.Append(Data[0,y].ToString());
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

        static int GetResult()
        {
            int result = 0;

            string[] sizeString = Console.ReadLine().Split(' ');
            int sizeX = int.Parse(sizeString[1]) + 2;
            int sizeY = int.Parse(sizeString[0]) + 2;
            Map2D<char> map = new Map2D<char>();
            char[,] data = new char[sizeX, sizeY];
            bool[] isOpen = new bool[128]; // index = char
            bool[,] footsteps = new bool[0,0];
            Queue<(int x, int y)>[] lockPos = new Queue<(int x, int y)>[26];
            for (int index = 0; index < 26; ++index)
            {
                lockPos[index] = new Queue<(int x, int y)>();
            }

            Func<int, int, bool> m_isAccessable = delegate (int posX, int posY)
            {
                return isOpen[map.Data[posX, posY]] && (footsteps[posX, posY] == false);
            };
            Func<int, int, bool> m_isLocked = delegate (int posX, int posY)
            {
                char one = map.Data[posX, posY];
                return (isOpen[one] == false) && IsUpperChar(one) && (footsteps[posX, posY] == false);
            };

            int endX = sizeX - 1;
            int endY = sizeY - 1;
            for (int x = 0; x < sizeX; ++x)
            {
                data[x, 0] = '.';
            }
            for (int y = 1; y < endY; ++y)
            {
                data[0, y] = '.';
                data[endX, y] = '.';
                string recvLine = Console.ReadLine();
                for (int x = 1; x < endX; ++x)
                {
                    data[x, y] = recvLine[x - 1];
                }
            }
            for (int x = 0; x < sizeX; ++x)
            {
                data[x, endY] = '.';
            }
            map.Init(data);

            isOpen['.'] = true;
            isOpen['$'] = true;
            for (char one = 'a'; one <= 'z'; ++one)
                isOpen[one] = true;

            string startKeys = Console.ReadLine();
            if (startKeys.Equals("0") == false)
            {
                for (int index = 0; index < startKeys.Length; ++index)
                    isOpen[startKeys[index] - 32] = true;
            }

            // 열쇠를 얻었으면 열쇠 칸을 제거합니다. 잠긴 알파벳은 제거하지 않습니다.
            // $를 얻었으면 해당 칸의 $를 제거하고, result ++ 합니다.



            // 이 한 루프당 너비 우선 탐색 1회를 진행합니다. 시작 지점은 왼쪽 위 [0,0] 입니다.

            //(int x, int y)[] nextQueue = new (int x, int y)[10405];
            (int x, int y)[] nextQueue = new (int x, int y)[50_000];
            int queueHead = 1;
            int queueRear = 0;

            nextQueue[0] = (0, 0);

            footsteps = map.GetNewTraceArray();

            footsteps[0, 0] = true;

            // 단 한번의 너비 우선 탐색을 합니다.
            // 열쇠를 얻는다면, 해당 위치를 




            while (queueHead - queueRear > 0)
            {
                (int m_x, int m_y) = nextQueue[queueRear];
                queueRear++;

                (int one_x, int one_y)[] tempPos = map.GetAroundIndex(m_x, m_y, m_isLocked);
                for (int index = 0; index < tempPos.Length; ++index)
                {
                    lockPos[map.Data[tempPos[index].one_x, tempPos[index].one_y] - 'A'].Enqueue(
                        (tempPos[index].one_x, tempPos[index].one_y));
                }

                (int one_x, int one_y)[] nextPos = map.GetAroundIndex(m_x, m_y, m_isAccessable);



                for (int index = 0; index < nextPos.Length; ++index)
                {
                    char oneBlock = map.Data[nextPos[index].one_x, nextPos[index].one_y];
                    nextQueue[queueHead] = (nextPos[index].one_x, nextPos[index].one_y);
                    footsteps[nextPos[index].one_x, nextPos[index].one_y] = true;
                    ++queueHead;

                    if (oneBlock == '$') result++;
                    if (IsLowerChar(oneBlock) && (isOpen[oneBlock - 32] == false))
                    {
                        isOpen[oneBlock - 32] = true;
                        while (lockPos[oneBlock - 'a'].Count > 0)
                        {
                            (int x, int y) posOne = lockPos[oneBlock - 'a'].Dequeue();
                            nextQueue[queueHead] = (posOne.x, posOne.y);
                            ++queueHead;
                        }
                    }
                    map.Data[nextPos[index].one_x, nextPos[index].one_y] = '.';
                }
            }

            if (false)
            {

                StringBuilder debuggerVisited = new StringBuilder();

                for (int y = 0; y < sizeY; ++y)
                {
                    for (int x = 0; x < sizeX; ++x)
                    {
                        if (map.Data[x, y] == '.')
                        {
                            if (footsteps[x, y] == true) debuggerVisited.Append('#');
                            else debuggerVisited.Append('.');
                        }
                        else
                        {
                            debuggerVisited.Append($"{map.Data[x, y]}");
                        }
                    }

                    debuggerVisited.Append('\n');
                }
                Console.Write(debuggerVisited);
            }


            return result;
        }


        static bool IsLowerChar(char target) => target < 123 && target > 96;
        static bool IsUpperChar(char target) => target < 91 && target > 64;
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; ++i)
            {
                result.Append($"{GetResult()}\n");
            }

            Console.Write(result);
        }
    }
}
// 일단 대문자 문은 2차 후보로 배치. 열쇠를 받으면, 즉시 해당하는 2차 후보의 포지션들을 전부 큐에 배치하기.