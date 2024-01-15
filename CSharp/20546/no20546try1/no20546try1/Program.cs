using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace no20546try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long moneyBNP = long.Parse(Console.ReadLine());
            long moneyTiming = moneyBNP;
            long stockBNP = 0;
            long stockTiming = 0;
            string[] valueString = Console.ReadLine().Split(' ');
            long[] cost = new long[14];

            for (int index = 0; index < 14; ++index)
            {
                cost[index] = long.Parse(valueString[index]);

                // bnp
                while (moneyBNP >= cost[index])
                {
                    moneyBNP -= cost[index];
                    stockBNP++;
                }
                // timing
                if (index > 2)
                {

                    // 매수
                    if (cost[index - 3] > cost[index - 2] &&
                        cost[index - 2] > cost[index - 1] &&
                        cost[index - 1] > cost[index])
                    {
                        long buyCount = moneyTiming / cost[index];
                        moneyTiming -= buyCount * cost[index];
                        stockTiming += buyCount;
                        //Console.WriteLine($"{index + 1} 일 {buyCount}개 매수");
                    }
                    // 매각
                    if (cost[index - 3] < cost[index - 2] &&
                        cost[index - 2] < cost[index - 1] &&
                        cost[index - 1] < cost[index])
                    {
                        //Console.WriteLine($"{index + 1} 일 {stockTiming}개 매도");
                        moneyTiming += stockTiming * cost[index];
                        stockTiming = 0;
                    }
                }
            }

            moneyBNP += stockBNP * cost[13];
            moneyTiming += stockTiming * cost[13];

            if (moneyBNP > moneyTiming)
            {
                Console.WriteLine("BNP");
            }
            else if (moneyBNP < moneyTiming)
            {
                Console.WriteLine("TIMING");
            }
            else
            {
                Console.WriteLine("SAMESAME");
            }

            //Console.WriteLine(moneyBNP);
            //Console.WriteLine(moneyTiming);


        }
    }
}
