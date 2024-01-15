using System;
// 누군진 잘 모르겠지만 치훈님은 공부를 열심히 하셨군요.

namespace no25206try1
{
    internal class Program
    {

        static double GetScore(string target)
        {
            if (target.Equals("A+")) return 4.5d;
            else if (target.Equals("A0")) return 4.0d;
            else if (target.Equals("B+")) return 3.5d;
            else if (target.Equals("B0")) return 3.0d;
            else if (target.Equals("C+")) return 2.5d;
            else if (target.Equals("C0")) return 2.0d;
            else if (target.Equals("D+")) return 1.5d;
            else if (target.Equals("D0")) return 1.0d;
            else if (target.Equals("F")) return 0.0d;
            else return -100.0d; // P
        }

        static void Main(string[] args)
        {
            double scoreSum = 0.0d; // (학점 * 전공평점) 의 합
            double creditSum = 0.0d; // 학점의 합 

            for (int i = 0; i < 20; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                double score = GetScore(recvLine[2]);
                if (score < 0.0d) continue; // if score is P

                double credit = double.Parse(recvLine[1]);

                scoreSum += credit * score; 
                creditSum += credit;
            }
            Console.WriteLine(scoreSum / creditSum);
        }
    }
}
