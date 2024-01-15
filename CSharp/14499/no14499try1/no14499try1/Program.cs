using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no14499try1
{
    internal class Program
    {
        // 주사위의 상태를 저장하는 변수를 준비합니다.
        // 굴러감에 따라 주사위의 숫자가 변하는 회전을 구현할 필요가 있습니다

        // enum으로 할수도 있지만, 숫자를 변하는건 좀 덜 직관적이여서요.
        const int TO_EAST = 1;
        const int TO_WEST = 2;
        const int TO_NORTH = 3;
        const int TO_SOUTH = 4;

        class Dice
        {
            int[] side = new int[6];

            const int WEST = 0;
            const int EAST = 1;
            const int NORTH = 2;
            const int TOP = 3;
            const int SOUTH = 4;
            const int BOTTOM = 5;
            
            public int ChangeDice(int cellNum)
            {
                if (cellNum == 0)
                {
                    int result = side[BOTTOM];
                    //side[BOTTOM] = 0; // 이게 맞나?
                    return result;
                }

                side[BOTTOM] = cellNum;
                return 0;
            }

            public void SpinDice(int direction)
            {
                switch (direction)
                {
                    case TO_EAST: ShiftDiceSideRight(TOP, EAST, BOTTOM, WEST); break;
                    case TO_WEST: ShiftDiceSideRight(TOP, WEST, BOTTOM, EAST); break;
                    case TO_NORTH: ShiftDiceSideRight(TOP, NORTH, BOTTOM, SOUTH); break;
                    case TO_SOUTH: ShiftDiceSideRight(TOP, SOUTH, BOTTOM, NORTH); break;
                    default: break;
                }
            }
            public int GetTop() => side[TOP];
            public string ToString() =>
                $"현재 주사위의 상태:\n\t\t북쪽 : {side[NORTH]}\n서쪽 : {side[WEST]}, 위 : {side[TOP]}, 아래 : {side[BOTTOM]}, 동쪽 : {side[EAST]}\n\t\t남쪽 : {side[SOUTH]}";

            void ShiftDiceSideRight(int side1, int side2, int side3, int side4)
            {
                // side1를 side2의 위치에 올리는 등 각 숫자의 값을 이동시킵니다.

                int temp = side[side4];

                side[side4] = side[side3];
                side[side3] = side[side2];
                side[side2] = side[side1];
                side[side1] = temp;
            }
        }

        // current 값이 max 이하, min 이상인경우 true를 리턴합니다.
        static bool IsInside(int max, int min, int current)
        {
            if (current > max) return false;
            if (current < min) return false;
            return true;
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            string[] recvLineNMXYK = Console.ReadLine().Split(' ');
            int n = int.Parse(recvLineNMXYK[0]);
            int m = int.Parse(recvLineNMXYK[1]);
            int y = int.Parse(recvLineNMXYK[2]);
            int x = int.Parse(recvLineNMXYK[3]);
            int k = int.Parse(recvLineNMXYK[4]);
            Dice dice = new Dice();
            int[,] map = new int[m, n]; // 접근 : map[x, y]
            for (int indexY = 0; indexY < n; ++indexY)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                for (int indexX = 0; indexX < m; ++indexX)
                {
                    map[indexX, indexY] = int.Parse(recvLine[indexX]);
                }
            }

            string[] recvLineMove = Console.ReadLine().Split(' ');

            for (int index = 0; index < k; ++index)
            {
                int direction = int.Parse(recvLineMove[index]);
                int nextX = x;
                int nextY = y;
                string m_side = "";

                switch (direction)
                {
                    case TO_EAST: nextX++; m_side = "동쪽"; break;
                    case TO_WEST: nextX--; m_side = "서쪽"; break;
                    case TO_NORTH: nextY--; m_side = "북쪽"; break;
                    case TO_SOUTH: nextY++; m_side = "남쪽"; break;
                    default: Console.WriteLine("THIS IS ERROR"); break;
                }

                //Console.WriteLine();
                //Console.WriteLine($"DEBUG : ==== {index}번째 루프 ===");
                //Console.WriteLine($"DEBUG : {dice.ToString()}");
                //Console.WriteLine($"DEBUG : 현재 주사위가 다음의 이동 방향 : {m_side}");
                //Console.WriteLine($"DEBUG : 현재 맵의 모양");
                //for (int m_y = 0; m_y < n; ++m_y)
                //{
                //    for (int m_x = 0; m_x < m; ++m_x)
                //    {
                //        Console.Write($"{map[m_x, m_y]} ");
                //    }
                //    Console.WriteLine();
                //}
                //Console.WriteLine($"DEBUG : 현재 주사위({x}, {y})의 다음 움직임 = ({nextX}, {nextY})");
                

                // 범위를 벗어나는지 여부를 판단합니다.
                if (!IsInside(m - 1, 0, nextX))
                {
                    //Console.WriteLine("<!> 벗어납니다 <!>");
                    continue;
                }
                if (!IsInside(n - 1, 0, nextY))
                {
                    //Console.WriteLine("<!> 벗어납니다 <!>");
                    continue;
                }

                dice.SpinDice(direction);
                map[nextX, nextY] = dice.ChangeDice(map[nextX, nextY]);
                result.AppendLine(dice.GetTop().ToString());
                x = nextX;
                y = nextY;
            }

            Console.WriteLine(result);
        }
    }
}
