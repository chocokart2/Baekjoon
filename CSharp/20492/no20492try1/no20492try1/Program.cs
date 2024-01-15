using System;

namespace no20492try1
{
    internal class Program
    {
        static int GetPersent(int num, int percent) => (num / 100) * percent;
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            Console.WriteLine($"{GetPersent(num, 78)} {GetPersent(num, 80) + GetPersent(GetPersent(num, 20), 78)}");
        }
    }
}
