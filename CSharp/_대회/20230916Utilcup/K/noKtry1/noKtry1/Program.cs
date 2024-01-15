using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noKtry1
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


        static void Main(string[] args)
        {
            int inkCount;
            int size;
            int command;
            int posX = 0;
            int posY = 0;
            int inkAmount = 0;
            int inkIndex = 0;
            string inkArray;
            string commandArray;
            Map2D<char> map = new Map2D<char>();

            string[] recvLineINK = Console.ReadLine().Split(' ');
            inkCount = int.Parse(recvLineINK[0]);
            size = int.Parse(recvLineINK[1]);
            command = int.Parse(recvLineINK[2]);
            inkArray = Console.ReadLine();
            char[,] data = new char[size, size];
            for (int y = 0; y < size; y++)
            {
                string recvLine = Console.ReadLine();

                for (int x = 0; x < size; ++x)
                {
                    data[x, y] = recvLine[x];
                    if (recvLine[x] == '@')
                    {
                        data[x, y] = '.';
                        posX = x;
                        posY = y;
                    }
                }
            }

            //Console.WriteLine("TEST");/
            map.Init(data);
            //Console.WriteLine(map.ToString());

            commandArray = Console.ReadLine();

            // read Command
            for (int commandIndex = 0; commandIndex < commandArray.Length; ++commandIndex)
            {
                switch (commandArray[commandIndex])
                {
                    //fine
                    case 'j':
                        inkAmount++;
                        //Console.WriteLine($"inkAmount = {inkAmount}");
                        break;
                        // fine
                    case 'J':
                        for (int x = 0; x < size; ++x)
                        {
                            for (int y = 0; y < size; ++y)
                            {
                                if (Math.Abs(x - posX) + Math.Abs(y - posY) > inkAmount) continue;
                                if ((map.Data[x, y] == '.') || (map.Data[x, y] == '@')) continue;
                                map.Data[x, y] = inkArray[inkIndex];
                            }
                        }
                        inkAmount = 0;
                        inkIndex++;
                        if (inkIndex >= inkCount) inkIndex = 0;
                        break;
                        // fine
                    case 'U': if (map.IsInsideRange(posX, posY - 1)) if (map.Data[posX, posY - 1] == '.') posY--; break;
                    case 'D': if (map.IsInsideRange(posX, posY + 1)) if (map.Data[posX, posY + 1] == '.') posY++; break;
                    case 'L': if (map.IsInsideRange(posX - 1, posY)) if (map.Data[posX - 1, posY] == '.') posX--; break;
                    case 'R': if (map.IsInsideRange(posX + 1, posY)) if (map.Data[posX + 1, posY] == '.') posX++; break;
                    default:
                        break;
                }

                //Console.WriteLine(map.ToString());
            }

            map.Data[posX, posY] = '@';
            //Console.WriteLine(map.xSize);
            //Console.WriteLine(map.ySize);
            //Console.WriteLine(posX);
            //Console.WriteLine(posY);
            //Console.WriteLine(map.Data[0,0]);
            Console.Write(map.ToString());
        }
    }
}
