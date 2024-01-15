using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10472try1
{
    internal class Program
    {
        public class MapToNum
        {
            public int data;
            public int step = -1;
            public bool[,] GetMap()
            {
                bool[,] result = new bool[3, 3];

                for (int y = 0; y < 3; ++y)
                {
                    for (int x = 0; x < 3; ++x)
                    {
                        int temp = 1 << (y * 3 + 1);
                        if ((data & temp) == temp) result[x, y] = true;
                    }
                }
                return result;
            }
            public void SetMap(bool[,] map)
            {
                data = 0;
                for (int y = 0; y < 3; ++y)
                {
                    for (int x = 0; x < 3; ++x)
                    {
                        if (map[x, y])
                        {
                            data &= 1 << (y * 3 + x);
                        }
                    }
                }
            }
        }
        public class Graph<TNodeData, TEdgeData>
        {
            // NestedClass
            public class Edge
            {
                public Node connectedNode;
                public TEdgeData containData;
            }
            public class Node
            {
                public int index; // 인덱스 접근을 위하여
                public TNodeData containData;
                public System.Collections.Generic.List<Edge> edges;

                public Node()
                {
                    edges = new System.Collections.Generic.List<Edge>();
                }
            }

            // Fields
            public Node[] nodes;

            // Constructor
            public Graph() { }
            public Graph(int size)
            {
                nodes = new Node[size];
                for (int index = 0; index < size; ++index)
                {
                    nodes[index] = new Node();
                    nodes[index].index = index;
                }
            }
            /// <summary>
            ///     초기화 함수입니다.
            /// </summary>
            /// <param name="size"></param>
            /// <param name="initData"> 각 노드마다 존재할 데이터입니다. 구조체가 아닌 클래스인경우, 얕은 복사에 주의하세요</param>
            public Graph(int size, TNodeData initData) : this(size)
            {
                for (int index = 0; index < size; ++index)
                {
                    nodes[index].containData = initData;
                }
            }

            // Function
            public void BuildOneWay(int begin, int destination, TEdgeData data)
            {
                nodes[begin].edges.Add(
                    new Edge()
                    {
                        connectedNode = nodes[destination],
                        containData = data
                    }
                    );
            }
            public void BuildTwoWay(int begin, int destination, TEdgeData data)
            {
                BuildOneWay(begin, destination, data);
                BuildOneWay(destination, begin, data);
            }
            public void BuildTwoWay(int begin, int destination, TEdgeData beginData, TEdgeData destinationData)
            {
                BuildOneWay(begin, destination, beginData);
                BuildOneWay(destination, begin, destinationData);
            }
        }


        static void Main(string[] args)
        {
            Graph<MapToNum, bool> graph = new Graph<MapToNum, bool>(512);
            for (int index = 0; index < graph.nodes.Length; ++index)
            {
                graph.nodes[index].containData.data = index;
            }

            int[] queueData = new int[graph.nodes.Length + 1];
            queueData[0] = 0;
            int queueHead = 1;
            int queueTail = 0;
            // ...
            // ...
            // ...
            graph.nodes[0].containData.step = 0;

            while (queueHead > queueTail)
            {
                int one = queueData[queueTail];
                queueTail++;

                // 해당 타일에 뒤집기를 시전한다.
                bool[,] oneMap = graph.nodes[one].containData.GetMap();

                for (int x = 0; )

            }

        }
    }
}
