using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no27906try1
{
    internal class Program
    {
        static int[][] viewOfPerson; // 인덱스는 몇번째 사람인가. 1은 yes -1은 black, 0은 몰라
        

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            viewOfPerson = new int[N][];
            for (int index = 0; index < N; ++index) viewOfPerson[index] = new int[N];




        }
    }
}
