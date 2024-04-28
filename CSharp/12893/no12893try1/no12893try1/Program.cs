using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no12893try1
{
    internal class Program
    {
        public class SimpleGraph
        {
            public class Node
            {
                public List<int> connectedIndex;

                public Node()
                {
                    connectedIndex = new List<int>();
                }
            }

            public Node[] data;

            public SimpleGraph(int size)
            {
                data = new Node[size];
                for (int i = 0; i < size; ++i)
                {
                    data[i] = new Node();
                }
            }
            public void BuildTwoWay(int indexA, int indexB)
            {
                data[indexA].connectedIndex.Add(indexB);
                data[indexB].connectedIndex.Add(indexA);
            }
            public void BreakTwoWay(int indexA, int indexB)
            {
                // 둘 중 하나라도 그 원소가 없으면 무시.
                int indexBInNodeA = data[indexA].connectedIndex.FindIndex(delegate (int index) { return index == indexB; });
                int indexAInNodeB = data[indexB].connectedIndex.FindIndex(delegate (int index) { return index == indexA; });

                if ((indexAInNodeB == -1) || (indexBInNodeA == -1)) return;

                data[indexA].connectedIndex.RemoveAt(indexBInNodeA);
                data[indexB].connectedIndex.RemoveAt(indexAInNodeB);
            }
        }

        static void Main(string[] args)
        {
            // 특정 대상이 적이다
            // 1) A - B 이 둘이 같은 팀인지 확인
            // 1-1) 같은 대상이라면 0을 리턴
            // 2) A의 적 그룹에 B를 넣고 B의 적 그룹에 A를 넣음

            // 또는 그래프 탐색을 진행. - 깊이 우선 탐색을 진행. 1 2 1 2 를 반복하며 진행
            // 
            string[] recvLinePeopleAndEnemy = Console.ReadLine().Split(' ');
            int people = int.Parse(recvLinePeopleAndEnemy[0]);
            int enemy = int.Parse(recvLinePeopleAndEnemy[1]);

            SimpleGraph graph = new SimpleGraph(people);
            int[] team = new int[people];
            int teamA = 1;
            int teamB = 2;
            int none = 0;
            bool[] hasVisited = new bool[people]; // 방문한 노드면 스텍에 넣지는 않습니다만, 그래도 서로 적인지 아닌지 여부는 판단합니다.

            for (int i = 0; i < enemy; ++i)
            {
                string[] one = Console.ReadLine().Split(' ');
                graph.BuildTwoWay(int.Parse(one[0]) - 1, int.Parse(one[1]) - 1);
            }

            int[] stack = new int[people];
            int stackCount = 0;

            for (int index = 0; index < people; ++index)
            {
                if (team[index] != none) continue;
                stack[stackCount] = index;
                stackCount++;
                hasVisited[index] = true;
                team[index] = teamA;
                // dfs 실행
                while (stackCount > 0)
                {
                    int oneIndex = stack[stackCount - 1];
                    SimpleGraph.Node one = graph.data[oneIndex];
                    --stackCount;

                    for (int nextIndex = 0; nextIndex < one.connectedIndex.Count; ++nextIndex)
                    {
                        // 팀의 정보를 가져옴
                        // 만약 같은 팀이다 -> 0 출력하고 종료
                        // 다른 팀이라면 넘어감
                        // 모르는 팀이다 -> 팀을 설정하고 스택에 추가
                        int nextEnemyIndnex = one.connectedIndex[nextIndex];
                        int nextEnemyTeam = team[nextEnemyIndnex];

                        if (nextEnemyTeam == team[oneIndex])
                        {
                            //Console.WriteLine($"현재 스택 : {}");

                            // 적의 적이 자신과 적입니다.
                            Console.WriteLine(0);
                            return;
                        }
                        if (nextEnemyTeam != none)
                        {
                            // 원래 서로 적이였으므로 무시한다
                            continue;
                        }

                        // 새로운 팀에 넣습니다.
                        team[nextEnemyIndnex] =
                            (team[oneIndex] == teamA) ? teamB : teamA;
                        stack[stackCount] = nextEnemyIndnex;
                        stackCount++;
                    }
                }


            }

            Console.WriteLine(1);
        }
    }
}
