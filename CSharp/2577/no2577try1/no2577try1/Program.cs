using System;

namespace no2577try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = 1;
            int[] digits = new int[10];
            for (int index = 0; index < 3; ++index)
            {
                number *= int.Parse(Console.ReadLine());
            }
            string numString = number.ToString();
            foreach(char c in number.ToString())
            {
                digits[int.Parse(c.ToString())]++;
            }
            for (int index = 0; index < 10; ++index)
            {
                Console.WriteLine(digits[index]);
            }
        }
    }
}
