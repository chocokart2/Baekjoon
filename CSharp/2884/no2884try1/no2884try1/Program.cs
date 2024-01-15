using System;

namespace no2884try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] time = { int.Parse(input[0]), int.Parse(input[1]) };

            if (time[1] < 45)
            {
                time[1] += 60;
                if (time[0] < 1) time[0] = 23;
                else --time[0];
            }
            time[1] -= 45;
            Console.WriteLine($"{time[0]} {time[1]}");
        }
    }
}
