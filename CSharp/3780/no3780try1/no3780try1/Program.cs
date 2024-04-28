using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no3780try1
{
    internal class Program
    {
        public class DisjointSetIntCosted // 서로소 집합
        {
            public int[] Origin { get => parent; }


            private int[] parent;
            private int[] costToCenter; // 자신의 비용 -> 자신이 자신의 페런트까지의 비용 + 페런트의 페런트까지의 비용
            private Func<int, int, int> costFunc;

            public DisjointSetIntCosted(int size)
            {
                parent = new int[size];
                for (int index = 0; index < size; ++index)
                {
                    parent[index] = index;
                }
                costToCenter = new int[size];
            }
            public void InitCostFunc(Func<int, int, int> _costFunc)
            {
                if (this.costFunc != null) return;
                this.costFunc = _costFunc;
            }
            public void InitCostFunc()
            {
                if (this.costFunc != null) return;
                this.costFunc = delegate (int x, int y)
                {
                    return Math.Abs(x - y) % 1000;
                };
            }
            public bool IsSame(int x, int y)
            {
                return FindRootRecursive(x) == FindRootRecursive(y);
            }
            public void Union(int x, int y)
            {
                costToCenter[M_FindRootRecursive(x)] = costFunc(x, y);
                parent[FindRootRecursive(x)] = y;
            }
            public int FindRootRecursive(int target)
            {
                if (parent[target] == target) return target; // 재귀의 종료
                int myOldParent = parent[target];
                int root = FindRootRecursive(parent[target]);
                parent[target] = root; // 경로 압축
                costToCenter[target] += costToCenter[myOldParent]; // + 자기 부모의 센터로 가는 비용
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
            public int GetCost(int target)
            {
                FindRootRecursive(target); // 업데이트 진행
                return costToCenter[target];
            }

            private int M_FindRootRecursive(int target)
            {
                return parent[target] == target ?
                    target : FindRootRecursive(parent[target]);
            }
        }

        static void Main(string[] args)
        {
            StringBuilder answer = new StringBuilder();
            for (int t = int.Parse(Console.ReadLine()); t > 0; --t)
            {
                DisjointSetIntCosted set = new DisjointSetIntCosted(int.Parse(Console.ReadLine()));
                set.InitCostFunc();
                while (true)
                {
                    string[] command = Console.ReadLine().Split(' ');

                    if (command[0][0] == 'O') break;
                    if (command[0][0] == 'E')
                    {
                        answer.Append($"{set.GetCost(int.Parse(command[1]) - 1)}\n");
                        continue;
                    }

                    set.Union(int.Parse(command[1]) - 1, int.Parse(command[2]) - 1);
                }


            }

            Console.Write(answer);
        }
    }
}
