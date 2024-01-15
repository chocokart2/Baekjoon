using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1546try1
{
    internal class Program
    {
        static float ChangeScore(float score, float max) => score / max * 100;

        static void Main(string[] args)
        {
            Console.ReadLine();
            string[] numString = Console.ReadLine().Split(' ');
            float[] scores = new float[numString.Length];
            float max = 0f;
            float result = 0f;
            for (int index = 0; index < numString.Length; ++index)
            {
                scores[index] = float.Parse(numString[index]);

                if (max < scores[index]) max = scores[index];
            }

            for (int index = 0; index < scores.Length; ++index)
                result += ChangeScore(scores[index], max);

            Console.WriteLine($"{(float)(result / scores.Length)}");
        }
    }
}
