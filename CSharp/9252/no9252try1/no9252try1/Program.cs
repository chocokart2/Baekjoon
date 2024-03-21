using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no9252try1
{
    internal class Program
    {
        class TraceBack
        {
            public string result;
        }
        static void Main(string[] args)
        {
            string lineA = Console.ReadLine();
            string lineB = Console.ReadLine();

            //string[,] result = new string[lineA.Length + 1, lineB.Length + 1];
            
            string[] prev = new string[lineB.Length + 1];
            for (int index = 0; index < prev.Length; index++)
            {
                prev[index] = "";
            }

            for (int aIndex = 1; aIndex <= lineA.Length; aIndex++)
            {
                string[] next = new string[lineB.Length + 1];

                for (int bIndex = 0; bIndex <= lineB.Length; bIndex++)
                {
                    if (aIndex == 0 || bIndex == 0)
                    {
                        //result[aIndex, bIndex] = "";
                        next[bIndex] = "";
                        continue;
                    }
                    if (lineA[aIndex - 1] == lineB[bIndex - 1])
                    {
                        //result[aIndex, bIndex] = $"{result[aIndex - 1, bIndex - 1]}{lineA[aIndex - 1]}";
                        next[bIndex] = $"{prev[bIndex - 1]}{lineA[aIndex - 1]}";
                    }
                    else
                    {
                        //if (result[aIndex - 1, bIndex].Length >= result[aIndex, bIndex - 1].Length)
                        if (prev[bIndex].Length >= next[bIndex - 1].Length)
                        {
                            //result[aIndex, bIndex] = result[aIndex - 1, bIndex];
                            next[bIndex] = prev[bIndex];
                        }
                        else
                        {
                            next[bIndex] = next[bIndex - 1];
                        }
                    }
                }

                prev = next;
            }
            
            //Console.WriteLine(result[lineA.Length, lineB.Length].Length);
            //if (result[lineA.Length, lineB.Length].Length > 0)
            //Console.WriteLine(result[lineA.Length, lineB.Length]);
            Console.WriteLine(prev[lineB.Length].Length);
            if (prev[lineB.Length].Length > 0)
            Console.WriteLine(prev[lineB.Length]);
        }
    }
}
