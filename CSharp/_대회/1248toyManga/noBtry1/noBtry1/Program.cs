using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] start = Console.ReadLine().Split(' ');
            int result = 0;
            for (int i = int.Parse(start[0]); i > 0; i--)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                string[] words = recvLine[0].Split('_');
                for (int index = 0; index < words.Length; index++)
                {
                    if (words[index].Equals(start[1]))
                    {
                        result += int.Parse(recvLine[1]);
                        break;
                    }
                }

            }

            Console.WriteLine(result);
        }
    }
}
