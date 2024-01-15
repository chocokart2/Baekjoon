using System;

namespace no2206try1
{
    internal class Program
    {

        // 그렇다면 Node를 int 하나로 변환한다음에. 그것을 Node 취급할까? 그리고 함수들은 map에 위치시키고.
        // GetX, SetX, GetY, Sety, GetStepCount, SetStepCount, (WriteBit, ReadBit : 앞의 여섯 함수를 도와줌)
        // IsReached, Copy
        struct Node
        {
            // 비트 구조
            // 0b_0AAA_AAAA_AAAA_BBBB_BBBB_BBCC_CCCC_CCCC
            // A는 step의 횟수
            // B는 x좌표
            // C는 y좌표


            public int x;
            public int y;
            public int stepCount;

            public bool IsReachEnd() => (x == blockData.GetLength(0) - 1) && (y == blockData.GetLength(1) - 1);
            public Node Copy(int dx, int dy) => new Node() { stepCount = this.stepCount + 1, x = this.x + dx, y = this.y + dy };
        }

        class Map
        {
            bool this[long x, long y]
            {
                get
                {
                    if (brokenPosX == x && brokenPosY == y)
                    {
                        return AIR;
                    }
                    else
                    {
                        return blockData[x, y];
                    }
                }
            }
            int brokenPosX;
            int brokenPosY;
            
            // 콘솔로 초기화하는 함수 (완료)
            // 최단 경로를 구하는 횟수
            // 벽 하나를 선택하여 파괴하는 모든 경우의 수를 지도의 배열로 리턴하는 함수. (완료)

            public Map()
            {
                brokenPosX = NOT_BROKEN;
                brokenPosY = NOT_BROKEN;
            }
            public long GetMinRoute() // 길을 찾지 못했으면 NOT_FOUND_ROUTE를 리턴
            {
                // 변수 선언 구간
                //Node[] queueData = new Node[1_000_001]; // 엄청 큰!
                long[] queueData = new long[1_000_001];
                int queueHead = 0;// 추가를 호출할 때 생성될 원소의 인덱스입니다.
                int queueRear = 0;// 파괴를 호출할 때 파괴될 원소의 인덱스입니다.
                bool[,] hasVisited = new bool[blockData.GetLength(0), blockData.GetLength(1)];

                // 함수 정의 구간
                void Push(long item)
                {
                    queueData[queueHead] = item;
                    ++queueHead;
                }
                long Pop()
                {
                    long _result = queueData[queueRear];
                    ++queueRear;
                    return _result;
                }
                bool IsAvailableNode(long x, long y)
                {
                    if (x < 0 || x > blockData.GetLength(0) - 1) return false;
                    if (y < 0 || y > blockData.GetLength(1) - 1) return false;
                    return (this[x, y] == AIR) && (hasVisited[x, y] == false);
                }

                // 실행
                //Node start = new Node() { stepCount = 1, x = 0, y = 0 };
                long start = 0;
                start = SetStep(start, 1);
                Push(start);
                while (queueHead > queueRear)
                {
                    long one = Pop();
                    long oneX = GetX(one);
                    long oneY = GetY(one);

                    if (IsNodeReachEnd(one)) return GetStep(one);
                    // 인근 블럭으로 뻗어나가본다.
                    if (IsAvailableNode(oneX + 1, oneY))
                    {
                        Push(Copy(one, 1, 0));
                        hasVisited[oneX + 1, oneY] = true;
                    }
                    if (IsAvailableNode(oneX - 1, oneY))
                    {
                        Push(Copy(one, -1, 0));
                        hasVisited[oneX - 1, oneY] = true;
                    }
                    if (IsAvailableNode(oneX, oneY + 1))
                    {
                        Push(Copy(one, 0, 1));
                        hasVisited[oneX, oneY + 1] = true;
                    }
                    if (IsAvailableNode(oneX, oneY - 1))
                    {
                        Push(Copy(one, 0, -1));
                        hasVisited[oneX, oneY - 1] = true;
                    }
                }
                return NOT_FOUND_ROUTE;
            }
            //public Map[] BreakWall()
            //{
            //    Map[] result = new Map[wallCount + 1];
            //    result[0] = this;

            //    int index = 1;
            //    for (int y = 0; y < blockData.GetLength(1); ++y)
            //    {
            //        for (int x = 0; x < blockData.GetLength(0); ++x)
            //        {
            //            if (blockData[x, y] == AIR) continue;
                        
            //            Map one = new Map();
            //            one.brokenPosX = x;
            //            one.brokenPosY = y;
            //            result[index] = one;
            //            ++index;
            //        }
            //    }

            //    return result;
            //}
            public long Search()
            {
                long result = GetMinRoute();

                for (int y = 0; y < blockData.GetLength(1); ++y)
                {
                    for (int x = 0; x < blockData.GetLength(0); ++x)
                    {
                        if (blockData[x, y] == AIR) continue;
                        Map one = new Map() { brokenPosX = x, brokenPosY = y };
                        long oneRoute = one.GetMinRoute();
                        if (result > oneRoute) result = oneRoute;
                    }
                }
                if (result == NOT_FOUND_ROUTE) result = -1;
                return result;
            }
        }
        const int NOT_BROKEN = -1;
        const int NOT_FOUND_ROUTE = int.MaxValue;
        const bool WALL = true;
        const bool AIR = false;
        const char AIR_CHAR = '0';
        static bool[,] blockData; // 맵의 구성
        static int wallCount; // 벽 파괴 구현을 편리하게 하기 위한 변수


        static long GetStep(long NodeInt32) => NodeInt32 >> 20;
        static long GetX(long NodeInt32) => (NodeInt32 >> 10) & 1023;
        static long GetY(long NodeInt32) => NodeInt32 & 1023;
        static long SetStep(long NodeInt32, long value)
        {
            return (NodeInt32 & 0b_0000_0000_0000_0000_0000_1111_1111_1111_1111_1111) | (value << 20);
        }
        static long SetX(long NodeInt32, long value)
        {
            return (NodeInt32 & 0b_1111_1111_1111_1111_1111_0000_0000_0011_1111_1111) | (value << 10);
        }
        static long SetY(long NodeInt32, long value)
        {
            return (NodeInt32 & 0b_1111_1111_1111_1111_1111_1111_1111_1100_0000_0000) | value;
        }
        static long Copy(long NodeInt32, long dx, long dy)
        {
            return SetStep(SetY(SetX(NodeInt32, GetX(NodeInt32) + dx), GetY(NodeInt32) + dy), GetStep(NodeInt32) + 1);
        }
        static bool IsNodeReachEnd(long NodeInt32) =>
            (GetX(NodeInt32) == blockData.GetLength(0) - 1) && (GetY(NodeInt32) == blockData.GetLength(1) - 1);

        static Map Init()
        {
            string[] sizies = Console.ReadLine().Split(' ');
            int sizeX = int.Parse(sizies[1]);
            int sizeY = int.Parse(sizies[0]);

            wallCount = 0;

            blockData = new bool[sizeX, sizeY];
            for (int y = 0; y < sizeY; ++y)
            {
                string recvLine = Console.ReadLine();

                for (int x = 0; x < sizeX; ++x)
                {
                    if (recvLine[x] == AIR_CHAR) continue;

                    blockData[x, y] = WALL;
                    wallCount++;
                }
            }

            Map result = new Map();
            return result;
        }


        static void Main(string[] args)
        {
            Map original = Init();
            long result = original.Search();
            Console.WriteLine(result);
        }
    }
}
