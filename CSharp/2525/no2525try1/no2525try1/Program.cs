using System;

namespace no2525try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rawTime = Console.ReadLine().Split(' ');
            int time = int.Parse(rawTime[0]) * 60 + int.Parse(rawTime[1]);
            time += int.Parse(Console.ReadLine());
            if (time >= 1440) time -= 1440;
            Console.WriteLine($"{time / 60} {time % 60}");
        }
    }
}
