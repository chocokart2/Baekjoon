using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no14502try1
{
    class Map
    {
        public int[,] tile;
        public Vector2[] placedWalls;
        public Vector2[] virusPositions;
        public int xSize;
        public int ySize;
        public int emptySpaces; // tile이 init될때 계산하는 값이고, 빈 칸의 값입니다.

        public void Init()
        {
            string[] recvLineNM = Console.ReadLine().Split(' ');
            xSize = int.Parse(recvLineNM[1]);
            ySize = int.Parse(recvLineNM[0]);
            tile = new int[xSize, ySize];
            List<Vector2> tempVirusPositions = new List<Vector2>();
            for (int y = 0; y < ySize; ++y)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                for (int x = 0; x < xSize; ++x)
                {
                    if (recvLine[x][0] == '0') emptySpaces++;
                    if (recvLine[x][0] == '2') tempVirusPositions.Add(new Vector2() { x = x, y = y });
                    tile[x, y] = recvLine[x][0] - '0';
                }
            }
            virusPositions = tempVirusPositions.ToArray();
        }
        public bool TryMakeWall(Vector2[] wallPositions)
        {
            bool result = true;
            placedWalls = wallPositions;
            for (int index = 0; index < wallPositions.Length; ++index)
            {
                if (tile[wallPositions[index].x, wallPositions[index].y] == 0)
                {
                    tile[wallPositions[index].x, wallPositions[index].y] = 4;
                }
                else
                {
                    result = false;
                    break;
                }
            }

            if (result == true)
            {
                emptySpaces -= wallPositions.Length;
                return result;
            }

            for (int index = 0; index < wallPositions.Length; ++index)
            {
                if (tile[wallPositions[index].x, wallPositions[index].y] == 4)
                    tile[wallPositions[index].x, wallPositions[index].y] = 0;
                placedWalls = new Vector2[0] { };
            }
            return result;
        }
        public void ClearPlacedWall()
        {
            for (int index = 0; index < placedWalls.Length; ++index)
                tile[placedWalls[index].x, placedWalls[index].y] = 0;
            emptySpaces += placedWalls.Length;
            placedWalls = new Vector2[0] { };
        }
        public int GetZero()
        {
            // 0의 갯수를 구하고, 바이러스가 퍼질 때마다 갯수를 1씩 깜. 그리고 최대한 제거한 수를 리턴
            // 너비 우선 탐색
            int result = emptySpaces;
            bool[,] hasVisited = new bool[xSize, ySize];
            for (int index = 0; index < virusPositions.Length; ++index)
                hasVisited[virusPositions[index].x, virusPositions[index].y] = true;
            Queue<Vector2> nextOne = new Queue<Vector2>(xSize * ySize);
            for (int index = 0; index < virusPositions.Length; ++index)
                nextOne.Enqueue(virusPositions[index]);

            bool m_AvailableToVisit(int x, int y)
            {
                if (x < 0 || x > xSize - 1) return false;
                if (y < 0 || y > ySize - 1) return false;
                return (!hasVisited[x, y]) && (tile[x, y] == 0);
            }
            void m_Step(int x, int y)
            {
                hasVisited[x, y] = true;
                nextOne.Enqueue(new Vector2() { x = x, y = y });
                result--;
            }

            while (nextOne.Count > 0)
            {
                Vector2 one = nextOne.Dequeue();

                if (m_AvailableToVisit(one.x + 1, one.y)) m_Step(one.x + 1, one.y);
                if (m_AvailableToVisit(one.x - 1, one.y)) m_Step(one.x - 1, one.y);
                if (m_AvailableToVisit(one.x, one.y + 1)) m_Step(one.x, one.y + 1);
                if (m_AvailableToVisit(one.x, one.y - 1)) m_Step(one.x, one.y - 1);
            }

            //StringBuilder myString = new StringBuilder();
            //int[,] tempTile = GetTileWithMap();
            //for (int y = 0; y < ySize; ++y)
            //{
            //    for (int x = 0; x < xSize; ++x)
            //    {
            //        char c = '?';
            //        if (tempTile[x, y] == 2) c = '^';
            //        else if (tempTile[x, y] == 3) c = 'X';
            //        else if (hasVisited[x, y]) c = '#';
            //        else if (tempTile[x, y] == 1) c = 'D';
            //        else if (tempTile[x, y] == 0) c = '_';

            //        myString.Append($"{c} ");
            //    }
            //    myString.Append("\n");
            //}
            //Console.Write(myString);
            //Console.WriteLine($"결과 : {result}\n");
            return result;
        }
        public bool TryMoveNext(ref Vector2 target)
        {
            if (target.x == xSize - 1)
            {
                if (target.y == ySize - 1)
                {
                    return false;
                }
                target.x = 0;
                target.y++;
                return true;
            }
            target.x++;
            return true;
        }
        public bool TryMoveNext(ref Vector2[] target)
        {
            //첫번째 자리부터 옆으로 옮겨본다.
            // n번째 자리를 옮기다 : 
            // 1. tryMoveNext를 호출한다. false면 다음 자리를 택한다.
            // 2. 자신의 이전 자리들을 n의 옆 자리로 배치한다. 그 이전의 이전 자리들은 그의 옆의 옆 자리다.
            // copy 함수 활용하고.
            // 이런식으로 배치하다가, 만약 이들중 하나라도 마지막 자리를 지나친다면, 다음 자리를 택한다.
            // 4. 작업을 끝내고 루프를 빠져나온다.
            // 5. 작업을 끝내지 못한 채 루프를 빠져나오면 false를 리턴합니다.
            //만약 첫번째 자리부터 옮길 수 없다면, 그 다음 자리를 옮겨봅니다
            // 만약 n번째 자리까지 되지 않는다면 false를 리턴합니다.
            // k번째 자리를 옮길 때는 k-1번째 자리와 겹치지 않는지/ k-1번째가 다음 자리로 이동할수 있는지도 체크해야 합니다.
            // ㄴ만약 불가능하다면 k+1번째 자리를 옮겨야겠죠.

            for (int indexA = 0; indexA < target.Length; ++indexA)
            {
                if (TryMoveNext(ref target[indexA]) == false) continue;
                bool isOutOfRange = false;
                for (int indexB = indexA - 1; indexB > -1; --indexB)
                {
                    target[indexB] = target[indexB + 1].GetCopy();
                    if (TryMoveNext(ref target[indexB]) == false) isOutOfRange = true;
                }
                if (isOutOfRange) continue;
                return true;
            }
            return false;
        }
        int[,] GetTileWithMap()
        {
            StringBuilder result = new StringBuilder();
            int[,] myMap = new int[xSize, ySize];
            for (int x = 0; x < xSize; ++x)
                for (int y = 0; y < ySize; ++y)
                    myMap[x, y] = tile[x, y];
            for (int index = 0; index < placedWalls.Length; ++index)
            {
                myMap[placedWalls[index].x, placedWalls[index].y] = 3;
            }
            return myMap;
        }
        
    }

    class Vector2
    {
        public int x;
        public int y;

        public Vector2 GetCopy() => new Vector2() { x = this.x, y = this.y };
    }

    internal class Program
    {
        // 무작위로 3개의 곳에 벽을넣는 시나리오 배열을 만듭니다.
        // 각 시나리오마다 바이러스를 확산시킵니다
        // 남은 빈칸의 갯수를 얻고 최대값을 출력합니다.

        static void Main(string[] args)
        {
            int result = 0;
            // 벡터 3개를 만듭니다.
            Vector2[] wallPos = new Vector2[3]
            {
                new Vector2() { x = 0, y = 0 },
                new Vector2() { x = 1, y = 0 },
                new Vector2() { x = 2, y = 0 }
            };

            Map map = new Map();
            map.Init();

            do
            {
                wallPos[1] = wallPos[0].GetCopy();
                do
                {
                    wallPos[2] = wallPos[1].GetCopy();
                    do
                    {
                        if (map.TryMakeWall(wallPos))
                        {
                            result = Math.Max(result, map.GetZero());
                        }
                        map.ClearPlacedWall();
                    }
                    while (map.TryMoveNext(ref wallPos[2]));
                }
                while (map.TryMoveNext(ref wallPos[1]));
            }
            while (map.TryMoveNext(ref wallPos[0]));



            //do
            //{
            //    if (map.TryMakeWall(wallPos))
            //    {
            //        result = Math.Max(result, map.GetZero());
            //    }
            //    map.ClearPlacedWall();
            //}
            //while (map.TryMoveNext(ref wallPos));

            Console.WriteLine(result);
        }
    }
}
