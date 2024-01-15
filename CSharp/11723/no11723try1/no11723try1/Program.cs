using System;
using System.Text;

namespace no11723try1
{
    internal class Program
    {
        static int bit = 0;

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; ++i)
            {
                string[] command = Console.ReadLine().Split(' ');
                switch (command[0])
                {
                    case "add":
                        bit |= (1 << (short.Parse(command[1]) - 1));
                        break;
                    case "remove":
                        bit &= ~(1 << (short.Parse(command[1]) - 1));
                        break;
                    case "check":
                        int a = 1 << short.Parse(command[1]) - 1;
                        string output = ((bit & a).Equals(a)) ? "1" : "0";
                        result.Append($"{output}\n");
                        break;
                    case "toggle":
                        bit = (bit & ~(1 << short.Parse(command[1]) - 1)) | (~bit & (1 << short.Parse(command[1]) - 1));
                        break;
                    case "all":
                        bit = 0b_0000_0000_0000_1111_1111_1111_1111_1111;
                        break;
                    case "empty":
                        bit = 0;
                        break;
                    default:
                        break;
                }
            }
            Console.Write(result);
        }
    }
}
