using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1753try1
{
    internal class Program
    {
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
            public int cost;
            public int index;
        }

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

        static void Main(string[] args)
        {
            string[] recvLineVE = Console.ReadLine().Split(' ');
            int nodeCount = int.Parse(recvLineVE[0]);
            int edgeCount = int.Parse(recvLineVE[1]);

            int startIndex = int.Parse(Console.ReadLine()) - 1;

            CostedEdgeGraph graph = new CostedEdgeGraph(nodeCount);

            for (int line = 0; line < edgeCount; ++line)
            {
                string[] recvLineOneEdge = Console.ReadLine().Split(' ');

                graph.BuildOneWay(int.Parse(recvLineOneEdge[0]) - 1, int.Parse(recvLineOneEdge[1]) - 1, int.Parse(recvLineOneEdge[2]));
                //Console.WriteLine($"DEBUG : 노드 {recvLineOneEdge[0]}의 간선 개수 : {graph.data[int.Parse(recvLineOneEdge[0]) - 1].connectedNode.Count}");
            }
            
            // 다익스트라 준비!
            bool[] isFintyCost = new bool[nodeCount];
            int[] cost = new int[nodeCount]; // 최대 코스트 : 199_990
            Heap<Step> selecter = new Heap<Step>(edgeCount, delegate(Step a, Step b) { return a.cost - b.cost; });
            isFintyCost[startIndex] = true;
            cost[startIndex] = 0;
            selecter.Push(new Step() { cost = 0, index = startIndex });
            
            while (selecter.count > 0)
            {
                //Console.WriteLine();
                Step one = selecter.Pop();
                //Console.WriteLine($"DEBUG : 현재 힙의 노드 : (index = {one.index}, cost = {one.cost})");
                if ((isFintyCost[one.index] == true) && (cost[one.index] < one.cost)) continue;

                if (graph.data[one.index].connectedNode.Count == 0)
                {
                    //Console.WriteLine($"DEBUG : 노드 {one.index + 1}의 간선 개수 : {graph.data[one.index].connectedNode.Count}");
                    //Console.WriteLine($"DEBUG : ㄴ 해당 노드에 연결된 노드가 존재하지 않습니다.");
                }
                // 한 노드를 선택하고, 그 노드에 연결된 간선을 모두 탐색해봅니다.
                for (int edgeIndex = 0; edgeIndex < graph.data[one.index].connectedNode.Count; ++edgeIndex)
                {
                    CostedEdgeGraph.Edge oneEdge = graph.data[one.index].connectedNode[edgeIndex];

                    //Console.WriteLine($"DEBUG : ㄴ 간선의 상태 : ( destination = {oneEdge.destinationNodeIndex}, cost = {oneEdge.cost})");
                    //Console.WriteLine($"DEBUG : ㄴ 당시의 코스트 : {((isFintyCost[oneEdge.destinationNodeIndex]) ? cost[oneEdge.destinationNodeIndex].ToString() : "infinity")}");

                    // 얼리 리턴 패턴 : 만약 코스트가 더 작으면 힙에 추가합니다.
                    if ((isFintyCost[oneEdge.destinationNodeIndex] == true) && (cost[oneEdge.destinationNodeIndex] <= cost[one.index] + oneEdge.cost))
                    {
                        //Console.WriteLine($"DEBUG : PASS");

                        continue;
                    }

                    isFintyCost[oneEdge.destinationNodeIndex] = true;
                    cost[oneEdge.destinationNodeIndex] = cost[one.index] + oneEdge.cost;
                    selecter.Push(
                        new Step()
                        {
                            cost = cost[oneEdge.destinationNodeIndex],
                            index = oneEdge.destinationNodeIndex
                        });
                    //Console.WriteLine($"DEBUG : ㄴ 힙에 새 노드를 추가합니다 : ( index = {oneEdge.destinationNodeIndex}, cost = {cost[oneEdge.destinationNodeIndex]} )");
                }
            }

            StringBuilder result = new StringBuilder();

            for (int index = 0; index < nodeCount; ++index)
            {
                if (isFintyCost[index])
                {
                    result.Append($"{cost[index]}\n");
                }
                else
                {
                    result.Append("INF\n");
                }
            }

            Console.Write(result);
        }
    }
}
