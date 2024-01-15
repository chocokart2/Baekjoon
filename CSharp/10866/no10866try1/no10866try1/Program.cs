using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10866try1
{
    internal class Program
    {
        static int[] data = new int[20_000];
        static int newRearPosition = 9_999;
        static int newFrontPosition = 10_000; // 최종

        static void AddFront(int num)
        {
            data[newFrontPosition] = num;
            ++newFrontPosition;
        }
        static void AddRear(int num)
        {
            data[newRearPosition] = num;
            --newRearPosition;
        }
        static int PopFront()
        {
            if (IsEmpty()) return -1;
            int result = data[newFrontPosition - 1];
            --newFrontPosition;
            return result;
        }
        static int PopRear()
        {
            if (IsEmpty()) return -1;
            int result = data[newRearPosition + 1];
            ++newRearPosition;
            return result;
        }
        static bool IsEmpty() => (newFrontPosition - newRearPosition - 1) == 0;
        static int GetSize() => newFrontPosition - newRearPosition - 1;
        static int GetFront() => (IsEmpty()) ? -1 : data[newFrontPosition - 1];
        static int GetRear() => (IsEmpty()) ? -1 : data[newRearPosition + 1];

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                string[] command = Console.ReadLine().Split(' ');

                switch (command[0])
                {
                    case "push_front":
                        AddFront(int.Parse(command[1]));
                        break;
                    case "push_back":
                        AddRear(int.Parse(command[1]));
                        break;
                    case "pop_front":
                        result.Append($"{PopFront()}\n");
                        break;
                    case "pop_back":
                        result.Append($"{PopRear()}\n");
                        break;
                    case "size":
                        result.Append($"{GetSize()}\n");
                        break;
                    case "empty":
                        result.Append(IsEmpty() ? "1\n" : "0\n");
                        break;
                    case "front":
                        result.Append($"{GetFront()}\n");
                        break;
                    case "back":
                        result.Append($"{GetRear()}\n");
                        break;
                    default:
                        break;
                }
            }

            Console.Write(result);
        }
    }
}
