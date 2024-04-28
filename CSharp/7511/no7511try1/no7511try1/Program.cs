using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no7511try1
{
    internal class Program
    {
        public class DisjointSetInt // 서로소 집합
        {
            public int[] Origin { get => parent; }
            private int[] parent;

            public DisjointSetInt(int size)
            {
                parent = new int[size];
                for (int index = 0; index < size; ++index)
                {
                    parent[index] = index;
                }
            }
            public bool IsSame(int x, int y)
            {
                return FindRootRecursive(x) == FindRootRecursive(y);
            }
            public void Union(int x, int y)
            {
                parent[FindRootRecursive(y)] = FindRootRecursive(x);
            }
            public int FindRootRecursive(int target)
            {
                if (parent[target] == target) return target; // 재귀의 종료
                int root = FindRootRecursive(parent[target]);
                parent[target] = root; // 경로 압축
                return root;
            }
            public int GetSetCount()
            {
                int result = 0;
                for (int index = 0; index < parent.Length; ++index)
                {
                    if (index == parent[index]) result++;
                }
                return result;
            }

            // 입력값의 유효성을 검사하는 프라이빗 함수입니다. O(1)만큼의 오버헤드가 발생합니다.
            private bool IsVaildIndex(int index)
            {
                return (index > -1) && (index < parent.Length);
            }
        }

        static void Main(string[] args)
        {
            DisjointSetInt set;
            StringBuilder answer = new StringBuilder();
            int testCase = int.Parse(Console.ReadLine());
            for (int t = 1; t <= testCase; ++t)
            {
                set = new DisjointSetInt(int.Parse(Console.ReadLine()));
                
                for (int bridge = int.Parse(Console.ReadLine()); bridge > 0; --bridge)
                {
                    string[] recvLine = Console.ReadLine().Split(' ');

                    set.Union(int.Parse(recvLine[0]), int.Parse(recvLine[1]));
                }

                if (t != 1) answer.AppendLine();
                answer.AppendLine($"Scenario {t}:");

                for (int q = int.Parse(Console.ReadLine()); q > 0; --q)
                {
                    string[] recvLine = Console.ReadLine().Split(' ');

                    answer.AppendLine(set.IsSame(int.Parse(recvLine[0]), int.Parse(recvLine[1])) ?
                        "1" : "0");
                }
            }

            Console.Write(answer);


        }
    }
}
