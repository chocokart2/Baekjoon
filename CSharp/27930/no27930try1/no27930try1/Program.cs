using System;

namespace no27930try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();
            string university = "SEOUL_UNIVERSITY";

            int korIndex = 0;
            int yonIndex = 0;

            for (int index = 0; index < recvLine.Length; ++index)
            {
                if (recvLine[index] == "KOREA"[korIndex])
                {
                    ++korIndex;
                    if (korIndex == 5)
                    {
                        university = "KOREA";
                        break;
                    }
                }
                if (recvLine[index] == "YONSEI"[yonIndex])
                {
                    ++yonIndex;
                    if (yonIndex == 6) 
                    {
                        university = "YONSEI";
                        break;
                    }
                }
            }
            Console.WriteLine(university);
        }
    }
}