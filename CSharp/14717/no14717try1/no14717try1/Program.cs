using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace no14717try1
{
    internal class Program
    {
        static int GetScore(int cardA, int cardB)
        {
            if (cardA == cardB)
            {
                switch (cardA)
                {
                    case 10: return 19;
                    case 9: return 18;
                    case 8: return 17;
                    case 7: return 16;
                    case 6: return 15;
                    case 5: return 14;
                    case 4: return 13;
                    case 3: return 12;
                    case 2: return 11;
                    case 1: return 10;
                    default: return int.MaxValue;
                }
            }
            else
            {
                return (cardA + cardB) % 10;
            }
        }

        static void Main(string[] args)
        {
            const int NOT_EXIST = -1;

            int[] numCards = new int[20]; // 1 1 2 2 3 3 ... / not exist => -1
            for (int index = 0; index < 10; ++index)
            {
                numCards[index * 2] = index + 1;
                numCards[index * 2 + 1] = index + 1;
            }


            int myScore;
            int myWinningCase = 0;
            int enemyCardCase = 153;
            string[] myCard = Console.ReadLine().Split(' ');
            int myCardA = int.Parse(myCard[0]);
            int myCardB = int.Parse(myCard[1]);

            numCards[(myCardA - 1) * 2] = NOT_EXIST;
            if (numCards[(myCardB - 1) * 2] == NOT_EXIST)
            {
                numCards[(myCardB - 1) * 2 + 1] = NOT_EXIST;
            }
            else numCards[(myCardB - 1) * 2] = NOT_EXIST;

            myScore = GetScore(myCardA, myCardB);
            
            // 적의 상황을 전부 구합니다.

            for (int indexA = 0; indexA < 19; ++indexA)
            {
                if (numCards[indexA] == NOT_EXIST) continue;

                for (int indexB = indexA + 1; indexB < 20; ++indexB)
                {
                    if (numCards[indexB] == NOT_EXIST) continue;
                    if (myScore > GetScore(numCards[indexA], numCards[indexB]))
                        myWinningCase++;
                }
            }
            
            myWinningCase *= 10000;
            myWinningCase /= enemyCardCase;
            if (myWinningCase % 10 < 5)
            {
                myWinningCase /= 10;
            }
            else
            {
                myWinningCase /= 10;
                myWinningCase++;
            }
            float result = (float)myWinningCase / 1000.0f;
            Console.WriteLine("{0:F3}", result);
        }
    }
}
