using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1167try1
{
    internal class Program
    {
        public class CostedEdgeGraph
        {
            public class Edge
            {
                public int destinationNodeIndex;
                public int cost; // 노드의 갯수가 최대 10만이고, 간선의 거리의 최대값은 만이므로, 지름의 최대값은 10억입니다. 다행히 int자료형의 최대값은 약 20억입니다.
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

        public class Move
        {
            public int index;
            public int cost;
        }



        static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine());
            CostedEdgeGraph tree = new CostedEdgeGraph(nodeCount);

            // 정보가 중복해서 주어집니다. 1번에서 2번을 연결했다고 했으면, 나중에 2번에서 1번을 연결했다는 이야기를 또 하는겁니다.
            for (int line = 0; line < nodeCount; ++line)
            {
                string[] recvLine = Console.ReadLine().Split();

                int oneStart = int.Parse(recvLine[0]) - 1;
                for (int index = 1; index + 1 < recvLine.Length; index += 2)
                {
                    tree.BuildOneWay(oneStart, int.Parse(recvLine[index]) - 1, int.Parse(recvLine[index + 1]));
                }
            }

            // 시작지점을 0로 하고, 가장 멀리 있는 간선을 찾습니다.
            // 가장 멀리있는 간선에서 출발해서 가장 멀리 있는 노드와의 거리를 구합니다.
            // 너비 우선 탐색을 기본으로 합니다.
            Move m_FindFar(int startIndex)
            {
                Move mostFarStep = new Move() { cost = 0, index = startIndex };

                Queue<Move> nextSteps = new Queue<Move>(nodeCount);
                bool[] hasVisited = new bool[nodeCount];

                nextSteps.Enqueue(new Move() { index = startIndex, cost = 0 });
                hasVisited[startIndex] = true;

                while (nextSteps.Count > 0)
                {
                    Move one = nextSteps.Dequeue();

                    // 현재 무브가 가장 멀리있는지 체크합니다. 멀리 있다면 갱신합니다.
                    if (mostFarStep.cost < one.cost) mostFarStep = one;

                    // 연결된 노드들을 통해 새로운 무브를 만들어서 전부 큐에 넣습니다.
                    for (int connectIndex = 0; connectIndex < tree.data[one.index].connectedNode.Count; ++connectIndex)
                    {
                        int nextIndex = tree.data[one.index].connectedNode[connectIndex].destinationNodeIndex;

                        if (hasVisited[nextIndex]) continue;

                        hasVisited[nextIndex] = true;
                        nextSteps.Enqueue(new Move()
                        {
                            index = nextIndex,
                            cost = one.cost + tree.data[one.index].connectedNode[connectIndex].cost
                        });
                    }
                }

                return mostFarStep;
            }

            Move mostFar = m_FindFar(0);
            int result = m_FindFar(mostFar.index).cost;

            Console.WriteLine(result);
        }
    }
}
