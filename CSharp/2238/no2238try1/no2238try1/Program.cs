using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2238try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 대여과기
            // 해시셋<이름>[가격]
            // 같은 가격을 같은 사람이 제시한 경우는 하나만 남기고 무시한다.
            // 같은 가격을 제시한 경우는 제거됩니다.
            // 

            List<string>[] bidder = new List<string>[10_001];
            int count = int.Parse(Console.ReadLine().Split(' ')[1]);
            for (int index = 0; index < 10_001; index++)
            {
                bidder[index] = new List<string>();
            }

            for (int i = 0; i < count; i++)
            {
                string[] bid = Console.ReadLine().Split(' ');
                int num = int.Parse(bid[1]);

                if (!bidder[num].Contains(bid[0]))
                {
                    bidder[num].Add(bid[0]);
                }
            }
            int minCountPerson = int.MaxValue;
            int minCountPersonCost = -1;
            for (int cost = 1; cost < 10_001; cost++)
            {
                if (bidder[cost].Count == 0) continue;
                if (bidder[cost].Count < minCountPerson)
                {
                    minCountPerson = bidder[cost].Count;
                    minCountPersonCost = cost;
                }
            }

            Console.WriteLine($"{bidder[minCountPersonCost][0]} {minCountPersonCost}");
        }
    }
}
