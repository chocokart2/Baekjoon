using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no25494try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                int sum = 0;

                int a = int.Parse(recvLine[0]);
                int b = int.Parse(recvLine[1]);
                int c = int.Parse(recvLine[2]);

                for (int x = 1; x <= a; ++x)
                {
                    for (int y = 1; y <= b; ++y)
                    {
                        for (int z = 1; z <= c; ++z)
                        {
                            int modX = x % y;
                            int modY = y % z;
                            int modZ = z % x;

                            if (modX == modY && modY == modZ) sum++;
                        }
                    }
                }

                result.AppendLine($"{sum}");
            }

            Console.Write(result);
        }
    }
}
