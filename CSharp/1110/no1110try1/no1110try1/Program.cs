using System;

namespace no1110try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int currentNum = num;
            int result = 0;

            do
            {
                int sum = (currentNum / 10) + (currentNum % 10);
                currentNum = (sum % 10) + (currentNum % 10) * 10;
                ++result;
            }
            while (currentNum != num);

            Console.WriteLine(result);
        }
    }
}
