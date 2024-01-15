using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2638try1
{
    internal class Program
    {
        class Map2D<T>
        {
            public int xSize { private set; get; }
            public int ySize { private set; get; }
            public T[,] Data { set; get; }


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
            public int[] InitByNumString(string[] recvLines, params T[] format)
            {
                // 숫자와 줄바꿈, 공백으로 이루어진 문자열의 배열을 2차원 배열로 만듭니다.
                int sizeOfX = recvLines[0].Split(' ').Length;
                Data = new T[sizeOfX, recvLines.Length];

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
                xSize = Data.GetLength(0);
                ySize = Data.GetLength(1);
                return result;
            }

            public bool IsInsideRange(int xIndex, int yIndex)
                => (0 <= xIndex) && (xIndex < xSize) && (0 <= yIndex) && (yIndex < ySize);
        }
        enum Block
        {
            air = 0,
            cheese = 1
        }



        static void Main(string[] args)
        {
            // 0,0위치에 너비 우선 탐색을 한다.
            // 만약에 두번 이상 닿은 치즈가 있다면, 파괴할 치즈에 예약한다.
            int ySize = int.Parse(Console.ReadLine().Split(' ')[0]);
            string[] mapString = new string[ySize];
            for (int index = 0; index < ySize; ++index)
                mapString[index] = Console.ReadLine();

            Map2D<Block> map = new Map2D<Block>();

            int[] blockCount = map.InitByNumString(mapString, Block.air, Block.cheese);

            int result = 0;

            //Console.WriteLine($"DEBUG : Map의 정보 : xSize = {map.xSize}, Ysize = {map.ySize}");

            while (true)
            {
                // 치즈가 다 안 녹으면 매번 "치즈 녹이기"를 실행한다
                //Console.WriteLine($"DEBUG : 현재 치즈의 갯수 : {blockCount[1]}");


                if (blockCount[1] == 0) break;
                result++;

                (int, int)[] queueData = new (int, int)[map.xSize * map.ySize + 1];
                queueData[0] = (0, 0);
                int queueRear = 0;
                int queueHead = 1;

                bool[,] hasVisited = new bool[map.xSize, map.ySize];
                int[,] contectAirCount = new int[map.xSize, map.ySize];
                
                bool IsExpandable(int x, int y)
                {
                    if (map.IsInsideRange(x, y) == false) return false;
                    if (map.Data[x, y] == Block.cheese)
                    {
                        contectAirCount[x, y]++;
                        //Console.WriteLine($"DEBUG : IsExpandable({x}, {y}) 에서 치즈가 공기에 닿습니다 : contectAirCount[x, y] = {contectAirCount[x, y]}");
                    }
                    return (map.Data[x, y] == Block.air) && (hasVisited[x, y] == false);
                }
                void Add(int x, int y)
                {
                    queueData[queueHead] = (x, y);
                    queueHead++;
                    hasVisited[x, y] = true;
                }

                // 어떤 치즈가 녹을 것인지 결정합니다.
                while (queueHead - queueRear > 0)
                {
                    //Console.WriteLine($"DEBUG : 너비 우선 탐색 진행 중! : queueHead - queueRear = {queueHead - queueRear}");
                    (int x, int y) one = queueData[queueRear];

                    // 근처 격자에 새 공기면 확장, 아니면 멈춥니다.
                    if (IsExpandable(one.x + 1, one.y)) Add(one.x + 1, one.y);
                    if (IsExpandable(one.x - 1, one.y)) Add(one.x - 1, one.y);
                    if (IsExpandable(one.x, one.y + 1)) Add(one.x, one.y + 1);
                    if (IsExpandable(one.x, one.y - 1)) Add(one.x, one.y - 1);

                    queueRear++;
                }
                
                // 해당 위치의 치즈를 녹입니다.
                for (int y = 0; y < map.ySize; ++y)
                {
                    for (int x = 0; x < map.xSize; ++x)
                    {
                        if (contectAirCount[x, y] > 1)
                        {
                            map.Data[x, y] = Block.air;
                            blockCount[1]--;
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
