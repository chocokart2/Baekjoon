using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1976try1
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
            int city = int.Parse(Console.ReadLine());
            int trip = int.Parse(Console.ReadLine());
            DisjointSetInt set = new DisjointSetInt(city);
            for (int start = 0; start < city; ++start)
            {
                string recvLine = Console.ReadLine();
                for (int end = start; end < city; ++end)
                {
                    if (recvLine[end * 2] == '1')
                    {
                        set.Union(start, end);
                    }
                }
            }

            string[] plan = Console.ReadLine().Split(' ');
            for (int index = 0; index < plan.Length - 1; ++index)
            {
                if (set.IsSame(int.Parse(plan[index]) - 1, int.Parse(plan[index + 1]) - 1) == false)
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
