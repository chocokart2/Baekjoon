using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1277try1
{
    internal class Program
    {
        public static double Power(double num) => num * num;

        public class CostedEdgeGraph
        {
            public class Edge
            {
                public int destinationNodeIndex;
                public double cost;
            }
            public class Node
            {
                public System.Collections.Generic.List<Edge> connectedNode;
                public double x;
                public double y;
                public double sumCost;
                public int selfIndex;

                public Node()
                {
                    connectedNode = new System.Collections.Generic.List<Edge>();
                    sumCost = double.PositiveInfinity;
                }
            }

            public Node[] data;

            public CostedEdgeGraph(int size)
            {
                data = new Node[size];
                for (int index = 0; index < size; ++index)
                {
                    data[index] = new Node();
                    data[index].selfIndex = index;
                }
            }

            public void BuildOneWay(int startIndex, int destinationIndex, double cost = 1)
            {
                data[startIndex].connectedNode.Add(
                    new Edge()
                    {
                        destinationNodeIndex = destinationIndex,
                        cost = cost
                    }
                    );
            }
            public void BuildTwoWay(int index1, int index2, double cost = 1)
            {
                BuildOneWay(index1, index2, cost);
                BuildOneWay(index2, index1, cost);
            }
        }
        class Heap<T>
        {
            // 숫자 : 작은 값일수록 우선순위가 높습니다.
            private Comparison<T> IsLeftPrecedence; // 왼쪽이 우선이면 함수의 리턴값은 양수가 아님.
            private T[] data;
            private int count;

            const int NOT_FOUND = -1;

            /// <summary>
            ///     배열 기반 Heap을 초기화합니다.
            /// </summary>
            /// <param name="size"></param>
            /// <param name="function">
            ///     (왼쪽 변수의 우선순위 - 오른쪽 변수의 우선순위)이며, 우선순위 값이 낮을수록 힙에 먼저 빠져나갑니다
            /// </param>
            public Heap(int size, Comparison<T> function)
            {
                data = new T[size + 1];
                count = 0;
                IsLeftPrecedence = function;
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
            public void Refresh()
            {
                Heap<T> result = new Heap<T>(data.Length, IsLeftPrecedence);
                while (count > 0)
                {
                    result.Push(Pop());
                }
                count = result.count;
                data = result.data;
            }
            public int Count => count;

            protected void M_Swap(int leftIndex, int rightIndex)
            {
                T temp = data[leftIndex];
                data[leftIndex] = data[rightIndex];
                data[rightIndex] = temp;
            }

            protected void M_Heapify(int targetIndex)
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
            protected int M_FindMotherIndex(int targetIndex) => (targetIndex < 2) ? NOT_FOUND : targetIndex >> 1;
            protected int M_FindDaughterIndex(int targetIndex)
            {
                int result = NOT_FOUND;
                if ((targetIndex << 1) > count) return result;
                result = (targetIndex << 1);
                if (result + 1 > count) return result;
                if (M_IsLeftPriority(data[result], data[result + 1])) return result;
                return result + 1;
            }
            protected bool M_IsLeftPriority(T left, T right)
                => IsLeftPrecedence(left, right) <= 0;
        }
        static void Main(string[] args)
        {
            // 

            // 발전소 간 가능한 모든 연결을 생성한다
            // => 100만번의 연산이 진행됨
            // ->두 발전소를 선택
            // -> 만약 해당 발전소가 연결이 가능하면 && 이미 연결된 발전소 관계가 아니라면
            // -> 새로운 선을 생성하고 코스트를 입력한다 / 이미 연결된 발전소 관계라면 코스트는 0이라고 간주한다.

            // 그래프가 생성됨
            // 그래프를 따라 데이크스트라를 진행한다. 이때, 새롭게 생성된 전선을 따라가는 경우 코스트 계산을 하고, 그렇지 않은 선을 따라가는 경우 증가 코스트는 0이다.

            string[] recvLineNW = Console.ReadLine().Split(' ');
            int numN = int.Parse(recvLineNW[0]);
            int numW = int.Parse(recvLineNW[1]);
            double limit = double.Parse(Console.ReadLine());

            CostedEdgeGraph graph = new CostedEdgeGraph(numN);
            for (int index = 0; index < numN; index++)
            {
                string[] position = Console.ReadLine().Split(' ');

                graph.data[index].x = int.Parse(position[0]);
                graph.data[index].y = int.Parse(position[1]);
            }

            for (int i = 0; i < numW; i++)
            {
                string[] point = Console.ReadLine().Split(' ');
                int left = int.Parse(point[0]) - 1;
                int right = int.Parse(point[1]) - 1;

                graph.BuildTwoWay(
                    left,
                    right,
                    0// 
                    );
            }

            // O(N ^ 2) 작업 진행
            for (int index1 = 0; index1 < numN - 1; ++index1)
            {
                for (int index2 = index1 + 1; index2 < numN; ++index2)
                {
                    double cost =
                        Math.Sqrt(
                            Power(graph.data[index1].x - graph.data[index2].x)
                            + Power(graph.data[index1].y - graph.data[index2].y)
                            );

                    if (cost > limit) { continue; }

                    graph.BuildTwoWay(
                        index1,
                        index2,
                        cost
                        );
                }
            }


            Heap<CostedEdgeGraph.Node> selecter =
                new Heap<CostedEdgeGraph.Node>(2_000_000, 
                delegate (CostedEdgeGraph.Node left, CostedEdgeGraph.Node right)
                {
                    if (left.sumCost < right.sumCost) return -1;
                    if (left.sumCost > right.sumCost) return 1;
                    return 0;
                }
                );
            bool[] hasVisited = new bool[numN];
            // selecter에서 이미 방문했던 것을 대상으로 또 pop하는 경우도 있긴 하지만,
            // Selecter에서 싼 가격으로 접근하는 것을 우선으로 하기 때문에, 꺼냈는데 hasvisited가 트루값이면 무시

            graph.data[0].sumCost = 0;
            selecter.Push(graph.data[0]);
            while (selecter.Count > 0)
            {
                CostedEdgeGraph.Node one = selecter.Pop();
                //Console.WriteLine($">> {one.selfIndex} -> {one.sumCost}");
                if (hasVisited[one.selfIndex]) continue; // 더 싼 방법으로 한번 방문했습니다!
                hasVisited[one.selfIndex] = true;

                for (int index = 0; index < one.connectedNode.Count; ++index)
                {
                    if (hasVisited[one.connectedNode[index].destinationNodeIndex]) continue;

                    graph.data[one.connectedNode[index].destinationNodeIndex].sumCost
                        = Math.Min(graph.data[one.connectedNode[index].destinationNodeIndex].sumCost,
                        one.sumCost + one.connectedNode[index].cost
                        );
                    selecter.Push(graph.data[one.connectedNode[index].destinationNodeIndex]);
                }
            }


            Console.WriteLine((int)(graph.data[numN - 1].sumCost * 1000));
        }
    }
}
