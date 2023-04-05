using System;

namespace no10950try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for(int i = 0; i < count; ++i)
            {
                string[] stringNum = Console.ReadLine().Split(' ');
                Console.WriteLine(int.Parse(stringNum[0]) + int.Parse(stringNum[1]));
            }
        }
    }
}
