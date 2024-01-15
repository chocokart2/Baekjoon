using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1238try1
{
    internal class Program
    {
        class Graph
        {
            public class Node
            {
                public List<Edge> edge;

                public Node()
                {
                    edge = new List<Edge>();
                }
            }
            public class Edge
            {
                public int nodeIndex;
                public int cost;
            }

            public Node[] nodes;

            public Graph(int size)
            {
                nodes = new Node[size];
                for (int index = 0; index < size; ++index)
                {
                    nodes[index] = new Node();
                }
            }
            public void BuildOneWay(int start, int end, int cost)
            {
                nodes[start].edge.Add(new Edge() { cost = cost, nodeIndex = end });
            }
        }
        class Heap<T>
        {
            // 작은 값일수록 우선순위가 높습니다.

            private Comparison<T> IsLeftGreatherThenRight;
            private T[] data;
            public int count { private set; get; }

            const int NOT_FOUND = -1;

            public Heap(int size, Comparison<T> function)
            {
                data = new T[size + 1];
                count = 0;
                IsLeftGreatherThenRight = function;
            }
            public void Push(T item)
            {
                ++count;
                data[count] = item;
                M_Heapify(count);
            }
            public T Peek()
            {
                if (count < 1) return default;
                return data[count];
            }
            public T Pop()
            {
                if (count < 1) return default;
                T result = data[1];
                data[1] = data[count];
                count--;
                M_Heapify(1);
                return result;
            }

            private void M_Swap(int leftIndex, int rightIndex)
            {
                T temp = data[leftIndex];
                data[leftIndex] = data[rightIndex];
                data[rightIndex] = temp;
            }

            private void M_Heapify(int targetIndex)
            {
                for (int currentIndex = targetIndex, daughterIndex = M_FindDaughterIndex(targetIndex);
                    daughterIndex != NOT_FOUND;
                    currentIndex = daughterIndex, daughterIndex = M_FindDaughterIndex(daughterIndex))
                {
                    if (M_IsLeftPriority(data[currentIndex], data[daughterIndex])) break; // 정상화가 된 상태입니다.
                    M_Swap(currentIndex, daughterIndex);
                }
                for (int currentIndex = targetIndex, motherIndex = M_FindMotherIndex(targetIndex);
                    motherIndex != NOT_FOUND;
                    currentIndex = motherIndex, motherIndex = M_FindMotherIndex(motherIndex))
                {
                    if (M_IsLeftPriority(data[motherIndex], data[currentIndex])) break; // 정상화가 된 상태입니다.
                    M_Swap(motherIndex, currentIndex);
                }
            }
            private int M_FindMotherIndex(int targetIndex) => (targetIndex < 2) ? NOT_FOUND : targetIndex >> 1;
            private int M_FindDaughterIndex(int targetIndex)
            {
                int result = NOT_FOUND;
                if ((targetIndex << 1) > count) return result;
                result = (targetIndex << 1);
                if (result + 1 > count) return result;
                if (M_IsLeftPriority(data[result], data[result + 1])) return result;
                return result + 1;
            }
            private bool M_IsLeftPriority(T left, T right)
                => IsLeftGreatherThenRight(left, right) <= 0;
        }
        class Step
        {
            public int index;
            public int cost;
        }


        static Graph graph;
        static int edgeCount;

        static int GetCost(int startIndex, int destinationIndex)
        {
            bool[] isFinityCost = new bool[graph.nodes.Length];
            int[] minCost = new int[graph.nodes.Length];
            Heap<Step> selector = new Heap<Step>(10000, delegate (Step left, Step right) { return left.cost - right.cost; });
            isFinityCost[startIndex] = true;
            minCost[startIndex] = 0;
            selector.Push(new Step() { cost = 0, index = startIndex });

            while (selector.count > 0)
            {
                Step one = selector.Pop();

                // 주변의 노드를 갱신시킵니다.
                for (int edgeIndex = 0; edgeIndex < graph.nodes[one.index].edge.Count; ++edgeIndex)
                {
                    Graph.Edge oneEdge = graph.nodes[one.index].edge[edgeIndex];
                    //int newCost = minCost[one.index] + one.cost;
                    int newCost = one.cost + oneEdge.cost;
                    // 얼리 리턴
                    if (isFinityCost[oneEdge.nodeIndex] && (minCost[oneEdge.nodeIndex] < newCost)) continue;
                    isFinityCost[oneEdge.nodeIndex] = true;
                    minCost[oneEdge.nodeIndex] = newCost;
                    selector.Push(new Step() { cost = newCost, index = oneEdge.nodeIndex });
                }
            }

            return minCost[destinationIndex];
        }

        static void Main(string[] args)
        {
            int resultMax = 0;

            string[] recvLineNMX = Console.ReadLine().Split(' ');
            int nodeCount = int.Parse(recvLineNMX[0]);
            edgeCount = int.Parse(recvLineNMX[1]);
            int waypointNode = int.Parse(recvLineNMX[2]) - 1; // 경유지 노드. 파티를 벌이는 곳

            graph = new Graph(nodeCount);
            for (int i = 0; i < edgeCount; ++i)
            {
                string[] recvLineOneEdge = Console.ReadLine().Split(' ');

                graph.BuildOneWay(int.Parse(recvLineOneEdge[0]) - 1, int.Parse(recvLineOneEdge[1]) - 1, int.Parse(recvLineOneEdge[2]));
            }

            for (int index = 0; index < nodeCount; ++index)
            {
                // n번째 노드가 경유지에 거쳤을때의 최솟값, 그리고 경유지에서 되돌아갔을때의 최솟값을 구합니다. 그리고 최대값인지 체크합니다.
                int oneCost = GetCost(index, waypointNode) + GetCost(waypointNode, index);

                if (resultMax < oneCost) resultMax = oneCost;
            }

            Console.WriteLine(resultMax);
        }
    }
}
