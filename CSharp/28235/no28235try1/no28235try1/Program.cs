using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no28235try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();
            string result = "";

            switch (recvLine[0])
            {
                case 'S': result = "HIGHSCHOOL"; break;
                case 'C': result = "MASTER"; break;
                case '2': result = "0611"; break;
                case 'A': result = "CONTEST"; break;
                default:
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
