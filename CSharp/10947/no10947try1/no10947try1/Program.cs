using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10947try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // start + end / delta
            // 0 + 1 => 1 / 1
            // 0 + 0 => 0 / 0
            // 1 + 1 => 2 / 0
            // 0 + 2 => 2 / 2

            // int i = 0, i -> n
            // int delta = 0, delta -> n
            // arr[i - delta] == arr[i + delta]를 만족하는 delta의 최대값을 result[i * 2]에 저장
            // arr[i - delta] == arr[i + 1 + delta]를 만족하는 delta의 최대값을 result[i * 2 + 1]에 저장
            // result[x]의 초기화 값은 -1(불가능)이다

            Console.ReadLine();
            string[] recvLine = Console.ReadLine().Split(' ');
            int[] numArray = new int[recvLine.Length];
            for (int index = 0; index < recvLine.Length; ++index)
            {
                numArray[index] = int.Parse(recvLine[index]);
            }

            bool M_IsOutside(int _index, int size)
            {
                if (_index < 0) return true;
                if (_index >= size) return true;
                return false;
            }

            int[] result = new int[numArray.Length * 2];
            for (int pivotIndex = 0; pivotIndex < numArray.Length; ++pivotIndex)
            {
                for (int isDoublePivot = 0; isDoublePivot <= 1; ++isDoublePivot)
                {
                    result[pivotIndex * 2 + isDoublePivot] = -1; // 초기화

                    for (int delta = 0; true; ++delta)
                    {
                        int start = pivotIndex - delta;
                        int end = pivotIndex + isDoublePivot + delta;

                        if (M_IsOutside(start, numArray.Length)) break;
                        if (M_IsOutside(end, numArray.Length)) break;
                        if (numArray[start] != numArray[end]) break;
                        result[pivotIndex * 2 + isDoublePivot] = delta * 2 + isDoublePivot;
                    }
                }
            }

            StringBuilder answer = new StringBuilder();

            for (int t = int.Parse(Console.ReadLine()); t > 0; --t)
            {
                string[] one = Console.ReadLine().Split(' ');
                int start = int.Parse(one[0]) - 1;
                int end = int.Parse(one[1]) - 1;

                bool oneAnswer = result[start + end] >= (end - start);
                answer.AppendLine(oneAnswer ? "1" : "0");
            }
            Console.Write(answer);

        }
    }
}
