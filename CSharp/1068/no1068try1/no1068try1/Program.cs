using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1068try1
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
                for (int index = 0; index < data.Length; ++index)
                    data[index] = new Node();
            }
            public void BuildOneWay(int indexA, int indexB)
            {
                data[indexA].connectedIndex.Add(indexB);
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
            int resultLeafNode = 0;

            int nodeCount = int.Parse(Console.ReadLine());

            SimpleGraph graph = new SimpleGraph(nodeCount);

            string[] recvLineEdge = Console.ReadLine().Split(' ');
            int rootIndex = -1;

            for (int index = 0; index < recvLineEdge.Length; ++index)
            {
                int one = int.Parse(recvLineEdge[index]);

                if (one == -1)
                {
                    rootIndex = index;
                    continue;
                }

                graph.BuildOneWay(one, index);
            }

            int bannedNode = int.Parse(Console.ReadLine());

            // 너비 우선 탐색
            int[] queueData = new int[nodeCount];
            queueData[0] = rootIndex;
            int queueRear = 0;
            int queueHead = 1;
            
            while (queueHead - queueRear > 0)
            {
                int one = queueData[queueRear];
                queueRear++;

                if (one == bannedNode) continue;

                // 밴을 제거해봅니다.
                graph.data[one].connectedIndex.RemoveAll(delegate (int single) { return single == bannedNode; });

                // 만약 자식 노드가 있으면 전부 queue에 넣고,
                // 아니라면 result에 1 추가
                int daughterCount = graph.data[one].connectedIndex.Count;

                if (daughterCount > 0)
                {
                    for (int edgeIndex = 0; edgeIndex < daughterCount; ++edgeIndex)
                    {
                        queueData[queueHead] = graph.data[one].connectedIndex[edgeIndex];
                        queueHead++;
                    }
                }
                else
                {
                    resultLeafNode++;
                }
            }

            Console.WriteLine(resultLeafNode);
        }
    }
}
