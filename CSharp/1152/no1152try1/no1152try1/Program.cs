using System;
using System.Collections;
using System.Collections.Generic;
namespace no1152try1
{
    internal class Program
    {

        static string[] Split(string target)
        {
            List<string> result = new List<string>();
            int tailIndex = 0;
            for(int headIndex = 0; headIndex < target.Length; ++headIndex)
            {
                if(target[headIndex] == ' ')
                {
                    string temp = target.Substring(tailIndex, headIndex - tailIndex);
                    result.Add(temp);
                    tailIndex = headIndex + 1;
                }
            }
            string temp2 = target.Substring(tailIndex, target.Length - tailIndex);
            result.Add(temp2);
            return result.ToArray();
        }
        static string[] ClearBlank(string[] target)
        {
            List<string> result = new List<string>();
            for(int index = 0; index < target.Length; ++index)
            {
                if (target[index].Length > 0) result.Add(target[index]);
            }
            return result.ToArray();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ClearBlank(Split(Console.ReadLine())).Length);
        }
    }
}
