using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1967try1
{
    internal class Program
    {
        class ArrayStack<T>
        {
            public T[] array;
            public int cursor; // 마지막 원소의 다음을 가리킵니다.
            public int Count { get => cursor; }

            public ArrayStack(int size)
            {
                array = new T[size];
                cursor = 0;
            }

            public void Push(T item)
            {
                array[cursor] = item;
                cursor++;
            }
            public T Peek() => array[cursor - 1];
            public (bool, T) Pop()
            {
                if (cursor < 1)
                {
                    //Console.WriteLine("!!!!!");
                    return (false, default);
                }
                cursor--;
                return (true, array[cursor]);
            }
            public T[] ToArray()
            {
                return array;
            }
        }
        class Tree
        {
            public Node[] nodes;

            public Tree(int length)
            {
                nodes = new Node[length];
                for (int index = 0; index < length; ++index)
                    nodes[index] = new Node();
            }
            public void Connect(int indexA, int indexB, int cost)
            {
                nodes[indexA].connected.Add(new Line() { index = indexB, cost = cost });
                nodes[indexB].connected.Add(new Line() { index = indexA, cost = cost });
            }
        }

        class Node
        {
            public List<Line> connected;

            public Node()
            {
                connected = new List<Line>();
            }
        }

        class Line
        {
            public int index;
            public int cost;
        }

        static Tree tree;
        
        static (int index, int maxCost) DepthFirstSearch(int index)
        {
            // 해당 노드에서 가장 먼 노드까지의 거리를 리턴합니다

            ArrayStack<int> m_cursor = new ArrayStack<int>(tree.nodes.Length);
            ArrayStack<int> m_currentCost = new ArrayStack<int>(tree.nodes.Length);
            int m_currentCostSum = 0;
            bool[] m_isVisited = new bool[tree.nodes.Length];
            int m_maxCost = 0;
            int m_maxCostIndex = 0;

            m_cursor.Push(index);
            m_isVisited[index] = true;

            while(m_cursor.Count > 0)
            {
                int m_oneIndex = m_cursor.Peek();
                Node m_one = tree.nodes[m_oneIndex];

                // 현재 노드에서 방문하지 않은 노드가 있는지 확인합니다.
                bool m_foundNew = false;
                for (int m_index = 0; m_index < m_one.connected.Count; ++m_index)
                {
                    if (m_isVisited[m_one.connected[m_index].index]) continue;

                    // 만약 방문할 수 있는 노드가 없다면 아래 코드는 실행되지 않습니다.
                    m_foundNew = true;
                    m_isVisited[m_one.connected[m_index].index] = true;
                    m_cursor.Push(m_one.connected[m_index].index);
                    m_currentCost.Push(m_one.connected[m_index].cost);
                    m_currentCostSum += m_one.connected[m_index].cost;

                    int m_costSum = 0;
                    // 해당 위치까지 코스트를 연산
                    for (int stackIndex = 0; stackIndex < m_currentCost.Count; ++stackIndex)
                        m_costSum += m_currentCost.array[stackIndex];
                    // 최대값인지 체크하는것도 넣기
                    //if (m_maxCost < m_costSum) m_maxCost = m_costSum;
                    if (m_maxCost < m_currentCostSum)
                    {
                        m_maxCost = m_currentCostSum;
                        m_maxCostIndex = m_one.connected[m_index].index;
                    }

                    break;
                }

                if (m_foundNew == false) // 접근가능한 미방문 노드가 없는 경우입니다.
                {
                    m_cursor.Pop();
                    m_currentCostSum -= m_currentCost.Pop().Item2;
                }
            }

            return (m_maxCostIndex, m_maxCost);
        }

        static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine());
            int max = 0;

            tree = new Tree(nodeCount);
            for (int i = 0; i < nodeCount - 1; ++i)
            {
                string[] connectLine = Console.ReadLine().Split(' ');
                tree.Connect(int.Parse(connectLine[0]) - 1, int.Parse(connectLine[1]) - 1, int.Parse(connectLine[2]));
            }
            (int index, int cost) one = DepthFirstSearch(0);
            (int index, int cost) second = DepthFirstSearch(one.index);
            Console.WriteLine(second.cost);

            //for (int index = 0; index < nodeCount; ++index)
            //{
            //    (int index, int cost) one = DepthFirstSearch(index);
            //    if (max < one) max = one;
            //}

            //Console.WriteLine(max);
        }
    }
}
