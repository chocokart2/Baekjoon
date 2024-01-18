using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace no23821try1
{
    internal class Program
    {
        enum EDirection
        {
            north,
            south,
            east,
            west
        }

        // struct은 DeepCopy가 기본으로 탑재됩니다.
        struct Vector2
        {
            public int x;
            public int y;

            public Vector2(int _x, int _y)
            {
                x = _x;
                y = _y;
            }
        }
        struct Rectangle
        {
            public Vector2 leftUpPosition; // indexPosition
            public Vector2 size;
        }

        static Rectangle M_Expand(Rectangle rect, EDirection direction)
        {
            switch (direction)
            {
                case EDirection.north:
                    rect.size.y++;
                    rect.leftUpPosition.y--;
                    break;
                case EDirection.south:
                    rect.size.y++;
                    break;
                case EDirection.west:
                    rect.size.x++;
                    rect.leftUpPosition.x--;
                    break;
                case EDirection.east:
                    rect.size.x++;
                    break;
                default: throw new Exception();
            }
            return rect;
        }
        static Rectangle M_Move(Rectangle rect, EDirection direction)
        {
            switch (direction)
            {
                case EDirection.north:
                    rect.leftUpPosition.y--;
                    break;
                case EDirection.south:
                    rect.leftUpPosition.y++;
                    break;
                case EDirection.east:
                    rect.leftUpPosition.x++;
                    break;
                case EDirection.west:
                    rect.leftUpPosition.x--;
                    break;
                default: throw new Exception();
            }
            return rect;
        }

        static void Main(string[] args)
        {
            string[] size = Console.ReadLine().Split(' ');
            int sizeY = int.Parse(size[0]);
            int sizeX = int.Parse(size[1]);

            EDirection[] directions = { EDirection.north, EDirection.south, EDirection.east, EDirection.west };

            int[,] sumO = new int[sizeX + 1, sizeY + 1];
            bool[,] result = new bool[sizeX, sizeY];

            Vector2[] startArray = new Vector2[2500];
            int startArrayRear = 0;

            for (int y = 0; y < sizeY; y++)
            {
                string recvLine = Console.ReadLine();
                for (int x = 0; x < sizeX; x++)
                {
                    sumO[x + 1, y + 1] = sumO[x, y + 1] + sumO[x + 1, y] - sumO[x, y] + (recvLine[x] != 'X' ? 1 : 0);
                    if (recvLine[x] == 'A') startArray[startArrayRear++] = new Vector2(x, y);
                }
            }

            // 해당 직육면체가 X를 포함하는지를 리턴합니다.
            bool M_IsContainX(Rectangle rect)
            {
                return rect.size.x * rect.size.y != (
                    sumO[rect.leftUpPosition.x + rect.size.x, rect.leftUpPosition.y + rect.size.y]
                    + sumO[rect.leftUpPosition.x, rect.leftUpPosition.y]
                    - sumO[rect.leftUpPosition.x + rect.size.x, rect.leftUpPosition.y]
                    - sumO[rect.leftUpPosition.x, rect.leftUpPosition.y + rect.size.y]
                    );
            }
            bool M_IsInside(Rectangle rect)
            {
                if (rect.leftUpPosition.x < 0 || rect.leftUpPosition.y < 0) return true;
                if (rect.leftUpPosition.x + rect.size.x > sizeX || rect.leftUpPosition.y + rect.size.y > sizeY) return true;
                return false;
            }
            bool M_IsNotNew(Rectangle rect)
            {
                bool m_result = true;
                for (int m_x = 0; m_x < rect.size.x; m_x++)
                {
                    for (int m_y = 0; m_y < rect.size.y; m_y++)
                    {
                        m_result &= result[m_x + rect.leftUpPosition.x, m_y + rect.leftUpPosition.y];
                    }
                }
                return m_result;
            }

            // 각 A 지점에서 시작하여, 너비 우선 탐색을 진행합니다. 1번 -> X체크 -> 2번 -> X체크 -> result 수정 및 다음 스텝 등록을 반복합니다.
            for (int index = 0; index < startArrayRear; index++) // O(n)
            {
                // 한번 pop마다 16 (4 * 4)개의 경우의 수가 생성됩니다.

                Queue<Rectangle> nextSteps = new Queue<Rectangle>();
                nextSteps.Enqueue(
                    new Rectangle()
                    {
                        leftUpPosition = startArray[index],
                        size = new Vector2(1, 1)
                    });
                result[startArray[index].x, startArray[index].y] = true;

                // 팝
                while (nextSteps.Count > 0) // O(?)
                {
                    Rectangle current = nextSteps.Dequeue();
                    //Console.WriteLine($">> Current : (pos = ({current.leftUpPosition.x}, {current.leftUpPosition.y}), size = ({current.size.x}, {current.size.y}))");


                    // 4개 방향으로 1번 진행
                    // 내부 루프에서 4개 방향으로 2번 진행. 가능한 경우에 한해서만.
                    for (int actionFirstDirection = 0; actionFirstDirection < 4; actionFirstDirection++)
                    {
                        Rectangle expandedRect = M_Expand(current, directions[actionFirstDirection]);

                        if (M_IsInside(expandedRect)) continue;
                        if (M_IsContainX(expandedRect)) continue;

                        for (int actionSecondDirection = 0; actionSecondDirection < 4; actionSecondDirection++) // O(16)
                        {
                            Rectangle movedRect = M_Move(expandedRect, directions[actionSecondDirection]);

                            if (M_IsInside(movedRect)) continue;
                            if (M_IsContainX(movedRect)) continue;
                            
                            // 이지점 위까지는 오케이.
                            if (M_IsNotNew(movedRect))
                            {
                                continue;
                            }

                            // 이것을 주석처리했는데도 시간 초과가 발생했다. 그래프 탐색을 바꾸어야 하나?
                            for (int y = movedRect.leftUpPosition.y; y < movedRect.leftUpPosition.y + movedRect.size.y; y++)
                            {
                                for (int x = movedRect.leftUpPosition.x; x < movedRect.leftUpPosition.x + movedRect.size.x; x++)
                                {
                                    // 여기가 문제인것 같은데.
                                    result[x, y] = true;
                                }
                            }
                            nextSteps.Enqueue(movedRect);
                        }
                    }

                }

            }

            //throw new OverflowException()

            StringBuilder printResult = new StringBuilder();

            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    printResult.Append(result[x, y] ? 'Y' : 'N');
                }
                printResult.Append('\n');
            }

            Console.Write(printResult);
        }
    }
}
