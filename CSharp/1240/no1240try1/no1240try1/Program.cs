using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace no1240try1
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

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int size = int.Parse(nums[0]);
            int query = int.Parse(nums[1]);

            CostedEdgeGraph graph = new CostedEdgeGraph(size);

            for (int i = 1; i < size; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                graph.BuildTwoWay(
                    int.Parse(recvLine[0]) - 1,
                    int.Parse(recvLine[1]) - 1,
                    int.Parse(recvLine[2])
                    );
            }

            StringBuilder result = new StringBuilder();
            // 너비 우선 탐색을 진행
            for (int i = 0; i < query; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                int start = int.Parse(recvLine[0]) - 1;
                int end = int.Parse(recvLine[1]) - 1;

                int[] cost = new int[size];
                for (int index = 0; index < size; ++index) cost[index] = -1;
                cost[start] = 0;

                int[] queue = new int[size];
                int queueRear = 0;
                int queueHead = 1;
                queue[0] = start;

                while (queueHead > queueRear)
                {
                    int one = queue[queueRear];
                    queueRear++;

                    // 얀결된 원소를 큐에 넣고, 코스트 업데이트

                    for (int index = 0; index < graph.data[one].connectedNode.Count; ++index)
                    {
                        if (cost[graph.data[one].connectedNode[index].destinationNodeIndex] > -1) continue;
                        queue[queueHead] = graph.data[one].connectedNode[index].destinationNodeIndex;
                        cost[graph.data[one].connectedNode[index].destinationNodeIndex]
                            = cost[one] + graph.data[one].connectedNode[index].cost;
                        queueHead++;
                    }
                }

                result.AppendLine($"{cost[end]}");
            }
            Console.Write(result);
        }
    }
}
