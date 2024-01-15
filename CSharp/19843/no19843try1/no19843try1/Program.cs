using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no19843try1
{
    internal class Program
    {
        static int Convert(string day)
        {
            switch (day)
            {
                case "Mon": return 0;
                case "Tue": return 1;
                case "Wed": return 2;
                case "Thu": return 3;
                case "Fri": return 4;
                default: return -1;
            }
        }

        static void Main(string[] args)
        {
            string[] numsQuotaAndCount = Console.ReadLine().Split(' ');
            int quota = int.Parse(numsQuotaAndCount[0]);
            int count = int.Parse(numsQuotaAndCount[1]);
            int sum = 0;
            for (int i = 0; i < count; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                quota -=
                    (Convert(recvLine[2]) - Convert(recvLine[0])) * 24
                    + int.Parse(recvLine[3]) - int.Parse(recvLine[1]);
            }

            if (quota > 48) Console.WriteLine(-1);
            else if (quota <= 0) Console.WriteLine(0);
            else Console.WriteLine(quota);
        }
    }
}
