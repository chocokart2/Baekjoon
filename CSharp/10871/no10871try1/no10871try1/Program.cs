using System;
using System.Text;

namespace no10871try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string[] strings = Console.ReadLine().Split(' ');
            int target = int.Parse(strings[1]);
            string[] numbers = Console.ReadLine().Split(' ');

            for (int index = 0; index < numbers.Length; ++index)
            {
                int value = int.Parse(numbers[index]);
                if (value >= target) continue;
                if (result.Length < 1) result.Append(numbers[index]);
                else result.Append($" {numbers[index]}");
            }
            Console.WriteLine(result);
        }
    }
}
