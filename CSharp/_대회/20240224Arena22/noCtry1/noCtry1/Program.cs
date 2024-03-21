using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noCtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // https://www.youtube.com/watch?v=vgZjV-tr98M

            // 동적 계획법
            // 첫번째
            // 이거 냅색 문제 아닌가? 첫번째는 초101, 두번째는 스피드(50 * 100 + 1), 원소는 최대양의 당근값.
            
            string[] recvLineNK = Console.ReadLine().Split(' ');
            int N = int.Parse(recvLineNK[0]);
            int maxTime = int.Parse(recvLineNK[1]);
            int?[,] carrots = new int?[maxTime + 1, 50 * (maxTime + 1)];
            carrots[0, 1] = 0;
            int[] cost = new int[N];
            int[] speedUp = new int[N];

            for (int index = 0; index < N; ++index)
            {
                string[] one = Console.ReadLine().Split(' ');

                cost[index] = int.Parse(one[0]);
                speedUp[index] = int.Parse(one[1]);
            }

            for (int time = 0; time < maxTime; ++time)
            {
                for (int speed = 1; speed < 50 * (maxTime + 1); ++speed)
                {
                    if (carrots[time, speed] == null) continue;
                    carrots[time + 1, speed] = carrots[time, speed].Value + speed;

                    for (int index = 0; index < N; ++index)
                    {
                        if (cost[index] > carrots[time, speed].Value) continue;

                        if (carrots[time + 1, speed + speedUp[index]] == null)
                        {
                            carrots[time + 1, speed + speedUp[index]] = carrots[time, speed] - cost[index];
                        }
                        else if (carrots[time + 1, speed + speedUp[index]] < carrots[time, speed] - cost[index])
                        {
                            carrots[time + 1, speed + speedUp[index]] = carrots[time, speed] - cost[index];
                        }
                    }

                }
            }


            int result = 0;
            for (int i = 0; i < 50 * (maxTime + 1); ++i)
            {
                if (carrots[maxTime, i] == null) continue;
                if (result < carrots[maxTime, i]) result = carrots[maxTime, i].Value;
            }
            Console.WriteLine(result);
        }
    }
}
