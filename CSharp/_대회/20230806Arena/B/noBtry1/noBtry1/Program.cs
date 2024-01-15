using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char begin = '_';
            char end = '_';
            int count = int.Parse(Console.ReadLine());
            string last = "";
            bool foundEmpty = false;
            HashSet<string> existWord = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string recvLine = Console.ReadLine();
                existWord.Add(recvLine);

                if (recvLine[0] == '?')
                {
                    foundEmpty = true;
                    begin = last[last.Length - 1];
                    continue;
                }
                if (begin == '_' && foundEmpty == false)
                {
                    last = recvLine;
                    continue;
                }
                if (foundEmpty && end == '_')
                {
                    end = recvLine[0];
                    continue;
                }
            }

            int M = int.Parse(Console.ReadLine());
            for (int i = 0; i < M; ++i)
            {
                string candidate = Console.ReadLine();

                //Console.WriteLine($"후보 : {candidate}");
                if (existWord.Add(candidate) == false)
                {
                    //Console.WriteLine("이미 존재하는 원소");
                    continue;
                }

                if (begin != '_')
                {
                    if (candidate[0] != begin)
                    {
                        //Console.WriteLine("시작이 다른 대상");
                        continue;
                    }
                }
                if (end != '_')
                {
                    if (candidate.EndsWith(end.ToString()) == false)
                    {
                        //Console.WriteLine("끝이 다른 대상");
                        continue;
                    }
                }
                Console.WriteLine(candidate);
            }
        }
    }
}
