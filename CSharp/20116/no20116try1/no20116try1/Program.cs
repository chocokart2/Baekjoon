using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no20116try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double size = double.Parse(Console.ReadLine().Split(' ')[1]);
            string[] strPositions = Console.ReadLine().Split(' ');
            double sum = 0;
            double boxCount = 0;

            for (int index = strPositions.Length - 1; index >= 0; index--)
            {
                double one = double.Parse(strPositions[index]);
                if (boxCount > 0)
                {
                    if (one + size <= sum / boxCount ||
                        one - size >= sum / boxCount)
                    {
                        Console.WriteLine("unstable");
                        return;
                    }
                }

                sum += one;
                boxCount += 1.0f;
            }

            Console.WriteLine("stable");
            //STICKING OUT YOUR GYATT FOR NERIZZLER
            //YOU'RE SO BAU BAU
            //YOU'RE SO BIBOO TAX
            //I JUST WANNA BE YOUR SHIORI

        }
    }
}
