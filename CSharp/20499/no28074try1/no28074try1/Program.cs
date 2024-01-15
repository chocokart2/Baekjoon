using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no28074try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool[] isExist = new bool[26];

            string recvLine = Console.ReadLine();

            foreach (char one in recvLine)
                isExist[one - 'A'] = true;

            if (isExist['M' - 'A'] &&
                isExist['O' - 'A'] &&
                isExist['B' - 'A'] &&
                isExist['I' - 'A'] &&
                isExist['S' - 'A'])
            {
                Console.WriteLine("YES");
            }
            else Console.WriteLine("NO");
        }
    }
}
