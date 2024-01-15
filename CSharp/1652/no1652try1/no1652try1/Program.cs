using System;
namespace no1652try1
{
    internal class Program
    {
        static bool[,] room;

        static void Main(string[] args)
        {
            const bool FLOOR = false;
            const bool WALL = true;
            
            int horizontal = 0;
            int vertical = 0; // 세로로 눕기

            // init
            int size = int.Parse(Console.ReadLine());
            room = new bool[size, size]; // y, x로 접근해야 합니다.
            for (int line = 0; line < size; ++line)
            {
                string recvLine = Console.ReadLine();

                for (int index = 0; index < recvLine.Length; ++index)
                {
                    room[line, index] = recvLine[index].Equals('X');
                }
            }

            // x, y가 주어지면 [y,x]와 [y,x + 1]이 false이거나 [y,x]와 [y + 1,x]이 false인지를 판단해야 한다.


            // 그럼 가로줄을 체크할 때 가장 먼저 처음 하얀색이 나오는 곳에서 이후에 길이가 2인지를 판단하면 되겠네요.
            // 그렇다면 가로를 먼저 세고, 그 다음 세로를 셉니다. 가로 세로 따로따로 루프 돌려서 체크합니다.
            // 읽는 동시에 가로와 세로를 세려면
            // 가로 체크하기
            for (int y = 0; y < size; ++y)
            {
                bool foundFloor = false;
                for (int x = 0; x < size - 1; ++x)
                {
                    if (room[y, x] == FLOOR)
                    {
                        if (foundFloor == true) continue;
                        else
                        {
                            // 처음 발견한 바닥입니다. 따라서 연산 진행.
                            if (room[y, x + 1] == FLOOR)
                            {
                                foundFloor = true;
                                ++horizontal;
                            }
                        }
                    }
                    else
                    {
                        foundFloor = false;
                    }
                }
            }

            for (int x = 0; x < size; ++x)
            {
                bool foundFloor = false;
                for (int y = 0; y < size - 1; ++y)
                {
                    if (room[y, x] == FLOOR)
                    {
                        if (foundFloor == true) continue;
                        else
                        {
                            // 처음 발견한 바닥입니다. 따라서 연산 진행.
                            if (room[y + 1, x] == FLOOR)
                            {
                                foundFloor = true;
                                ++vertical;
                            }
                        }
                    }
                    else
                    {
                        foundFloor = false;
                    }
                }
            }

            Console.WriteLine($"{horizontal} {vertical}");
        }
    }
}
