using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] today = Console.ReadLine().Split('-');

            int count = int.Parse(Console.ReadLine());
            int result = 0;

            for (int coupon = 0; coupon < count; ++coupon)
            {
                string[] expDate = Console.ReadLine().Split('-');

                for (int index = 0; index < 3; ++index)
                {
                    int todayOne = int.Parse(today[index]);
                    int expireOne = int.Parse(expDate[index]);

                    if (expireOne > todayOne)
                    {
                        result++;
                        break;
                    }
                    else if (expireOne < todayOne) break;
                    if (index == 2) result++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
