using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1717try1
{
    internal class Program
    {
        public class DisjointSetInt // 서로소 집합
        {
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
        }

        static void Main(string[] args)
        {
            string[] recvLineNM = Console.ReadLine().Split(' ');
            DisjointSetInt set = new DisjointSetInt(int.Parse(recvLineNM[0]) + 1);
            StringBuilder answer = new StringBuilder();
            for (int q = int.Parse(recvLineNM[1]); q > 0; --q)
            {
                string[] query = Console.ReadLine().Split(' ');

                int x = int.Parse(query[1]);
                int y = int.Parse(query[2]);

                if (query[0][0] == '0')
                {
                    set.Union(x, y);
                }
                else
                {
                    answer.AppendLine((set.IsSame(x, y) ? "YES" : "NO"));
                }
            }

            Console.WriteLine(answer);
        }
    }
}
