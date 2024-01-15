using System;

namespace no3003try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] piece = Console.ReadLine().Split();
            Console.Write($"{1 - int.Parse(piece[0])}");
            Console.Write($" {1 - int.Parse(piece[1])}");
            Console.Write($" {2 - int.Parse(piece[2])}");
            Console.Write($" {2 - int.Parse(piece[3])}");
            Console.Write($" {2 - int.Parse(piece[4])}");
            Console.Write($" {8 - int.Parse(piece[5])}");

        }
    }
}
