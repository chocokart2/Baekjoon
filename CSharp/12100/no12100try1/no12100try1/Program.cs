using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no12100try1
{
    internal class Program
    {
        static bool isDebug = false;

        enum Direction
        {
            North,
            South,
            West,
            East
        }

        class Board
        {
            // 원소는 0이거나, 1이거나 2의 양수의 제곱 
            // 인덱스 접근은 [x - 1, y - 1]
            public int[,] tile;
            public int size = -1;
            public int moveStep;
            public Direction[] step;

            public Board(int size)
            {
                tile = new int[size, size];
                this.size = size;
                this.moveStep = 0;
                this.step = new Direction[5];
            }

            public void Init()
            {
                for (int y = 0; y < size; ++y)
                {
                    string[] line = Console.ReadLine().Split(' ');

                    for (int x = 0; x < size; ++x)
                    {
                        tile[x, y] = int.Parse(line[x]);
                    }
                }
            }
            public Board DeepCopy()
            {
                Board result = new Board(this.size);
                for (int x = 0; x < size; ++x)
                    for (int y = 0; y < size; ++y)
                        result.tile[x, y] = this.tile[x, y];
                result.moveStep = this.moveStep;
                for (int index = 0; index < moveStep; ++index)
                    result.step[index] = this.step[index];
                return result;
            }
            public Board CopyAndShift(Direction direction)
            {
                Board result = DeepCopy();
                result.moveStep++;

                // size X size 타일의 부을형 변수가 있습니다. 해당 블럭이 움직이는 속도를 가지고 있는지 여부를 저장합니다.

                // isChanged가 false일때까지 while 루프문을 돕니다.
                // nextX = currentX + deltaX, nextY = currentY + deltaY
                // currentX의 방향 : deltaX이 음수거나 0이면 증감값이 ++, 양수라면 증감값이 --, Y도 마찬가지
                // currentX의 시작지점 : deltaX이 음수거나 0이면 0부터 시작, 양수라면 size - 1부터 시작
                int deltaX = 0;
                int deltaY = 0;
                bool isChanged = true;
                //bool[,] hasSpeed = new bool[size, size];
                bool[,] hasStacked = new bool[size, size]; // 한번 겹쳐진 건 더이상 겹쳐질 수 없습니다. 
                


                //bool ShouldMove()
                //{
                //    for (int x = 0; x < size; ++x)
                //        for (int y = 0; y < size; ++y)
                //            if (hasSpeed[x, y]) return true;
                //    return false;
                //}
                // true인 타일만 움직일 수 있습니다. 한칸 이동시 한칸 이동하여 도착한 곳에 true를 남기고, 출발한 곳은 false로 만듭니다.
                // 만약 블럭이 합쳐지면 멈춰야 합니다.
                // ㄴ 왜냐하면, 블럭이 합쳐지려면 자신의 블럭은 이동해야 하지만,
                // ㄴ 상대방 블럭은 벽에 부딛혀 고정된 상태여야 하며, 그렇지 않으며ㅓㄴ

                result.step[result.moveStep - 1] = direction;
                switch (direction)
                {
                    case Direction.North: deltaY = -1; break;
                    case Direction.South: deltaY = 1; break;
                    case Direction.West: deltaX = -1; break;
                    case Direction.East: deltaX = 1; break;
                    default: break;
                }
                // 빈칸이 아닌 블럭인 대상에게만 true로 만듭니다.
                //for (int x = 0; x < size; ++x)
                //    for (int y = 0; y < size; ++y)
                //        hasSpeed[x, y] = tile[x, y] != 0;

                while (isChanged)
                {
                    isChanged = false;

                    for (int x = (deltaX > 0) ? size - 1 : 0; IsValidIndex(x); x = (deltaX > 0) ? x - 1 : x + 1)
                    {
                        int nextX = x + deltaX;
                        if (IsValidIndex(nextX) == false) continue;
                        
                        for (int y = (deltaY > 0) ? size - 1 : 0; IsValidIndex(y); y = (deltaY > 0) ? y - 1 : y + 1)
                        {
                            int nextY = y + deltaY;
                            if (IsValidIndex(nextY) == false) continue;

                            // 만약 0이면 이동 , isChanged = true
                            // 만약 같은 숫자면 합치기, isChanged = true
                            // 둘다 아니라면 움직이지 마!
                            if (result.tile[x, y] == 0) continue;

                            if (result.tile[nextX, nextY] == 0)
                            {
                                if (false)
                                {
                                    Console.WriteLine("result.tile[nextX, nextY] == 0");
                                }

                                // 데이터 이동
                                result.tile[nextX, nextY] = result.tile[x, y];
                                hasStacked[nextX, nextY] = hasStacked[x, y];
                                result.tile[x, y] = 0;
                                hasStacked[x, y] = false;

                                isChanged = true;
                            }
                            else if (result.tile[nextX, nextY] == result.tile[x, y]
                                && !(hasStacked[x, y] || hasStacked[nextX, nextY]))
                            {
                                if (false)
                                {
                                    Console.WriteLine("result.tile[nextX, nextY] == result.tile[x, y]");
                                    Console.WriteLine($"result.tile[nextX, nextY] : {result.tile[nextX, nextY]}");
                                }

                                   
                                result.tile[nextX, nextY] = 2 * result.tile[nextX, nextY];
                                hasStacked[nextX, nextY] = true;
                                result.tile[x, y] = 0;
                                hasStacked[x, y] = false;
                                isChanged = true;
                            }

                            //if (isDebug)
                            if (false)
                            {
                                Console.WriteLine($"\t=== 진행중 [{x}, {y}] === nextX : {nextX}, nextY : {nextY}");
                                result.DebugShowTile(1);
                            }

                        }
                    }
                }

                if (isDebug)
                {
                    Console.WriteLine();
                    result.DebugShowTile();
                    Console.WriteLine("=== END ===");
                }

                return result;
            }
            public int GetMax()
            {
                int max = 0;
                for (int x = 0; x < size; ++x)
                {
                    for (int y = 0; y < size; ++y)
                    {
                        if (tile[x, y] > max) max = tile[x, y];
                    }
                }
                return max;
            }
            private void DebugShowTile(int tab = 0)
            {
                if (tile == null)
                {
                    for (int i = 0; i < tab; ++i) Console.Write('\t');
                    Console.WriteLine("DebugShowTile() : 이 타일은 널 값입니다.");
                    return;
                }

                for (int i = 0; i < tab; ++i) Console.Write('\t');
                Console.WriteLine("DebugShowTile() : 호출됨");
                for (int i = 0; i < tab; ++i) Console.Write('\t');
                Console.Write("이동 방법 : ");
                for (int index = 0; index < moveStep; ++index)
                {
                    switch (step[index])
                    {
                        case Direction.North: Console.Write("U "); break;
                        case Direction.South: Console.Write("D "); break;
                        case Direction.West: Console.Write("L "); break;
                        case Direction.East: Console.Write("R "); break;
                    }
                }
                Console.WriteLine();
                for (int y = 0; y < size; ++y)
                {
                    for (int i = 0; i < tab; ++i) Console.Write('\t');
                    Console.Write("DebugShowTile() : ");
                    for (int x = 0; x < size; ++x)
                    {
                        Console.Write($"{tile[x, y]} ");
                    }
                    Console.WriteLine();
                }
            }
            private bool IsValidIndex(int target) => target < size && target > -1;
        }


        static void Main(string[] args)
        {
            Board[] caseArray = new Board[1365];
            int head = 1;
            int tail = 0;

            caseArray[0] = new Board(int.Parse(Console.ReadLine()));
            caseArray[0].Init();
            int max = caseArray[0].GetMax();
            
            while (head - tail > 0)
            {
                Board current = caseArray[tail];
                ++tail;

                if (current.moveStep < 5)
                {
                    caseArray[head] = current.CopyAndShift(Direction.North);
                    caseArray[head + 1] = current.CopyAndShift(Direction.South);
                    caseArray[head + 2] = current.CopyAndShift(Direction.West);
                    caseArray[head + 3] = current.CopyAndShift(Direction.East);
                    head += 4;
                }

                if (max < current.GetMax()) max = current.GetMax();
            }

            Console.WriteLine(max);
        }
    }
}
