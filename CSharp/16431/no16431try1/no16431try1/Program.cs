using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no16431try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');
            int BessieX = int.Parse(recvLine[0]);
            int BessieY = int.Parse(recvLine[1]);
            recvLine = Console.ReadLine().Split(' ');
            int DaisyX = int.Parse(recvLine[0]);
            int DaisyY = int.Parse(recvLine[1]);
            recvLine = Console.ReadLine().Split(' ');
            int JohnX = int.Parse(recvLine[0]);
            int JohnY = int.Parse(recvLine[1]);

            int result =
                (Math.Abs(DaisyX - JohnX) + Math.Abs(DaisyY - JohnY))
                - Math.Max(Math.Abs(BessieX - JohnX), Math.Abs(BessieY - JohnY));
            Console.WriteLine(result == 0 ? "tie" : (result > 0 ? "bessie" : "daisy"));
        }
    }
}
