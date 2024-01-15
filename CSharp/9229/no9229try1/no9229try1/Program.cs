using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9229try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exitTrigger = true;
            bool testCaseResult = true;
            string prev = "";
            while (true)
            {
                string recvLine = Console.ReadLine();

                if (exitTrigger)
                {
                    if (recvLine.Equals("#")) break;
                    else
                    {
                        exitTrigger = false;
                        prev = recvLine;

                    }
                }
                else
                {
                    if (recvLine.Equals("#"))
                    {
                        Console.WriteLine(testCaseResult ? "Correct" : "Incorrect");
                        exitTrigger = true;
                        testCaseResult = true;
                        continue;
                    }
                    else
                    {
                        // prev와 비교
                        if (prev.Length != recvLine.Length)
                        {
                            testCaseResult = false;
                        }
                        else
                        {
                            int differCount = 0;
                            for (int index = 0; index < prev.Length; ++index)
                            {
                                if (recvLine[index] != prev[index]) differCount++;
                            }

                            if (differCount != 1) testCaseResult = false;
                        }

                        // 다음
                        prev = recvLine;
                    }
                }
            }
        }
    }
}
