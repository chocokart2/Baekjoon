using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no16673try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');

            int result = 0;
            int affectionValue = int.Parse(recvLine[1]);
            int addiction = int.Parse(recvLine[2]);
            for (int c = int.Parse(recvLine[0]); c > 0; c--)
            {
                result += c * affectionValue + c * c * addiction;
            }

            Console.WriteLine(result);
        }
    }
}
