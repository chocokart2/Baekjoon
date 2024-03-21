using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1063try1
{
    internal class Program
    {
        class Vector2
        {
            public int x;
            public int y;

            public Vector2() { }
            public Vector2(int _x, int _y) { x = _x; y = _y; }
            public Vector2(Vector2 origin) { x = origin.x; y = origin.y; }

            public bool IsSame(Vector2 other)
            {
                return (x == other.x) && (y == other.y);
            }
            public bool IsOut()
            {
                return x < 0 || x > 7 || y < 0 || y > 7;
            }
            public override string ToString()
            {
                return $"{(char)('A' + x)}{y + 1}";
            }
            public static Vector2 operator+(Vector2 left, Vector2 right)
            {
                return new Vector2(left.x + right.x, left.y + right.y);
            }
        }

        static void Main(string[] args)
        {
            string[] start = Console.ReadLine().Split(' ');
            Vector2 king = new Vector2(start[0][0] - 'A', start[0][1] - '1');
            Vector2 pawn = new Vector2(start[1][0] - 'A', start[1][1] - '1');

            Dictionary<string, Vector2> str2Delta = new Dictionary<string, Vector2>()
            {
                { "R", new Vector2(1, 0) },
                { "L", new Vector2(-1, 0) },
                { "B", new Vector2(0, -1) },
                { "T", new Vector2(0, 1) },
                { "RT", new Vector2(1, 1) },
                { "LT", new Vector2(-1, 1) },
                { "RB", new Vector2(1, -1) },
                { "LB", new Vector2(-1, -1) }
            };

            for (int i = int.Parse(start[2]); i > 0; --i)
            {
                Vector2 delta = str2Delta[Console.ReadLine()];
                Vector2 tempNewKing = king + delta;
                Vector2 tempNewPawn = new Vector2(pawn);
                if (tempNewKing.IsSame(pawn))
                {
                    tempNewPawn += delta;
                }

                if (tempNewKing.IsOut() || tempNewPawn.IsOut()) continue;
                king = tempNewKing;
                pawn = tempNewPawn;
            }

            Console.WriteLine(king);
            Console.WriteLine(pawn);
        }
    }
}
