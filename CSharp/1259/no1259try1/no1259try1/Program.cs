using System;

namespace no1259try1
{
    internal class Program
    {
        static bool IsPalindrome(string arg)
        {
            int half = arg.Length / 2;
            for(int index = 0; index < half; ++index)
            {
                if (arg[index].Equals(arg[arg.Length-1-index]) == false) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                string receiveLine = Console.ReadLine();
                if (receiveLine.Equals("0")) break;
                if (IsPalindrome(receiveLine)) Console.WriteLine("yes");
                else Console.WriteLine("no");
            }
        }
    }
}
