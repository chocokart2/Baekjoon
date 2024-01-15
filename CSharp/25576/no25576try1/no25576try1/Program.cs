using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no25576try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int RALPA = 0;
            string[] numNM = Console.ReadLine().Split(' ');
            int subscribe = int.Parse(numNM[0]);
            int time = int.Parse(numNM[1]);
            int[,] viewer = new int[subscribe, time];
            int dammedBasterdCount = 0;
            for (int index = 0; index < subscribe; ++index)
            {
                string[] oneStr = Console.ReadLine().Split(' ');
                for (int indexStat = 0; indexStat < time; ++indexStat)
                {
                    viewer[index, indexStat] = int.Parse(oneStr[indexStat]);
                }
                if (index > RALPA)
                {
                    int sum = 0;
                    for (int indexStat = 0; indexStat < time; ++indexStat)
                    {
                        sum += Math.Abs(viewer[RALPA, indexStat] - viewer[index, indexStat]);
                    }
                    if (sum > 2000) dammedBasterdCount++;
                }
            }
            if (subscribe - 1 <= dammedBasterdCount * 2)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
