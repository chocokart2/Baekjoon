using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no16462try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float count = int.Parse(Console.ReadLine());
            float[] scores = new float[(int)count];
            float sum = 0;

            for (int i = 0; i < count; ++i)
            {
                string one = Console.ReadLine();
                StringBuilder newOne = new StringBuilder();
                for (int index = 0; index < one.Length; ++index)
                {
                    newOne.Append((one[index] == '0' || one[index] == '6') ? '9' : one[index]);
                }

                float oneScore = float.Parse(newOne.ToString());
                if (oneScore > 100) oneScore = 100;
                scores[i] = oneScore;
                sum += oneScore;
            }

            float maxTerm = 10000;
            float result = 0;

            for (int index = 0; index < count; ++index)
            {
                float oneTerm = Math.Abs(scores[index] - (sum / count));
                if (maxTerm > oneTerm)
                {
                    maxTerm = oneTerm;
                    result = scores[index];
                }
            }

            Console.WriteLine(((sum / count) - Math.Truncate(sum / count) == 0.5f) ? Math.Ceiling(sum / count) : Math.Round(sum / count));
        }
    }
}
