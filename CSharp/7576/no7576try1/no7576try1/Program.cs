using System;

namespace no7576try1
{
    internal class Program
    {
        static int[,] box; // box[y,x]

        static (int x, int y, int day)[] queueData;
        static int queueRear = 0;
        static int queueHead = 0;

        static void Init()
        {
            string[] nums = Console.ReadLine().Split(' ');
            int[] size = { int.Parse(nums[0]), int.Parse(nums[1]) };
            box = new int[size[1], size[0]];
            queueData = new (int x, int y, int day)[1_000_000];

            for (int y = 0; y < size[1]; ++y)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                for (int x = 0; x < size[0]; ++x)
                {
                    if (recvLine[x].Equals("0")) box[y, x] = 0;
                    else if (recvLine[x].Equals("-1")) box[y, x] = -1;
                    else box[y, x] = 1;
                }
            }
        }
        static void Push(int x, int y, int day)
        {
            queueData[queueHead] = (x, y, day);
            ++queueHead;
        }
        static (int x, int y, int day) Pop()
        {
            if (queueHead - queueRear == 0) return (-1, -1, -1);

            (int, int, int) result = queueData[queueRear];
            ++queueRear;
            return result;

        }
        static bool IsVaildIndex(int x, int y) => (x < box.GetLength(1) && x > -1) && (y < box.GetLength(0) && y > -1);
        static bool IsGreenTomato(int x, int y)
        {
            if (!IsVaildIndex(x, y)) return false;
            return box[y, x] == 0;
        }

        static void Main(string[] args)
        {
            int result = 0;
            Init();

            for (int y = 0; y < box.GetLength(0); ++y)
            {
                for (int x = 0; x < box.GetLength(1);  ++x)
                {
                    if (box[y, x] == 1) Push(x, y, 0);
                }
            }

            while(queueHead - queueRear > 0)
            {
                (int x, int y, int day) pos = Pop();
                result = pos.day;
                if (IsGreenTomato(pos.x + 1, pos.y))
                {
                    box[pos.y, pos.x + 1] = 1;
                    Push(pos.x + 1, pos.y, pos.day + 1);
                }
                if (IsGreenTomato(pos.x - 1, pos.y))
                {
                    box[pos.y, pos.x - 1] = 1;
                    Push(pos.x - 1, pos.y, pos.day + 1);
                }
                if (IsGreenTomato(pos.x, pos.y + 1))
                {
                    box[pos.y + 1, pos.x] = 1;
                    Push(pos.x, pos.y + 1, pos.day + 1);
                }
                if (IsGreenTomato(pos.x, pos.y - 1))
                {
                    box[pos.y - 1, pos.x] = 1;
                    Push(pos.x, pos.y - 1, pos.day + 1);
                }
            }


            bool isFound = false;
            for (int y = 0; y < box.GetLength(0); ++y)
            {
                for (int x = 0; x < box.GetLength(1); ++x)
                {
                    if (box[y, x] == 0)
                    {
                        result = -1;
                        isFound = true;
                        break;
                    }
                }
                if (isFound) break;
            }

            Console.WriteLine(result);
        }
    }
}
