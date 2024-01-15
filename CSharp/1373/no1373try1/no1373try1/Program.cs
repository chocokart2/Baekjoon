using System;
using System.Text;

namespace no1373try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();

            int single = 0;
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < recvLine.Length; ++index)
            {
                int binaryNumberPositionIndex = recvLine.Length - 1 - index;
                if (recvLine[index].Equals('1')) single += 1 << binaryNumberPositionIndex % 3;
                if ((binaryNumberPositionIndex % 3).Equals(0))
                {
                    result.Append(single);
                    single = 0;
                }
            }
            Console.WriteLine(result.ToString());
        }
    }
}
