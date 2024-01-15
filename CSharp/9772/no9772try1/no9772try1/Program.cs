using System;

namespace no9772try1
{
    internal class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                float x = float.Parse(recvLine[0]);
                float y = float.Parse(recvLine[1]);

                if (x == 0 || y == 0) Console.WriteLine("AXIS");
                else if (x > 0)
                {
                    if (y > 0) Console.WriteLine("Q1");
                    else Console.WriteLine("Q4");
                }
                else
                {
                    if (y > 0) Console.WriteLine("Q2");
                    else Console.WriteLine("Q3");
                }

                if (x == 0 && y == 0) break;
            }
        }
    }
}
