using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no8595try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            string recvLine = Console.ReadLine();
            long result = 0;
            StringBuilder one = new StringBuilder();

            for (int i = 0; i < recvLine.Length; i++)
            {
                bool isNum = recvLine[i] >= '0' && recvLine[i] <= '9';
                if (isNum)
                {
                    one.Append(recvLine[i]);
                }
                else if ((!isNum) && (one.Length > 0))
                {
                    result += long.Parse(one.ToString());
                    one.Clear();
                }
            }
            if (one.Length > 0)
            {
                result += long.Parse(one.ToString());
            }
            Console.WriteLine(result);
        }
    }
}
