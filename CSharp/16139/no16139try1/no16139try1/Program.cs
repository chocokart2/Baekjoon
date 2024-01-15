using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no16139try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string words = Console.ReadLine();
            int[,] sum = new int[26, words.Length + 1]; // [알파벳, 위치]
            for (int index = 0; index < words.Length; index++)
            {
                sum[words[index] - 'a', index + 1]++;
                for (int alphabet = 0; alphabet < 26; alphabet++)
                {
                    sum[alphabet, index + 1] += sum[alphabet, index];
                }
            }
            
            
            int questionCount = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < questionCount; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int alphabet = recvLine[0][0] - 'a';

                result.AppendLine($"{sum[alphabet, int.Parse(recvLine[2]) + 1] - sum[alphabet, int.Parse(recvLine[1])]}");
            }
            Console.Write(result);
        }
    }
}
