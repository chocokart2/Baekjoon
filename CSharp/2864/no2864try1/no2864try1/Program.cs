using System;
using System.Text;

namespace no2864try1
{
    internal class Program
    {
        // from를 발견하면 to로 변환합니다.
        static int GetNum(string target, char from, char to)
        {
            StringBuilder num = new StringBuilder();
            for (int index = 0; index < target.Length; ++index)
                num.Append((target[index] == from) ? to : target[index]);
            return int.Parse(num.ToString());
        }

        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            Console.WriteLine($"{GetNum(numbers[0], '6', '5') + GetNum(numbers[1], '6', '5')} {GetNum(numbers[0], '5', '6') + GetNum(numbers[1], '5', '6')}");
        }
    }
}
