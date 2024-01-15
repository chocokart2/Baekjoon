using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1865try1
{
    internal class Program
    {
        public class CostedEdgeGraph
        {
            public class Edge
            {
                public int destinationNodeIndex;
                public int cost;
            }
            public class Node
            {
                public System.Collections.Generic.List<Edge> connectedNode;

                public Node()
                {
                    connectedNode = new System.Collections.Generic.List<Edge>();
                }
            }

            public Node[] data;

            public CostedEdgeGraph(int size)
            {
                data = new Node[size];
                for (int index = 0; index < size; ++index)
                {
                    data[index] = new Node();
                }
            }

            public void BuildOneWay(int startIndex, int destinationIndex, int cost = 1)
            {
                data[startIndex].connectedNode.Add(
                    new Edge()
                    {
                        destinationNodeIndex = destinationIndex,
                        cost = cost
                    }
                    );
            }
            public void BuildTwoWay(int index1, int index2, int cost = 1)
            {
                BuildOneWay(index1, index2, cost);
                BuildOneWay(index2, index1, cost);
            }
        }

        static bool IsLoop()
        {
            // 먼저 지도를 만듭니다.

            string[] recvLineNMW = Console.ReadLine().Split(' ');
            int nodeCount = int.Parse(recvLineNMW[0]);
            int roadCount = int.Parse(recvLineNMW[1]);
            int wormholeCount = int.Parse(recvLineNMW[2]);
            HashSet<int> startPointSet = new HashSet<int>();

            CostedEdgeGraph map = new CostedEdgeGraph(nodeCount);
            for (int i = 0; i < roadCount; ++i)
            {
                string[] recvLineSET = Console.ReadLine().Split(' ');
                map.BuildTwoWay(int.Parse(recvLineSET[0]) - 1, int.Parse(recvLineSET[1]) - 1, int.Parse(recvLineSET[2]));
            }
            for (int i = 0; i < wormholeCount; ++i)
            {
                string[] recvLineSET = Console.ReadLine().Split(' ');
                map.BuildOneWay(int.Parse(recvLineSET[0]) - 1, int.Parse(recvLineSET[1]) - 1, -int.Parse(recvLineSET[2]));
                startPointSet.Add(int.Parse(recvLineSET[0]) - 1);
            }

            // 2차원 배열의 인덱스의 의미 : 첫번째 인덱스는 n번째 노드가 출발 지점인 케이스의 종류, 두번째 인덱스는 해당 케이스의 몇번째 노드인가?
            int m_size = map.data.Length;
            int m_caseCount = startPointSet.Count;
            int[] startPoint = startPointSet.ToArray();
            bool[,] isCostNotPositiveInfinity = new bool[m_caseCount, m_size];
            int[,] costForReach = new int[m_caseCount, m_size];
            
            // 이제 벨만 포드를 사용합니다.
            // 그 어떤 노드라도 가격이 음의 무한대인 경우, true를 리턴합니다.

            // 각 케이스 마다 시작 노드는 0으로 설정합니다.
            for (int index = 0; index < m_caseCount; ++index)
            {
                int oneStart = startPoint[index];
                isCostNotPositiveInfinity[index, oneStart] = true;
                costForReach[index, oneStart] = 0;
            }

            // 모든 노드의 탐객에 대해서는 탐색은 깊이 우선 탐색과 유사한 방식으로 한다
            // 같은 노드를 재방문할 수 있도록 하되, size - 1만큼 노드를 건너가도록 제한한다.

            for (int attempt = 0; attempt < m_size; attempt++)
            {
                for (int nodeIndex = 0; nodeIndex < map.data.Length; nodeIndex++)
                {
                    for (int connectIndex = 0; connectIndex < map.data[nodeIndex].connectedNode.Count; ++connectIndex)
                    {
                        CostedEdgeGraph.Edge one = map.data[nodeIndex].connectedNode[connectIndex];

                        for (int caseIndex = 0; caseIndex < m_caseCount; ++caseIndex)
                        {
                            // 간선의 출발지점이 무한대인 경우 : 반드시 무시
                            if (isCostNotPositiveInfinity[caseIndex, nodeIndex] == false)
                            {
                                //Console.WriteLine($"DEBUG : 해당 간선의 출발지점은 코스트 값이 무한대입니다. \n 케이스 : {caseIndex}, 출발 노드 : {nodeIndex}");
                                continue;
                            }
                            // 간선의 도착지점이 무한대인 경우 : 반드시 갱신
                            if (isCostNotPositiveInfinity[caseIndex, one.destinationNodeIndex] == false)
                            {
                                isCostNotPositiveInfinity[caseIndex, one.destinationNodeIndex] = true;
                                costForReach[caseIndex, one.destinationNodeIndex] =
                                    costForReach[caseIndex, nodeIndex] + one.cost;
                                continue;
                            }
                            // 둘다 아닌 경우 : 조건부 갱신
                            if (costForReach[caseIndex, one.destinationNodeIndex] > costForReach[caseIndex, nodeIndex] + one.cost)
                            {
                                costForReach[caseIndex, one.destinationNodeIndex] =
                                    costForReach[caseIndex, nodeIndex] + one.cost;
                            }
                        }
                    }
                }
            }

            //// 각자의 데이터 확인하기
            //for (int indexY = 0; indexY < m_size; ++indexY)
            //{
            //    for (int indexX = 0; indexX < m_size; ++indexX)
            //    {
            //        string one = "INF";

            //        if (isCostNotPositiveInfinity[indexY, indexX])
            //            one = costForReach[indexY, indexX].ToString();
            //        Console.Write($"{one}\t");

            //    }
            //    Console.WriteLine();
            //}

            for (int index = 0; index < m_caseCount; ++index)
            {
                if (costForReach[index, startPoint[index]] < 0) return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
                result.Append((IsLoop()) ? "YES\n" : "NO\n");

            Console.Write(result);
        }
    }
}
