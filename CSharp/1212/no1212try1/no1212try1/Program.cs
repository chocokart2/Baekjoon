using System;
using System.Text;

namespace no1212try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            string recvLine = Console.ReadLine();
            
            for (int index = 0; index < recvLine.Length; ++index)
            {
                switch (recvLine[index])
                {
                    case '0': result.Append("000"); break;
                    case '1': result.Append("001"); break;
                    case '2': result.Append("010"); break;
                    case '3': result.Append("011"); break;
                    case '4': result.Append("100"); break;
                    case '5': result.Append("101"); break;
                    case '6': result.Append("110"); break;
                    case '7': result.Append("111"); break;
                    default: break;
                }
            }
            while (result[0] == '0' && result.Length > 1)
            {
                result = result.Remove(0, 1);
            }

            Console.WriteLine(result);
        }
    }
}
