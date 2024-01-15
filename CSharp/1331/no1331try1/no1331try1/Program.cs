using System;

namespace no1331try1
{
    internal class Program
    {
        static bool IsVaild((int, int) from, (int, int) to)
        {
            return Math.Abs(from.Item1 - to.Item1) * Math.Abs(from.Item2 - to.Item2) == 2;
        }

        static (int, int) GetPos(string pos) => (pos[0] - 'A' + 1, int.Parse(pos[1].ToString()));

        static bool[,] board = new bool[6, 6];

        static void Main(string[] args)
        {
            bool result = true;

            (int, int) pos = GetPos(Console.ReadLine());
            (int, int) start = (pos.Item1, pos.Item2);
            board[pos.Item1 - 1, pos.Item2 - 1] = true;
            
            for (int i = 0; i < 35; ++i)
            {
                (int, int) next = GetPos(Console.ReadLine());
                if (board[next.Item1 - 1, next.Item2 - 1])
                {
                    result = false;
                    break;
                }
                board[next.Item1 - 1, next.Item2 - 1] = true;

                //for (int index1 = 0; index1 < 6; ++index1)
                //{
                //    for (int index2 = 0; index2 < 6; ++index2)
                //    {
                //        if (index1 == (next.Item1 - 1) && index2 == (next.Item2 - 1))
                //            Console.Write("===\t");
                //        else if (board[index1, index2]) Console.Write("_O_\t");
                //        else Console.Write("XXX\t");
                //    }
                //    Console.Write("\n");
                //}
                //Console.Write("\n");

                if (IsVaild(pos, next) == false)
                {
                    result = false;
                    break;
                }
                pos = next;
            }

            for (int index1 = 0; index1 < 6; ++index1)
            {
                for (int index2 = 0; index2 < 6; ++index2)
                {
                    result = result && board[index1, index2];
                }
            }
            result &= IsVaild(pos, start);

            Console.WriteLine(result ? "Valid" : "Invalid");
        }
    }
}
