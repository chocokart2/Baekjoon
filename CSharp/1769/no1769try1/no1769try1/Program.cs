using System;
using System.Text;

namespace no1769try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int resultCount = 0;
            string recvLine = Console.ReadLine();
            while (recvLine.Length > 1)
            {
                ++resultCount;
                int num = 0;
                for (int index = 0; index < recvLine.Length; ++index)
                    num += int.Parse(recvLine[index].ToString());
                recvLine = num.ToString();
            }
            result.Append($"{resultCount}\n");
            switch (recvLine)
            {
                case "1":
                case "2":
                case "4":
                case "5":
                case "7":
                case "8":
                    result.Append("NO\n");
                    break;
                case "3":
                case "6":
                case "9":
                    result.Append("YES\n");
                    break;
                default:
                    break;
            }

            Console.WriteLine(result);
        }
    }
}
