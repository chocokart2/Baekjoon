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
            string[] lineCountScore = Console.ReadLine().Split(' ', '.');

            int count = int.Parse(lineCountScore[0]);
            int limitScore = int.Parse(lineCountScore[1]) * 100 + int.Parse(lineCountScore[2]);
            int sumScores = 0;
            int sumCredit = 0; // limitScore에 사용
            int emptyCredit = 0;
            

            for (int i = 0; i < count; ++i)
            {
                string[] one = Console.ReadLine().Split(' ');
                int oneCredit = int.Parse(one[0]);
                sumCredit += oneCredit;

                if (one.Length < 2)
                {
                    emptyCredit = oneCredit;
                    continue;
                }

                int oneScore = 0;

                switch (one[1])
                {
                    case "A+": oneScore = 450; break;
                    case "A0": oneScore = 400; break;
                    case "B+": oneScore = 350; break;
                    case "B0": oneScore = 300; break;
                    case "C+": oneScore = 250; break;
                    case "C0": oneScore = 200; break;
                    case "D+": oneScore = 150; break;
                    case "D0": oneScore = 100; break;
                    default:
                        break;
                }

                sumScores += oneCredit * oneScore;
            }
            int GetScore(int point)
            {
                return (sumScores + point * emptyCredit) / sumCredit;
            } 


            if (limitScore < GetScore(0)) Console.WriteLine("F");
            else if (limitScore < GetScore(100)) Console.WriteLine("D0");
            else if (limitScore < GetScore(150)) Console.WriteLine("D+");
            else if (limitScore < GetScore(200)) Console.WriteLine("C0");
            else if (limitScore < GetScore(250)) Console.WriteLine("C+");
            else if (limitScore < GetScore(300)) Console.WriteLine("B0");
            else if (limitScore < GetScore(350)) Console.WriteLine("B+");
            else if (limitScore < GetScore(400)) Console.WriteLine("A0");
            else if (limitScore < GetScore(450)) Console.WriteLine("A+");
            else Console.WriteLine("impossible");
            
        }
    }
}
