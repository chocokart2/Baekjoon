using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1049try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sixMin = int.MaxValue;
            int oneMin = int.MaxValue;
            int result = 0;

            string[] recvLineMN = Console.ReadLine().Split(' ');
            int demand = int.Parse(recvLineMN[0]);
            int count = int.Parse(recvLineMN[1]);

            for (int i = 0; i < count; ++i)
            {
                string[] oneLine = Console.ReadLine().Split(' ');

                sixMin = Math.Min(sixMin, int.Parse(oneLine[0]));
                oneMin = Math.Min(oneMin, int.Parse(oneLine[1]));
            }

            if (sixMin < oneMin * 6)
            {
                result = sixMin * (demand / 6) + oneMin * (demand % 6);
            }
            else
            {
                result = oneMin * demand;
            }
            result = Math.Min(sixMin * (demand % 6 == 0 ? (demand / 6) : (demand / 6 + 1)), result);
            Console.WriteLine(result);
        }
    }
}
