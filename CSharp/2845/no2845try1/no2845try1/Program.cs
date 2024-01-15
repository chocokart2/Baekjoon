using System;

namespace no2845try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLineLP = Console.ReadLine().Split(' ');
            int people = int.Parse(recvLineLP[0]) * int.Parse(recvLineLP[1]);
            string[] recvLineArticle = Console.ReadLine().Split(' ');
            Console.WriteLine($"{int.Parse(recvLineArticle[0]) - people} {int.Parse(recvLineArticle[1]) - people} {int.Parse(recvLineArticle[2]) - people} {int.Parse(recvLineArticle[3]) - people} {int.Parse(recvLineArticle[4]) - people}");
        }
    }
}
