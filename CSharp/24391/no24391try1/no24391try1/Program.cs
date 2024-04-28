using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no24391try1
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
            string[] nums = Console.ReadLine().Split(' ');

            int size = int.Parse(nums[0]);
            int mergeCount = int.Parse(nums[1]);

            DisjointSetInt set = new DisjointSetInt(size);

            int answer = 0; // 두 강의실이 같은 셋이 아니면 1 추가

            for (int i = 0; i < mergeCount; ++i)
            {
                string[] one = Console.ReadLine().Split(' ');
                set.Union(int.Parse(one[0]) - 1, int.Parse(one[1]) - 1);

            }

            string[] roomStr = Console.ReadLine().Split(' ');
            int[] room = new int[roomStr.Length];
            for (int index = 0; index < room.Length; ++index)
            {
                room[index] = int.Parse(roomStr[index]) - 1;

                if (index == 0) continue;

                if (set.IsSame(room[index - 1], room[index]) == false) answer++;
            }

            Console.WriteLine(answer);
        }
    }
}
