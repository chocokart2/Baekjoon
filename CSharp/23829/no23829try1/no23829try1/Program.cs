using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no23829try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rescvLineNQ = Console.ReadLine().Split(' ');
            int treeCount = int.Parse(rescvLineNQ[0]);
            int query = int.Parse(rescvLineNQ[1]);

            long[] trees = new long[10_000_001];
            long[] score = new long[10_000_001];
            string[] treePositions = Console.ReadLine().Split(' ');
            for (int index = 0; index < treeCount; index++)
            {
                trees[int.Parse(treePositions[index])]++;
            }
            for (int index = 1; index < trees.Length; index++)
            {
                trees[index] += trees[index - 1];
            }
            // 위치가 0일때의 점수를 구함
            for (int index = 0; index < treeCount; ++index)
            {
                score[0] += long.Parse(treePositions[index]);
            }
            // 위치가 0일때의 점수를 기준으로 그 옆자리의 점수를 구함.
            for (int position = 1; position < score.Length; position++)
            {
                // 자기보다 왼쪽의 트리갯수만큼 점수를 추가하고, 자기보다 오른쪽에 있는 트리갯수만큼 점수를 뺀다.
                score[position] = score[position - 1] + trees[position - 1] - (trees[trees.Length - 1] - trees[position - 1]);
            }
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < query; ++i)
            {
                result.AppendLine(score[int.Parse(Console.ReadLine())].ToString());
            }
            Console.Write(result);
        }
    }
}
