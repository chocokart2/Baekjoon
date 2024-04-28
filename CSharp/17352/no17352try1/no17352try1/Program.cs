using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no17352try1
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
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            DisjointSetInt set = new DisjointSetInt(size);
            StringBuilder answer = new StringBuilder();

            for (int i = 2; i < size; ++i)
            {
                string[] line = Console.ReadLine().Split(' ');

                set.Union(int.Parse(line[0]) - 1, int.Parse(line[1]) - 1);
            }

            for (int index = 0; index < size; ++index)
            {
                if (set.Origin[index] != index) continue;

                if (answer.Length > 1)
                {
                    answer.Append($"{index + 1}");
                    break;
                }
                answer.Append($"{index + 1}");
                answer.Append(' ');
            }

            Console.WriteLine(answer);
        }
    }
}
