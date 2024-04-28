using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no22935try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] answer =
            {
                "VVV딸기",
                "VV딸기V",
                "VV딸기딸기",
                "V딸기VV",
                "V딸기V딸기",
                "V딸기딸기V",
                "V딸기딸기딸기",
                "딸기VVV",
                "딸기VV딸기",
                "딸기V딸기V",
                "딸기V딸기딸기",
                "딸기딸기VV",
                "딸기딸기V딸기",
                "딸기딸기딸기V",
                "딸기딸기딸기딸기"
            };

            StringBuilder result = new StringBuilder();
            for (int t = int.Parse(Console.ReadLine()); t > 0; t--)
            {
                long count = long.Parse(Console.ReadLine()) - 1;
                count %= 28;
                if (count > 14) count = 28 - count;
                result.AppendLine(answer[count]);
            }
            Console.Write(result);
        }
    }
}
