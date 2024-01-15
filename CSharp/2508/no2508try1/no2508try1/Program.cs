using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace no2508try1
{
    internal class Program
    {
        static int GetValue()
        {
            Console.ReadLine();

            int result = 0;

            string[] sizeNum = Console.ReadLine().Split(' ');

            int sizeX = int.Parse(sizeNum[1]);
            int sizeY = int.Parse(sizeNum[0]);

            char[,] map = new char[sizeX, sizeY];
            for (int y = 0; y < sizeY; ++y)
            {
                string recvLine = Console.ReadLine();
                for (int x = 0; x < sizeX; ++x)
                {
                    map[x, y] = recvLine[x];

                    if (x > 1)
                    {
                        if (map[x, y] == '<' &&
                            map[x - 1, y] == 'o' &&
                            map[x - 2, y] == '>')
                            result++;
                    }
                    if (y > 1)
                    {
                        if (map[x, y] == '^' &&
                            map[x, y - 1] == 'o' &&
                            map[x, y - 2] == 'v')
                            result++;
                    }
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < count; ++i)
            {
                result.AppendLine(GetValue().ToString());
            }

            Console.Write(result);
        }
    }
}
