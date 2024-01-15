using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1193try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int recvNum = int.Parse(Console.ReadLine());
            int level = 1; // level = 분자 + 분모 - 1;
            // 분자 = recvNum
            // 분모 = level - recvSum
            for (;recvNum > level; ++level)
            {
                recvNum -= level;
            }

            if (level % 2 == 0) Console.WriteLine($"{recvNum}/{level + 1 - recvNum}");
            else Console.WriteLine($"{level + 1 - recvNum}/{recvNum}");

        }
    }
}
