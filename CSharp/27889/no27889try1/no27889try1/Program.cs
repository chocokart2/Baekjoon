using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no27889try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();
            string result;
            switch (recvLine[0])
            {
                case 'N':
                    result = "North London Collegiate School";
                    break;
                case 'B':
                    result = "Branksome Hall Asia";
                    break;
                case 'K':
                    result = "Korea International School";
                    break;
                case 'S':
                    result = "St. Johnsbury Academy";
                    break;
                default:
                    result = "";
                    break;
            }
            Console.WriteLine(result);
        }
    }
}
