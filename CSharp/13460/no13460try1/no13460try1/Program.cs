using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no13460try1
{
    // 브론즈 2문제
    internal class Program
    {
        static void Say(object a) => Console.WriteLine($"DEBUG : {a.ToString()}");

        static int callStack = 0;
        static void FuncCall(object a)
        {
            StringBuilder result = new StringBuilder();
            result.Append("DEBUG: ");
            for (int i = 0; i < callStack; ++i)
                result.Append("| ");
            result.Append(a.ToString());
            Console.WriteLine(result);
            ++callStack;
        }
        static void FuncEnd(object a)
        {
            --callStack;
            StringBuilder result = new StringBuilder();
            result.Append("DEBUG: ");
            for (int i = 0; i < callStack; ++i)
                result.Append("| ");
            result.Append(a.ToString());
            Console.WriteLine(result);
        }
        static void FuncMid(object a)
        {
            StringBuilder result = new StringBuilder();
            result.Append("DEBUG: ");
            for (int i = 0; i < callStack; ++i)
                result.Append("| ");
            result.Append(a.ToString());
            Console.WriteLine(result);
        }

        const int REQUEST_TIMEOUT = -408;
        const int NOT_FOUND = -404;

        // 너비 우선 탐색 시 큐 사용

        enum Direction
        {
            north,
            south,
            west,
            east
        }
        enum MoveResult
        {
            moved,
            success,
            failed
        }
        class Situation // 공의 위치 상황을 저장하는 클래스입니다.
        {
            bool isGoalReached; // 빨간공이 해당 위치에 들어갔을 때 true를 리턴해줍니다.            
            /// <summary>
            /// BallPositionData 비트 구조 : 0b_0000_0000_0000_0000_AAAA_BBBB_CCCC_DDDD
            /// A : Red X Position (index)
            /// B : Red Y Position (index)
            /// C : blue X Position (index)
            /// D : blue Y Position (index)
            /// </summary>
            int ballPositionData;
            int moveCount; // history에 가장 마지막에 추가된 원소의 index 값이기도 합니다.
            int[] historyPos; // 만약 현재 포지션을 생성할 때, 이전과 동일한 포지션이 만들어지면 이 상황은 소멸합니다.
            StringBuilder historyDirection;

            //public void ShowStatus()
            //{
            //    StringBuilder result = new StringBuilder();
            //    (int redX, int redY, int blueX, int blueY) pos = GetPositionData();

            //    for (int y = 0; y < map.GetLength(0); ++y)
            //    {
            //        for (int x = 0; x < map.GetLength(1); ++x)
            //        {
            //            if (x == pos.redX && y == pos.redY) result.Append('R');
            //            else if (x == pos.blueX && y == pos.blueY) result.Append('B');
            //            else result.Append(map[y, x]);
            //        }
            //        result.Append('\n');
            //    }
            //    Console.WriteLine(result);
            //}
            public Situation()
            {
                historyPos = new int[11]; // 배열 선언은 IndexOutOfRange를 발생시키지 않습니다.
                moveCount = 0;
                historyDirection = new StringBuilder();
                isGoalReached = false;
            }
            public Situation DeepCopy()
            {
                Situation result = new Situation()
                {
                    ballPositionData = this.ballPositionData,
                    historyPos = this.historyPos,
                    historyDirection = new StringBuilder(),
                    moveCount = this.moveCount,
                    isGoalReached = this.isGoalReached
                };
                result.historyDirection.Append(this.historyDirection.ToString());

                return result;
            }
            public void SetPosition(int redX, int redY, int blueX, int blueY)
            {
                ballPositionData = 0;
                ballPositionData |= (redX << 12);
                ballPositionData |= (redY << 8);
                ballPositionData |= (blueX << 4);
                ballPositionData |= blueY;
            }
            public void HistoryInit()
            {
                historyPos[0] = ballPositionData; // 이 함수를 호출하는 모든 상황의 시점에서 historyPos는 이미 Length가 11이므로 IndexOutOfRange의 원인이 아님
            }
            public (int redX, int redY, int blueX, int blueY) GetPositionData()
            {
                return (
                    (ballPositionData & 0b_0000_0000_0000_0000_1111_0000_0000_0000) >> 12,
                    (ballPositionData & 0b_0000_0000_0000_0000_0000_1111_0000_0000) >> 8,
                    (ballPositionData & 0b_0000_0000_0000_0000_0000_0000_1111_0000) >> 4,
                    (ballPositionData & 0b_0000_0000_0000_0000_0000_0000_0000_1111));
            }
            // 해당 상황에서 4가지 방향으로 움직여 봅니다. 그 결과에 대한 상황을 리턴해줍니다.
            public int PopSituation()
            {
                //FuncCall($"PopSituation()");

                if (moveCount > 9)
                {
                    //FuncEnd($"PopSituation() = REQUEST_TIMEOUT");
                    return REQUEST_TIMEOUT;
                }

                // 상하좌우로 이동한 결과값을 리턴해봅니다.
                Situation north = TryMove('N');
                if (north != null)
                {
                    //Console.WriteLine();
                    //Say("current");
                    //this.ShowStatus();
                    //Say("north");
                    //north.ShowStatus();

                    if (north.isGoalReached)
                    {
                        //FuncEnd($"PopSituation() = {north.moveCount}");
                        return north.moveCount;
                    }
                    PushQueue(north);
                }
                Situation south = TryMove('S');
                if (south != null)
                {
                    //Console.WriteLine();
                    //Say("current");
                    //this.ShowStatus();
                    //Say("south");
                    //south.ShowStatus();

                    if (south.isGoalReached)
                    {
                        //FuncEnd($"PopSituation() = {south.moveCount}");
                        return south.moveCount;
                    }
                    PushQueue(south);
                }
                Situation west = TryMove('W');
                if (west != null)
                {
                    //Console.WriteLine();
                    //Say("current");
                    //this.ShowStatus();
                    //Say("west");
                    //west.ShowStatus();

                    if (west.isGoalReached)
                    {
                        //FuncEnd($"PopSituation() = {west.moveCount}");
                        return west.moveCount;
                    }
                    PushQueue(west);
                }
                Situation east = TryMove('E');
                if (east != null)
                {
                    //Console.WriteLine();
                    //Say("current");
                    //this.ShowStatus();
                    //Say("east");
                    //east.ShowStatus();
                    //FuncMid($"east.isGoalReached = {east.isGoalReached}");

                    if (east.isGoalReached)
                    {
                        //FuncEnd($"PopSituation() = {east.moveCount}");
                        return east.moveCount;
                    }
                    PushQueue(east);
                }
                //FuncEnd($"PopSituation() = -1");
                return -1;
            }
            
            /// <summary>
            ///     현재 상태를 복사한 다음 해당 방향으로 이동하고 그 결과를 리턴합니다. 실패한 경우라면 null을 리턴합니다.
            /// </summary>
            /// <param name="direction"></param>
            /// <returns></returns>
            private Situation TryMove(char direction) // 이 함수 호출한 모든 시점에서 this.moveCount는 9와 같거나 9보다 작다는것이 보장됩니다.
            {
                //FuncCall($"TryMove({direction})");
                // bool canMove
                // 루프 : canMove
                // CanMove = false
                // 한칸씩 R과 B를 번갈아가며 움직여본다
                // 빨강과 파란공중 하나라도 움직일수 있으면 한칸씩 움직이고 canMove를 트루로 한다
                // 한 턴에 빨간공이 움직일지 체크 -> 빨간공 이동 -> 파란공 움직일지 체크 -> 파란공 이동 / 루프 끝
                // canMove가 true면 다시 반복한다.
                // 1. 파란공에 구멍에 도착하면 즉시 null 리턴
                // 2. 빨간공 만 구멍에 도착하면 success 표시
                // 3. 둘다 아닌 경우 moved
                // 루프 빠져나가면 위치값 대입하고 리턴.
                Situation temp = DeepCopy();

                bool CanAnyBallMove = true;
                (int redX, int redY, int blueX, int blueY) posData = temp.GetPositionData();
                while (CanAnyBallMove)
                {
                    CanAnyBallMove = false;
                    // 빨간공 움직이기 체크 및 움직이기
                    if (CanMove(posData.redX, posData.redY, posData.blueX, posData.blueY, direction))
                    {
                        (int x, int y) redMovedPos = Move(posData.redX, posData.redY, direction);
                        posData.redX = redMovedPos.x;
                        posData.redY = redMovedPos.y;
                        CanAnyBallMove = true;
                        if (map[posData.redY, posData.redX] == 'O') // 오류 가능성
                        {
                            temp.isGoalReached = true;
                            posData.redX = -1;
                            posData.redY = -1;
                        }
                    }
                    // 파란공 움직이기 체크 및 움직이기
                    if (CanMove(posData.blueX, posData.blueY, posData.redX, posData.redY, direction))
                    {
                        (int x, int y) blueMovedPos = Move(posData.blueX, posData.blueY, direction);
                        posData.blueX = blueMovedPos.x;
                        posData.blueY = blueMovedPos.y;
                        CanAnyBallMove = true;
                        if (map[posData.blueY, posData.blueX] == 'O') // 오류 가능성
                        {
                            //FuncEnd($"TryMove({direction}) = null");
                            return null;
                        }
                    }
                }
                // 이동이 끝났습니다. 여기 아래는 파란 공이 구멍에 도달하지 않았습니다.
                // 히스토리에 이 위치 값이 이미 있었다면 null을 리턴합니다.
                // ㄴ 아니라면 히스토리에 위치 값을 push하고,
                // ㄴ 움직인 횟수를 늘립니다.
                // ㄴ 히스토리 방향 값도 추가하기
                // ㄴ 위치 값 반영하기
                temp.SetPosition(posData.redX, posData.redY, posData.blueX, posData.blueY);
                // 이미 해당 위치 값이 있는지 체크합니다.
                for (int index = 0; index <= temp.moveCount; ++index)
                {
                    //FuncMid($"TryMove({direction}).Loop : historyPos[{index}] = {historyPos[index]}, temp.ballPositionData = {temp.ballPositionData}");
                    if (historyPos[index] == temp.ballPositionData) 
                        // TryMove를 호출하는 4가지의 모든 상황중 이미 if 문을 통하여 temp.moveCount이 9보다 작거나 같고, 생성자에 의해 0보다 크거나 같다는 점이 보장됩니다.
                        // temp는 this의 깊은 복사본입니다.
                    {
                        //FuncEnd($"TryMove({direction}) = null");
                        return null;
                    }
                }
                temp.moveCount++; // 여기서의 temp.moveCount은 최대 10입니다. historyPos은 Length가 11입니다.
                temp.historyPos[temp.moveCount] = temp.ballPositionData; // 윗줄의 주석에 의해 여기서 IndexOutOfRange를 발생시키지 않습니다.
                temp.historyDirection.Append(direction);

                //FuncEnd($"TryMove({direction}) = temp");
                return temp;
            }
            // 벽과 공이 막고 있는지를 체크합니다. 구멍은 바닥으로 인식하며 파란공이 구멍에 빠지는 사건은 고려하지 않습니다.
            private bool CanMove(int oneX, int oneY, int oppositeX, int oppositeY, char direction)
            {
                //FuncCall($"CanMove({oneX}, {oneY}, {oppositeX}, {oppositeY}, {direction})");

                // 현재 공이 구멍을 따라 나간 상태라면 연산하지 않습니다.
                if (oneX == -1)
                {
                    //FuncEnd($"CanMove({oneX}, {oneY}, {oppositeX}, {oppositeY}, {direction}) = false");
                    return false;
                }
                // 1. 대상이 벽인지 체크 -> 2. 공이 가로막고 있는지 체크
                int nextMoveX = oneX;
                int nextMoveY = oneY;
                switch (direction)
                {
                    case 'N':
                        --nextMoveY;
                        break;
                    case 'S':
                        ++nextMoveY;
                        break;
                    case 'E':
                        ++nextMoveX;
                        break;
                    case 'W':
                        --nextMoveX;
                        break;
                    default:
                        break;
                }
                if (map[nextMoveY, nextMoveX] == '#') // 오류 가능성
                {
                    //FuncEnd($"CanMove({oneX}, {oneY}, {oppositeX}, {oppositeY}, {direction}) = false");
                    return false;
                }
                if (oppositeX == -1) // 공이 구멍을 타고 나간 상태입니다.
                {
                    //FuncEnd($"CanMove({oneX}, {oneY}, {oppositeX}, {oppositeY}, {direction}) = true");
                    return true;
                }
                if (nextMoveX == oppositeX && nextMoveY == oppositeY)
                {
                    //FuncEnd($"CanMove({oneX}, {oneY}, {oppositeX}, {oppositeY}, {direction}) = false");
                    return false;
                }
                //FuncEnd($"CanMove({oneX}, {oneY}, {oppositeX}, {oppositeY}, {direction}) = true");
                return true;
            }
            private (int x, int y) Move(int x, int y, char direction)
            {
                //FuncCall($"Move({x}, {y}, {direction})");
                int newX = x;
                int newY = y;
                switch (direction)
                {
                    case 'N': newY -= 1; break;
                    case 'S': newY += 1; break;
                    case 'E': newX += 1; break;
                    case 'W': newX -= 1; break;
                    default: return (x, y);
                }
                //FuncEnd($"Move({x}, {y}, {direction}) = ({newX}, {newY})");
                return (newX, newY);
            }
        }

        /// <summary>
        ///     map[y, x]
        /// </summary>
        static char[,] map;

        //static Situation[] queueData = new Situation[78_733]; // 4 * (3 ^ 9) + 1
        static Situation[] queueData = new Situation[1_048_576]; // 4 * (3 ^ 9) + 1
        static int queuePushPos = 0; // 새롭게 추가되어야 할 장소입니다
        static int queuePopPos = 0;
        
        static void InitMap(int y, int x) // 3 7 ==> 가로 7 세로 3
        {
            map = new char[y, x]; // 2차원 배열의 선언에서 IndexOutOfRange를 발생시키지 않습니다.
            Situation startSituation = new Situation();
            int tempRedPosX = -1;
            int tempRedPosY = -1;
            int tempBluePosX = -1;
            int tempBluePosY = -1;


            for (int yIndex = 0; yIndex < y; ++yIndex)
            {
                string recvLine = Console.ReadLine(); // 주석 2번
                                                      // recvLine.Length와 x값은 동일합니다.
                                                      // 이유 : "첫 번째 줄에는 보드의 세로, 가로 크기를 의미하는 두 정수 N, M (3 ≤ N, M ≤ 10)이 주어진다.
                                                      //        다음 N개의 줄에 보드의 모양을 나타내는 길이 M의 문자열이 주어진다."

                for (int xIndex = 0; xIndex < x; ++xIndex)
                {
                    map[yIndex, xIndex] = recvLine[xIndex];
                    // 주석 1번 : 첫번째 인덱스 접근은 yIndex는 0보다 크거나 같고 y보다 작고,
                    //          xIndex는 0보다 크거나 같고 항상 x보다 작으므로 IndexOutOfRange를 발생시키지 않습니다
                    // 두번째 인덱스 접근은 주석 2번에 의해 IndexOutOfRange를 발생시키지 않습니다
                    if (recvLine[xIndex] == 'B') // 주석 2번과 주석 1번에 의해 IndexOutOfRange를 발생시키지 않습니다
                    {
                        tempBluePosX = xIndex;
                        tempBluePosY = yIndex;
                        map[yIndex, xIndex] = '.';
                        // 위 주석 1번에 의해 IndexOutOfRange를 발생시키지 않습니다
                    }
                    else if (recvLine[xIndex] == 'R')
                        // 주석 2번과 주석 1번에 의해 IndexOutOfRange를 발생시키지 않습니다
                    {
                        tempRedPosX = xIndex;
                        tempRedPosY = yIndex;
                        map[yIndex, xIndex] = '.';
                        // 위 주석 1번에 의해 IndexOutOfRange를 발생시키지 않습니다
                    }
                }
            }
            startSituation.SetPosition(tempRedPosX, tempRedPosY, tempBluePosX, tempBluePosY);
            startSituation.HistoryInit();
            PushQueue(startSituation);
        }
        static void PushQueue(Situation target)
        {
            queueData[queuePushPos] = target; // 오류 가능성
            ++queuePushPos;
        }
        static int GetCount() => queuePushPos - queuePopPos;
        static Situation PopQueue()
        {
            if (queuePushPos - queuePopPos == 0) return null;
            Situation result = queueData[queuePopPos];
            ++queuePopPos;
            return result;
        }

        static void Main(string[] args)
        {
            int result = -1;
            string[] nums = Console.ReadLine().Split(' ');
            InitMap(int.Parse(nums[0]), int.Parse(nums[1])); // nums의 원소의 갯수는 항상 2이므로 IndexOutOfRange를 발생시키지 않습니다
            //queueData[0].ShowStatus();
            while (GetCount() > 0)
            {
                //Say(GetCount());

                Situation current = PopQueue();
                result = current.PopSituation();
                if (result == REQUEST_TIMEOUT)
                {
                    result = -1;
                    break;
                }
                else if (result == -1) continue;
                else
                {
                    
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
