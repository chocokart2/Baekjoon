using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2751try1
{
    internal class Program
    {
        static StringBuilder result = new StringBuilder();
        static bool[] numbers = new bool[1_000_001];
        static bool[] minusNumbers = new bool[1_000_001];

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
            {
                int num = int.Parse(Console.ReadLine());
                if(num < 0) minusNumbers[-num] = true;
                else numbers[num] = true;
            }
            for (int index = minusNumbers.Length - 1; index > 0; --index)
            {
                if (minusNumbers[index]) result.Append($"{-index}\n");
            }
            Console.Write(result);
            result.Clear();
            for (int index = 0; index < numbers.Length; ++index)
            {
                if (numbers[index]) result.Append($"{index}\n");
            }
            Console.Write(result);
        }
    }
}
