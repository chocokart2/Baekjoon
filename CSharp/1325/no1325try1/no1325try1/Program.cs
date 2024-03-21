using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1325try1
{
    internal class Program
    {
        class Graph
        {
            public class Node
            {
                public int index;
                public string name;
                public List<Node> arcs; // 자기보다 나이가 적은 사람의 목록
            }
            public Node[] data;
            public Dictionary<string, int> name2index;

            public Node this[string name]
            {
                get
                {
                    return data[name2index[name]];
                }
                set
                {
                    data[name2index[name]] = value;
                }
            }

            public void TryAdd(string name)
            {
                if (name2index.ContainsKey(name) == false)
                {
                    name2index.Add(name, name2index.Count);
                    data[name2index[name]] = new Node()
                    {
                        index = name2index[name],
                        name = name,
                        arcs = new List<Node>()
                    };
                }
            }
        }

        static bool Search(Graph data, Graph.Node start, Graph.Node end)
        {
            Queue<Graph.Node> next = new Queue<Graph.Node>();
            bool[] hasVisited = new bool[data.data.Length];
            next.Enqueue(start);
            hasVisited[start.index] = true;
            
            while (next.Count > 0)
            {
                Graph.Node one = next.Dequeue();

                if (one.index == end.index) return true;

                for (int index = 0; index < one.arcs.Count; ++index)
                {
                    if (hasVisited[one.arcs[index].index])
                    {
                        continue;
                    }

                    next.Enqueue(one.arcs[index]);
                    hasVisited[one.arcs[index].index] = true;
                }
            }
            return false;
        }


        static void Main(string[] args)
        {
            string[] recvLineNM = Console.ReadLine().Split(' ');
            int peopleCount = int.Parse(recvLineNM[0]);
            int skillCount = int.Parse(recvLineNM[1]);
            // 나이를 알 수 있는 것을 기록할때만 가능.
            Graph graph = new Graph();
            graph.data = new Graph.Node[peopleCount];
            graph.name2index = new Dictionary<string, int>();

            // 그래프 기록
            for (int i = 0; i < skillCount; ++i)
            {
                string[] name = Console.ReadLine().Split(' ');
                graph.TryAdd(name[0]);
                graph.TryAdd(name[1]);

                graph[name[0]].arcs.Add(graph[name[1]]);
            }
            // 반드시 없는 사항 : 이 그래프는 루프가 없습니다!

            StringBuilder result = new StringBuilder();
            for (int i = int.Parse(Console.ReadLine()); i > 0; --i)
            {
                string[] name = Console.ReadLine().Split(' ');
                if (name[0].Equals(name[1]))
                {
                    result.Append("gg ");
                    continue;
                }

                if ((graph.name2index.ContainsKey(name[0]) == false) ||
                    (graph.name2index.ContainsKey(name[1]) == false))
                {
                    result.Append("gg ");
                    continue;
                }


                // 그래프 탐색 실시
                if (Search(graph, graph[name[0]], graph[name[1]]))
                {
                    result.Append($"{name[0]} ");
                    continue;
                }
                if (Search(graph, graph[name[1]], graph[name[0]]))
                {
                    result.Append($"{name[1]} ");
                    continue;
                }
                result.Append("gg ");
            }
            Console.WriteLine(result);
        }
    }
}
