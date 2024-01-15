using System;

namespace no5086try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] numStr = Console.ReadLine().Split(' ');
                if (numStr[0].Equals("0")) break;
                int[] number = new int[] { int.Parse(numStr[0]), int.Parse(numStr[1]) };

                if (number[1] % number[0] == 0) Console.WriteLine("factor");
                else if (number[0] % number[1] == 0) Console.WriteLine("multiple");
                else Console.WriteLine("neither");
            }
        }
    }
}
