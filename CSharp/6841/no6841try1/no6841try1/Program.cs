using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no6841try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string recvLine = Console.ReadLine();
                switch (recvLine)
                {
                    case "CU": recvLine = "see you"; break;
                    case ":-)": recvLine = "I’m happy"; break;
                    case ":-(": recvLine = "I’m unhappy"; break;
                    case ";-)": recvLine = "wink"; break;
                    case ":-P": recvLine = "stick out my tongue"; break;
                    case "(~.~)": recvLine = "sleepy"; break;
                    case "TA": recvLine = "totally awesome"; break;
                    case "CCC": recvLine = "Canadian Computing Competition"; break;
                    case "CUZ": recvLine = "because"; break;
                    case "TY": recvLine = "thank-you"; break;
                    case "YW": recvLine = "you’re welcome"; break;
                    case "TTYL": recvLine = "talk to you later"; break;
                    default: break;
                }
                Console.WriteLine(recvLine);
                if (recvLine.Equals("talk to you later")) break;
            }
        }
    }
}
