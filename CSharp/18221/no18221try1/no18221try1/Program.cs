using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 뭐 이런 끔찍한 소리가 다 있답니까

namespace no18221try1
{
    internal class Program
    {
        static int[,] seat;
        static int size;
        static float studentKidnapperX;
        static float studentKidnapperY;
        static float kidnapVictimX;
        static float kidnapVictimY;

        static void Init()
        {
            size = int.Parse(Console.ReadLine());
            seat = new int[size, size];

            for (int y = 0; y < size; ++y)
            {
                string[] line = Console.ReadLine().Split(' ');

                for (int x = 0; x < size; ++x)
                {
                    seat[x, y] = int.Parse(line[x]);
                    if (seat[x, y] == 2)
                    {
                        kidnapVictimX = x;
                        kidnapVictimY = y;
                    }
                    if (seat[x,y] == 5)
                    {
                        studentKidnapperX = x;
                        studentKidnapperY = y;
                    }
                }
            }
        }

        static double GetDistanceSquare() =>
            Math.Pow(studentKidnapperX - kidnapVictimX, 2) + Math.Pow(studentKidnapperY - kidnapVictimY, 2);

        static bool IsEnoughHelper()
        {
            int count = 0;

            for (int x = (int)Math.Min(studentKidnapperX, kidnapVictimX); x <= (int)Math.Max(studentKidnapperX, kidnapVictimX); ++x)
            {
                for (int y = (int)Math.Min(studentKidnapperY, kidnapVictimY); y <= (int)Math.Max(studentKidnapperY, kidnapVictimY); ++y)
                {
                    if (seat[x,y] == 1)
                    {
                        count++;
                        if (count == 3) return true;
                    }
                }
            }
            return false;
        }


        static void Main(string[] args)
        {
            Init();
            Console.WriteLine($"{((IsEnoughHelper() && (GetDistanceSquare() >= 25)) ? "1" : "0")}");
        }
    }
}
