using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11404try1
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
        }


        static bool[,] isFiniteCost;
        static int[,] minCost;

        static void SetCost(int start, int end, int cost)
        {
            if (isFiniteCost[start, end] && (minCost[start, end] <= cost)) return;
            isFiniteCost[start, end] = true;
            minCost[start, end] = cost;
        }


        static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine());
            int edgeCount = int.Parse(Console.ReadLine());

            // 인덱스 범례 : [startNode, endNode]
            isFiniteCost = new bool[nodeCount, nodeCount];
            minCost = new int[nodeCount, nodeCount];
            for (int index = 0; index < nodeCount; index++)
                isFiniteCost[index, index] = true;
            for (int i = 0; i < edgeCount; i++)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int start = int.Parse(recvLine[0]) - 1;
                int end = int.Parse(recvLine[1]) - 1;
                int cost = int.Parse(recvLine[2]);

                SetCost(start, end, cost);
            }

            // size ^ 3 모르고리즘

            for (int middleNode = 0; middleNode < nodeCount; ++middleNode)
            {
                for (int startNode = 0; startNode < nodeCount; ++startNode)
                {
                    if (startNode == middleNode) continue;

                    for (int endNode = 0; endNode < nodeCount; ++endNode)
                    {
                        if (endNode == middleNode) continue;

                        if (isFiniteCost[startNode, middleNode] && isFiniteCost[middleNode, endNode])
                        {
                            SetCost(startNode, endNode, minCost[startNode, middleNode] + minCost[middleNode, endNode]);
                        }
                    }
                }
            }

            // 출력
            StringBuilder result = new StringBuilder();

            for (int x = 0; x < nodeCount; ++x)
            {
                result.Append(minCost[x, 0]);

                for (int y = 1; y < nodeCount; ++y)
                {
                    result.Append($" {minCost[x, y]}");
                }
                result.Append('\n');
            }
            Console.Write(result);
        }
    }
}
