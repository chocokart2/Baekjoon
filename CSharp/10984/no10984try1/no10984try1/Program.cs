using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10984try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://www.youtube.com/watch?v=9sAZE165L_I

            for (int t = int.Parse(Console.ReadLine()); t > 0; t--)
            {
                float sum = 0;
                float GpaSum = 0.0f;
                
                for (int i = int.Parse(Console.ReadLine()); i > 0; i--)
                {
                    string[] recvLine = Console.ReadLine().Split(' ');
                    float point = float.Parse(recvLine[0]);
                    float score = float.Parse(recvLine[1]);

                    sum += point;
                    GpaSum += point * score;
                }

                Console.WriteLine($"{sum} {GpaSum / sum}");
            }


        }
    }
}
