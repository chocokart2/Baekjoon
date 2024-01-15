using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11659try1
{
    internal class Program
    {
        class BinaryTree
        {
            int[] data;
            int startIndex;
            int endIndex; // 마지막 원소의 인덱스입니다.

            


            // 부모는 자식의 두 데이터의 합을 가지고 있습니다. 따라서 합을 구할 때, 두 자식의 합이 필요하다면, 부모의 값을 참조합니다.
            public int GetSum(int begin, int end)
            {
                return 0;
            }
        }





        static int GetSum(int startIndex, int endIndex)
        {

        }


        static void Main(string[] args)
        {
            string[] nAndM = Console.ReadLine().Split(' ');
            int n = int.Parse(nAndM[0]);
            int m = int.Parse(nAndM[1]);
            int[,] numberAndSum = new int[17, n];
            string[] numbers = Console.ReadLine().Split(' ');
            for (int index = 0; index < n; ++index)
                numberAndSum[0, index] = int.Parse(numbers[index]);
            for (int firstIndex = 1; firstIndex < 17; ++firstIndex)
            {
                int firstIndexMax = n / (int)Math.Pow(2, firstIndex);
                
            }


        }
    }
}
