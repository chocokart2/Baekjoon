using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noStry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] spliter = Console.ReadLine().Split(' ');
            int m = int.Parse(Console.ReadLine());
            string[] spliterNum = Console.ReadLine().Split(' ');
            int k = int.Parse(Console.ReadLine());
            string[] merger = Console.ReadLine().Split(' '); // 양쪽의 문자을 합침. 공백 제거기
            int s = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();

            HashSet<char> splitLetter = new HashSet<char>();
            for (int index = 0; index < n; ++index)
            {
                splitLetter.Add(spliter[index][0]);
            }
            for (int index = 0; index < m; ++index)
            {
                splitLetter.Add(spliterNum[index][0]);
            }
            for (int index = 0; index < k; ++index)
            {
                splitLetter.Remove(merger[index][0]);
            }
            splitLetter.Add(' ');
            string[] result = str.Split(splitLetter.ToArray());
            for (int index = 0; index < result.Length; ++index)
            {
                if (result[index].Length < 1) continue;
                Console.WriteLine(result[index]);
            }
        }
    }
}
