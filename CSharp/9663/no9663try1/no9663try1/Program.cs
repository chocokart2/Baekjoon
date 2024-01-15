using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9663try1
{
    internal class Program
    {
        class MyDebugger
        {
            int step = 0;
            int loopCount = 0;

            public void EnterFunction(object arguments, [CallerMemberName] string caller = "", [CallerLineNumber] int lineNum = -1)
            {
                Console.WriteLine(CraftMessage($"{caller}({arguments}) : 라인 {lineNum}에 호출됨"));
                ++step;
            }
            public void OutFunction(object arguments, object message, [CallerMemberName] string caller = "")
            {
                --step;
                Console.WriteLine(CraftMessage($"{caller}({arguments}) = {message}"));
            }
            public void SetNewLoop()
            {
                loopCount = 0;
            }
            public void PrintLoop(object message)
            {
                Console.WriteLine(CraftMessage($"{loopCount} 번째 루프 : {message}"));
                ++loopCount;
            }
            string CraftMessage(object message)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < step; ++i)
                    result.Append("|\t");
                result.Append($"{message.ToString()}");
                return result.ToString();
            }
        }

        static MyDebugger debug = new MyDebugger();
        static Stack<(int x, int y)> queenLocations;
        static int size;
        static int[,] board; // int는 해당 지역에 공격할 수 있는 퀸의 갯수
        // 다음 줄
        static (bool, int, int) TryFindNext(int x, int y)
        {
            if (y < 0 || y >= size) return (false, -1, -1);
            for (int xIndex = x + 1; xIndex < size; ++xIndex)
            {
                if (board[xIndex, y] == 0)
                    return (true, xIndex, y);
            }
            return (false, -1, -1);
        }

        // 가능하던 불가능하던 무조건 퀸을 올립니다.
        // 0.9
        static void PlaceQueen(int x, int y, [CallerLineNumber] int callerLineNum = 0)
        {
            //debug.EnterFunction($"PlaceQueen({x}, {y}) : 호출됨", lineNum: callerLineNum);

            queenLocations.Push((x, y));
            board[x, y] += 1;
            for (int i = 1; i < size; ++i)
            {
                if (IsInsideBoard(x - i, y - i))
                    board[x - i, y - i] += 1;
                if (IsInsideBoard(x - i, y + i)) board[x - i, y + i] += 1;
                if (IsInsideBoard(x + i, y - i)) board[x + i, y - i] += 1;
                if (IsInsideBoard(x + i, y + i)) board[x + i, y + i] += 1;
                if (IsInsideBoard(x - i, y)) board[x - i, y] += 1;
                if (IsInsideBoard(x + i, y)) board[x + i, y] += 1;
                if (IsInsideBoard(x, y - i)) board[x, y - i] += 1;
                if (IsInsideBoard(x, y + i)) board[x, y + i] += 1;
            }
            //debug.OutFunction($"{x}, {y}", "void");
        }
        // 0.9
        static void RemoveQueen()
        {
            (int x, int y) one = queenLocations.Pop();
            board[one.x, one.y]--;
            for (int i = 1; i < size; ++i)
            {
                if (IsInsideBoard(one.x - i, one.y - i)) board[one.x - i, one.y - i]--;
                if (IsInsideBoard(one.x - i, one.y + i)) board[one.x - i, one.y + i]--;
                if (IsInsideBoard(one.x + i, one.y - i)) board[one.x + i, one.y - i]--;
                if (IsInsideBoard(one.x + i, one.y + i)) board[one.x + i, one.y + i]--;
                if (IsInsideBoard(one.x - i, one.y)) board[one.x - i, one.y]--;
                if (IsInsideBoard(one.x + i, one.y)) board[one.x + i, one.y]--;
                if (IsInsideBoard(one.x, one.y - i)) board[one.x, one.y - i]--;
                if (IsInsideBoard(one.x, one.y + i)) board[one.x, one.y + i]--;
            }
            // 상하좌우 대각선으로 1을 제거합니다.
        }
        static bool IsInsideBoard(int x, int y)
        {
            if (x > size - 1 || x < 0) return false;
            if (y > size - 1 || y < 0) return false;
            return true;
        }
        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            board = new int[size, size];
            // 왼쪽 위에서부터 오른쪽 방향으로 하나씩 배치

            // def n번 퀸 설치
            // 만약 n + 1번 퀸의 위치를 찾은 경우 n + 1번째 퀸을 설치
            // 그렇지 못한 경우, 자신의 몸을 다음 위치를 찾고, n + 1번째 퀸의 위치를 찾음, 계속 반복,
            // 모두 찾지 못한 경우, 빠져나감

            // + 8번째 퀸에 도달한 경우 result += 1 연산을 진행하고,
            int result = 0;
            queenLocations = new Stack<(int, int)>(16); // 미리 reserve 해두자.
            PlaceQueen(0, 0);



            // 이전 루프의 결과 : 자신의 위치와
            // ㄴ이전 루프에서 다음 퀸의 자리를 찾음!
            // => 이전 루프에서 새로운 퀸을 배치하고 패스
            // ㄴ다음 퀸의 자리를 찾지 못함.
            // => 퀸을 뺀다. 그리고 흔적을 남긴다.
            // => 다음 루프에서 무조건 자신의 다음 자리를 찾는다.(사이즈와 동일하면 리절트 값 추가) 그렇지 않으면 퀸을 빼는걸 반복한다. 찾는것도 실패했고, 현재 퀸이 가장 첫번째 퀸이면 루프를 중지한다.
            // 
            debug.SetNewLoop();

            bool isPrevExist = false;
            int prevX = -1;
            int prevY = -1;

            while (true)
            {
                if (queenLocations.Count == size) result++;
                //Console.WriteLine($"이번 퀸의 갯수 : {queenLocations.Count}");

                (int x, int y) one = (-1, 0);
                    
                if (isPrevExist)
                {
                    one = (prevX, prevY);
                    isPrevExist = false;
                }
                else
                {
                    one.y = queenLocations.Peek().y + 1;
                }
                (bool isFound, int x, int y) next = TryFindNext(one.x, one.y);
                
                if (next.isFound)
                {
                    PlaceQueen(next.x, next.y);
                }
                else
                {
                    if (queenLocations.Count == 0) break;
                    (int x, int y) lastQueen = queenLocations.Peek();
                    isPrevExist = true;
                    prevX = lastQueen.x;
                    prevY = lastQueen.y;
                    RemoveQueen();
                }
            }

            Console.WriteLine(result);


            return;
        }
    }
}
