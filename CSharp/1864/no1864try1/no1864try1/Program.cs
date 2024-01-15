using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1864try1
{
    internal class Program
    {
        static int GetNum(char c)
        {
            switch (c)
            {
                case '-': return 0;
                case '\\': return 1;
                case '(': return 2;
                case '@': return 3;
                case '?': return 4;
                case '>': return 5;
                case '&': return 6;
                case '%': return 7;
                case '/': return -1;
                default: return int.MaxValue;
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                string num = Console.ReadLine();
                if (num[0] == '#') break;

                int value = 0;
                int a = 1;

                for (int index = num.Length - 1; index >= 0; --index)
                {
                    value += GetNum(num[index]) * a;
                    a *= 8;
                }
                Console.WriteLine(value);
            }
        }
    }
}
