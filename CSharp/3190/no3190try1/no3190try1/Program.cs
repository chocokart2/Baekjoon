using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no3190try1
{
    internal class Program
    {
        class Debugger
        {
            const bool RELEASE = true;
            const bool DEBUG = false;

            static bool status = RELEASE;
            static int calledStack = 0;

            static public void FunctionCalled(string arguments, [CallerMemberName] string caller = "")
            {
                if (status) return;

                StringBuilder result = new StringBuilder();
                for (int i = 0; i < calledStack; ++i) result.Append("|\t");
                result.Append($"{caller}({arguments}) : 호출됨");
                Console.WriteLine(result);
                ++calledStack;
            }
            static public void FunctionEnd(string arguments, string funcResult = "", [CallerMemberName] string caller = "")
            {
                if (status) return;

                --calledStack;
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < calledStack; ++i) result.Append("|\t");
                if (funcResult.Length == 0) result.Append($"{caller}({arguments}) : 종료됨");
                else result.Append($"{caller}({arguments}) = {funcResult}");
                Console.WriteLine(result);
            }
        }


        struct Vector2
        {
            public int x;
            public int y;

            public Vector2(int _x, int _y)
            {
                this.x = _x;
                this.y = _y;
            }
            static public bool operator ==(Vector2 left, Vector2 right)
            {
                return (left.x == right.x) && (left.y == right.y);
            }
            static public bool operator !=(Vector2 left, Vector2 right)
            {
                return !(left == right);
            }
        }

        class SnakeQueue
        {
            readonly (int x, int y) VOID = (-1, -1);

            private (int x, int y)[] data = new (int, int)[103];
            private int headIndex = 0; // headIndex - 1이 가장 최근에 추기된 원소의 인덱스.
            private int tailIndex = 0; // tailIndex - 1이 가장 최근에 파괴된 원소의 인덱스. 이건 파괴될 원소의 인덱스

            public (int x, int y) Peek()
            {
                return (headIndex == tailIndex) ? VOID : data[GetPreviousIndex(headIndex)];
                // 삼항 연산자로 인하여 항상 배열에 인스턴스화한 원소가 있는 상태이며
                // headIndex는 가장 최근에 추가된 원소의 다음 인덱스이므로 IndexOutOfRange를 일으키지 않습니다.
            }
            public void Add((int x, int y) item)
            {
                Debugger.FunctionCalled($"({item.x}, {item.y})");

                data[headIndex] = item;
                // headIndex가 변하는 요인은 GetNextIndex의 호출입니다.
                // 하지만 GetNextIndex는 배열 data의 범위 내에 존재하도록 보장하므로
                // 이곳에서 IndexOutOfRange를 발생시키지 않습니다.
                headIndex = GetNextIndex(headIndex);
                Debugger.FunctionEnd($"({item.x}, {item.y})");
            }
            public (int, int) RemoveTail()
            {
                Debugger.FunctionCalled("");
                (int, int) result = (data[tailIndex].x, data[tailIndex].y);
                // tailIndex가 변하는 요인은 GetNextIndex의 호출입니다.
                // 하지만 GetNextIndex는 배열 data의 범위 내에 존재하도록 보장하므로
                // 이곳에서 IndexOutOfRange를 발생시키지 않습니다.
                data[tailIndex] = VOID;
                // tailIndex가 변하는 요인은 GetNextIndex의 호출입니다.
                // 하지만 GetNextIndex는 배열 data의 범위 내에 존재하도록 보장하므로
                // 이곳에서 IndexOutOfRange를 발생시키지 않습니다.
                tailIndex = GetNextIndex(tailIndex);
                Debugger.FunctionEnd("", $"({result.Item1}, {result.Item2})");
                return result;
            }
            public bool IsExist((int x, int y) item)
            {
                for (int index = tailIndex; index != headIndex; index = GetNextIndex(index))
                {
                    if (data[index].x == item.x && data[index].y == item.y)
                    // index는 tailIndex을 시작으로 하고, tailIndex를 포함하며 headIndex에 도달하기 전 까지의 값입니다.
                    // GetNextIndex에 의하여 항상 data의 범위 내부에 있으므로
                    // 이곳에서 IndexOutOfRange를 발생시키지 않습니다.
                    {
                        return true;
                    }
                }
                return false;
            }

            public void DEBUG_DrawSnake()
            {
                bool[,] map = new bool[size, size];

                for (int index = tailIndex; index != headIndex; index = GetNextIndex(index))
                {
                    if (data[index].x == -1) continue;
                    // index는 tailIndex을 시작으로 하고, tailIndex를 포함하며 headIndex에 도달하기 전 까지의 값입니다.
                    // GetNextIndex에 의하여 항상 data의 범위 내부에 있으므로
                    // 이곳에서 IndexOutOfRange를 발생시키지 않습니다.
                    map[data[index].x, data[index].y] = true;
                    // Debug 모드에서만 호출되는 함수이므로 RELEASE에서 IndexOutOfRange를 발생시키지 않습니다.
                }


                for (int i = 0; i < size + 2; ++i) Console.Write('#');
                Console.WriteLine();

                for (int indexY = 0; indexY < size; ++indexY)
                {
                    Console.Write('#');
                    for (int indexX = 0; indexX < size; ++indexX)
                    {
                        if (map[indexX, indexY]) Console.Write('O');
                        else Console.Write('.');
                    }
                    Console.WriteLine('#');
                }
                for (int i = 0; i < size + 2; ++i) Console.Write('#');
                Console.WriteLine();
            }

            private int GetNextIndex(int index)
                => (index < data.Length - 1) ? index + 1 : 0;
            private int GetPreviousIndex(int index)
                => (index == 0) ? data.Length - 1 : index - 1;
        }


        static readonly Vector2 NORTH = new Vector2(0, -1);
        static readonly Vector2 SOUTH = new Vector2(0, 1);
        static readonly Vector2 EAST = new Vector2(1, 0);
        static readonly Vector2 WEST = new Vector2(-1, 0);
        static readonly Vector2[] arrow = new Vector2[4] {NORTH, EAST, SOUTH, WEST};
        const int EMPTY = 0;
        const int SNAKE = 1;
        const int APPLE = 2;
        static int[,] tile; // [x,y] 으로 접근, 0은 빈칸, 1은 뱀, 2은 사과
        static int size;
        
        static (int x, int y) Next((int x, int y) position, Vector2 direction)
        {
            Debugger.FunctionCalled($"({position.x}, {position.y}), <Vector2> {{x = {direction.x}, y = {direction.y} }}");
            Debugger.FunctionEnd($"({position.x}, {position.y}), <Vector2> {{x = {direction.x}, y = {direction.y} }}"
                , $"({position.x + direction.x}, {position.y + direction.y})");
            return (position.x + direction.x, position.y + direction.y);
        }
        // 이 함수는 index가 size를 크기로 하는 배열의 인덱스로 사용될지 판정하며,
        // 이를 사용할 시 IndexOutOfRange를 발생시키지 않음을 보장할 수 있습니다.
        static bool IsAvailableIndex(int index) => index > -1 && index < size;
        static bool IsAvailableToMove((int x, int y) position)
        {
            Debugger.FunctionCalled($"({position.x}, {position.y})");
            if (! (IsAvailableIndex(position.x) && IsAvailableIndex(position.y)))
            {
                Debugger.FunctionEnd($"({position.x}, {position.y})", "false");
                return false;
            }
            Debugger.FunctionEnd($"({position.x}, {position.y})", (tile[position.x, position.y] == APPLE || tile[position.x, position.y] == EMPTY).ToString());
            // if문의 특성 상 이곳에서는 IsAvailableIndex(position.x)와, IsAvailableIndex(position.y)가 모두 true입니다.
            // 따라서 각 차원의 크기가 size인 2차원 배열 tile에서 사용할 수 있는 인덱스이므로
            // 여기서  IndexOutOfRange를 발생시키지 않습니다.
            return tile[position.x, position.y] == APPLE || tile[position.x, position.y] == EMPTY;
            // if문의 특성 상 이곳에서는 IsAvailableIndex(position.x)와, IsAvailableIndex(position.y)가 모두 true입니다.
            // 따라서 각 차원의 크기가 size인 2차원 배열 tile에서 사용할 수 있는 인덱스이므로
            // 여기서  IndexOutOfRange를 발생시키지 않습니다.
        }
        static void DrawMap()
        {
            StringBuilder paint = new StringBuilder();

            for (int i = 0; i < size + 2; ++i) paint.Append('#');
            paint.Append('\n');
            for (int y = 0; y < size; ++y)
            {
                paint.Append('#');
                for (int x = 0; x < size; ++x)
                {
                    string c = "";
                    switch (tile[x, y])
                    // x와 y는 0부터 시작하여 tile의 각 차원의 마지막 인덱스인 size - 1까지 이어집니다.
                    // 따라서 여기서 IndexOutOfRange를 발생시키지 않습니다.
                    {
                        case 0: c = "."; break;
                        case 1: c = "O"; break;
                        case 2: c = "$"; break;
                        default: break;
                    }
                    paint.Append(c);
                }
                paint.Append('#');
                paint.Append('\n');
            }
            for (int i = 0; i < size + 2; ++i) paint.Append('#');
            paint.Append('\n');
            Console.WriteLine(paint);
        }
        // Queue에는 머리와 몸통에 대한 정보를 가지고 있다. 가장 최근에 들어온 원소는 뱀의 머리이며, 그 뒤 원소들은 뱀의 꼬리이자
        // ㄴ Queue는 배열을 사용하되, 원형 배열을 사용한다. 즉 인덱스가 배열의 끝에 다다르면, 0으로 바뀝니다.
        // ㄴ Queue의 길이는 1(초기 뱀 길이) + 100(사과의 최대 개수)개 + 2(구현상 여유 공간)로 구성된다
        static void Main(string[] args)
        {
            int result = 0;

            size = int.Parse(Console.ReadLine());
            tile = new int[size, size];
            int appleCount = int.Parse(Console.ReadLine());
            int directionCount;
            (int x, int y) headPosition;
            Vector2 direction;
            (int second, char direction)[] movePlan;
            SnakeQueue queue = new SnakeQueue();

            for (int i = 0; i < appleCount; ++i)
            {
                string[] position = Console.ReadLine().Split(' ');
                tile[int.Parse(position[1]) - 1, int.Parse(position[0]) - 1] = APPLE;
                // 사과의 위치값은 세로 위치 값, 가로 위치 값이 주어집니다.
                // 위치 값은 인덱스 번호보다 1 큽니다.
                // 보드 바깥쪽에 사과를 배치하는 일은 없으므로 이곳에서 IndexOutOfRange를 발생시키지 않습니다.
            }

            // snake Init
            direction = EAST;
            queue.Add((0, 0));
            tile[0, 0] = SNAKE;
            // 문제의 입력 "첫째 줄에 보드의 크기 N이 주어진다. (2 ≤ N ≤ 100)"에 의해 tile의 각 차원의 크기는 최소 2 이상입니다
            // 따라서 여기서 IndexOutOfRange를 발생시키지 않습니다.
            headPosition = (0, 0);

            // 방향 정보 init
            movePlan = new (int second, char direction)[int.Parse(Console.ReadLine())];
            for (int index = 0; index < movePlan.Length; ++index)
            {
                string[] command = Console.ReadLine().Split(' ');

                movePlan[index] = (int.Parse(command[0]), command[1][0]);
                // 문제의 입력 "다음 줄에는 뱀의 방향 변환 횟수 L 이 주어진다. (1 ≤ L ≤ 100)
                // 다음 L개의 줄에는 뱀의 방향 변환 정보가 주어지는데"
                // 에서 movePlan은 크기가 L개인 배열이며, 이후에 이 루프는 L번만큼 반복되며
                // index의 값은 movePlan.Length - 1까지 변하므로 여기서 IndexOutOfRange를 발생시키지 않습니다.
            }

            while (IsAvailableToMove(Next(queue.Peek(), direction))) // 다음 스텝을 이어갈 수 있습니다.
            {
                result++;

                // 1.
                // 머리 방향으로 한 줄을 늘립니다.
                // 2.
                // 사과를 먹는지 체크합니다. => 사과를 먹지 않으면 꼬리를 뗍니다.
                // 3.
                // plan을 확인하여 회전할지를 판단합니다.
                // 만약 result == next의 번호이면 돕니다

                // 머리 방향으로 한 줄 늘리기
                // 이동 : 타일도 변경 + 큐도 변경
                queue.Add(Next(queue.Peek(), direction));
                //tile[queue.Peek().x, queue.Peek().y] = SNAKE;

                // 2번
                if (queue.Peek().x == -1 || queue.Peek().y == -1) throw new ArgumentNullException();
                if (tile[queue.Peek().x, queue.Peek().y] == EMPTY) // 사과가 아니므로 한칸 줄여야 합니다.
                // === IndexOutOfRange ===
                // queue의 원소는 tile에 유효한 위치값인 (0,0)이거나
                // Next(queue.Peek(), direction))가 들어갈 수 있는데,
                // 여기서는 while의 문 특성상 IsAvailableToMove(Next(queue.Peek(), direction)) == true입니다.
                // IsAvailableToMove는 해당 위치가 보드 안쪽의 사과나 빈칸이 있음을 보장합니다.
                // 또한 queue의 원소의 크기는 while 문 이전에 1로 되어 있고,
                // while문 내부에서 queue의 원소를 제거하는 함수 RemoveTail함수는 최대 1회 호출되며,
                // RemoveTail함수가 호출 되기 이전에 while루프 내부 1회에는 항상 queue.Add 함수가 호출되므로,
                // queue.Peek()에서 queue.VOID가 리턴되는 일은 전혀 없습니다.
                {
                    (int x, int y) removed = queue.RemoveTail();
                    tile[removed.x, removed.y] = EMPTY;
                    // queue의 원소는 tile에 유효한 위치값인 (0,0)이거나
                    // queue의 원소의 크기는 while 문 이전에 1로 되어 있고,
                    // while문 내부에서 queue의 원소를 제거하는 함수 RemoveTail함수는 최대 1회 호출되며,
                    // RemoveTail함수가 호출 되기 이전에 while루프 내부 1회에는 항상 queue.Add 함수가 호출되므로,
                    // queue.Peek()에서 쓰레기 값이 리턴되는 일은 전혀 없습니다.

                }

                // 3번 : 회전
                for (int index = 0; index < movePlan.Length; ++index)
                {
                    if (result > movePlan[index].second) continue;
                    // index는 0부터 시작하여 movePlan의 Length - 1까지 이어집니다.
                    // 따라서 배열 범위 내부에 있으므로 IndexOutOfRange를 일으키지 않습니다.
                    if (result < movePlan[index].second) break;
                    // index는 0부터 시작하여 movePlan의 Length - 1까지 이어집니다.
                    // 따라서 배열 범위 내부에 있으므로 IndexOutOfRange를 일으키지 않습니다.

                    if (movePlan[index].direction == 'D') // 오른쪽
                        // index는 0부터 시작하여 movePlan의 Length - 1까지 이어집니다.
                        // 따라서 배열 범위 내부에 있으므로 IndexOutOfRange를 일으키지 않습니다.
                    {
                        if (direction == NORTH) direction = EAST;
                        else if (direction == EAST) direction = SOUTH;
                        else if (direction == SOUTH) direction = WEST;
                        else if (direction == WEST) direction = NORTH;
                    }
                    else // 완쪽
                    {
                        if (direction == NORTH) direction = WEST;
                        else if (direction == EAST) direction = NORTH;
                        else if (direction == SOUTH) direction = EAST;
                        else if (direction == WEST) direction = SOUTH;
                    }
                }
                if (queue.Peek().x == -1 || queue.Peek().y == -1) throw new ArgumentNullException();
                tile[queue.Peek().x, queue.Peek().y] = SNAKE; // 1번
                // IsAvailableToMove(Next(queue.Peek(), direction))가 호출되었고 true이며,
                // queue.Add(Next(queue.Peek(), direction));가 호출되었으므로
                // IsAvailableToMove(queue.Peek())은 true 값입니다.
                //


                //Console.WriteLine();
                //Console.WriteLine($"뱀의 상태 : 스탭 = {result}");
                //queue.DEBUG_DrawSnake();
                //DrawMap();
            }
            ++result;
            Console.WriteLine(result);
        }
    }
}
