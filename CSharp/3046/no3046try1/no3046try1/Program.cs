using System;

namespace no3046try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] receiveStrings = Console.ReadLine().Split(' ');
            Console.WriteLine(int.Parse(receiveStrings[1]) * 2 - int.Parse(receiveStrings[0]));
        }
    }
}
