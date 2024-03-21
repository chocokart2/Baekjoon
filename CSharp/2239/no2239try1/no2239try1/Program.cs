using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace no2239try1
{
    internal class Program
    {
        const bool IS_DEBUGGING = false;

        public struct Position
        {
            public int x;
            public int y;
        }

        static int[,] nums = new int[9, 9];
        static List<Position> slots = new List<Position>();
        
        static string GetString()
        {
            StringBuilder result = new StringBuilder();

            for (int y = 0; y < 9; ++y)
            {
                for (int x = 0; x < 9; ++x)
                {
                    result.Append(nums[x, y]);
                }
                result.Append('\n');
            }
            return result.ToString();
        }
        static bool CheckSudoku(Position point)
        {

            bool[] isExistRow = new bool[9]; // 가로 체크
            bool[] isExistColumn = new bool[9]; // 세로 체크
            bool[] isExistBox = new bool[9];
            for (int i = 0; i < 9; ++i)
            {
                if (nums[i, point.y] > 0)
                {
                    if (isExistRow[nums[i, point.y] - 1])
                    {
                        if (IS_DEBUGGING)
                        {
                            Console.WriteLine("실패! 가로 줄 중복입니다.");
                        }
                        return false;
                    }
                    isExistRow[nums[i, point.y] - 1] = true;
                }
                if (nums[point.x, i] > 0)
                {
                    if (isExistColumn[nums[point.x, i] - 1])
                    {
                        if (IS_DEBUGGING)
                        {
                            Console.WriteLine("실패! 세로 줄 중복입니다.");
                        }
                        return false;
                    }
                    isExistColumn[nums[point.x, i] - 1] = true;
                }
            }
            for (int x = 0; x < 3; ++x)
            {
                for (int y = 0; y < 3; ++y)
                {
                    int one = nums[(point.x / 3) * 3 + x, (point.y / 3) *3 + y];
                    if (one > 0)
                    {
                        if (isExistBox[one - 1])
                        {
                            if (IS_DEBUGGING)
                            {
                                Console.WriteLine($"실패! 상자 칸 중복입니다. : ({(point.x / 3) * 3 + x}, {(point.y / 3) * 3 + y})");
                            }
                            return false;
                        }
                        isExistBox[one - 1] = true;
                    }
                }
            }
            if (IS_DEBUGGING)
            {
                Console.WriteLine("OKOKOKOKOK");
            }
            return true;
        }
        static bool IsCouldPlaceRecursive(int index, int number)
        {
            if (IS_DEBUGGING)
            {
                Console.WriteLine($"index = {index}, number = {number}");
                Console.WriteLine(GetString());
            }
            if (index == slots.Count) return true;

            nums[slots[index].x, slots[index].y] = number;
            if (CheckSudoku(slots[index]) == false)
            {
                nums[slots[index].x, slots[index].y] = 0;
                return false;
            }

            // 다음 숫자를 넣어보자
            for (int nextNumber = 1; nextNumber < 10; ++nextNumber)
            {
                if (IsCouldPlaceRecursive(index + 1, nextNumber)) return true;
            }
            nums[slots[index].x, slots[index].y] = 0;
            return false;
        }

        static void Main(string[] args)
        {
            for (int posY = 0; posY < 9; ++posY)
            {
                string numbers = Console.ReadLine();
                for (int posX = 0; posX < 9; ++posX)
                {
                    nums[posX, posY] = numbers[posX] - '0';
                    if (nums[posX, posY] == 0)
                    {
                        slots.Add(new Position()
                        {
                            x = posX,
                            y = posY
                        });
                    }
                }
            }
            if (IS_DEBUGGING)
            {
                Console.WriteLine($"빈칸 갯수 : {slots.Count}");
            }
            for (int nextNumber = 1; nextNumber < 10; ++nextNumber)
            {
                if (IsCouldPlaceRecursive(0, nextNumber))
                {
                    Console.WriteLine(GetString());
                    return;
                }
            }
            if (IS_DEBUGGING)
            {
                Console.WriteLine("탐색 실패!");
            }
        }
    }
}
