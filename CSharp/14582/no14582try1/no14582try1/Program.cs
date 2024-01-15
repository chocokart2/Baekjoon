using System;

namespace no14582try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ScoreDiffer = 0;
            string[] playerScores = Console.ReadLine().Split(' ');
            string[] opponentScores = Console.ReadLine().Split(' ');
            for(int index = 0; index < 9; ++index)
            {
                ScoreDiffer += int.Parse(playerScores[index]);
                if(ScoreDiffer > 0)
                {
                    Console.WriteLine("Yes");
                    return;
                }
                ScoreDiffer -= int.Parse(opponentScores[index]);
            }
            Console.WriteLine("No");
            return;
        }
    }
}
