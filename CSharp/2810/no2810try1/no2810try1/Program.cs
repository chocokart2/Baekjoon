using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace no2810try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> arrange = new List<int>();
            const int EMPTY = 0;
            const int CUP_HOLDER = 1;
            const int SOLO_DUDE = 2;
            const int COUPLE_WINNER = 3;
            int result = 0;


            void RemoveNearCupHolder(int index)
            {
                if (arrange[index - 1] == CUP_HOLDER)
                {
                    arrange[index - 1] = EMPTY;
                    result++;
                    return;
                }
                else if (arrange[index + 1] == CUP_HOLDER)
                {
                    arrange[index + 1] = EMPTY;
                    result++;
                    return;
                }
            }


            Console.ReadLine();
            string recvLine = Console.ReadLine();
            arrange.Add(CUP_HOLDER);
            for (int i = 0; i < recvLine.Length; i++)
            {
                if (recvLine[i] == 'L')
                {
                    arrange.Add(COUPLE_WINNER);
                    arrange.Add(COUPLE_WINNER);
                    arrange.Add(CUP_HOLDER);
                    i++;
                }
                else
                {
                    arrange.Add(SOLO_DUDE);
                    arrange.Add(CUP_HOLDER);
                }
            }

            for (int index = 0; index < arrange.Count; index++)
            {
                if (arrange[index] == COUPLE_WINNER)
                {
                    RemoveNearCupHolder(index);
                }
            }
            for (int index = 0; index < arrange.Count; ++index)
            {
                if (arrange[index] == SOLO_DUDE)
                {
                    RemoveNearCupHolder(index);
                }
            }
            Console.WriteLine(result);
        }
    }
}
