using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no28248try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int score = 0;
            int delevered = int.Parse(Console.ReadLine());
            int collided = int.Parse(Console.ReadLine());
            score = (delevered * 5 - collided) * 10;
            if (delevered > collided) score += 500;
            Console.WriteLine(score);
        }
    }
}
