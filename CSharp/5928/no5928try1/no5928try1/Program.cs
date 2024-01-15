using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no5928try1
{
    internal class Program
    {
        static int ConvertToTime(string[] timeString)
        {
            return int.Parse(timeString[0]) * 24 * 60 +
                int.Parse(timeString[1]) * 60 + int.Parse(timeString[2]);
        }

        static void Main(string[] args)
        {
            int start = ConvertToTime(new string[] { "11", "11", "11" });
            int term =
                ConvertToTime(Console.ReadLine().Split(' ')) - start;
            Console.WriteLine((term >= 0) ? term : -1);
        }
    }
}
