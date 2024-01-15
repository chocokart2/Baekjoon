using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2644try1
{
    internal class Program
    {

        public class SimpleGraph
        {
            public class Node
            {
                public List<int> connectedIndex;
                public int step;

                public Node()
                {
                    connectedIndex = new List<int>();
                    step = -1;
                }
            }

            public Node[] data;

            public SimpleGraph(int size)
            {
                data = new Node[size];
                for (int i = 0; i < size; ++i)
                {
                    data[i] = new Node();
                }
            }
            public void BuildTwoWay(int indexA, int indexB)
            {
                data[indexA].connectedIndex.Add(indexB);
                data[indexB].connectedIndex.Add(indexA);
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
            int peopleCount = int.Parse(Console.ReadLine());
            string[] targetNum = Console.ReadLine().Split(' ');
            int start = int.Parse(targetNum[0]) - 1;
            int finish = int.Parse(targetNum[1]) - 1;
            SimpleGraph family = new SimpleGraph(peopleCount);
            int bridgeCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < bridgeCount; ++i)
            {
                string[] one = Console.ReadLine().Split(' ');

                family.BuildTwoWay(int.Parse(one[0]) - 1, int.Parse(one[1]) - 1);
            }

            // 그래프 탐색
            int[] queueData = new int[101];
            queueData[0] = start;
            int queueHead = 1;
            int queueTail = 0;
            family.data[start].step = 0;

            while (queueHead > queueTail)
            {
                int one = queueData[queueTail];
                ++queueTail;

                // 주변으로 흩뿌림
                for (int index = 0; index < family.data[one].connectedIndex.Count; ++index)
                {
                    int oneEdgeDestination = family.data[one].connectedIndex[index];

                    if (family.data[oneEdgeDestination].step != -1) continue;

                    queueData[queueHead] = oneEdgeDestination;
                    queueHead++;
                    family.data[oneEdgeDestination].step = family.data[one].step + 1;
                }
            }

            Console.WriteLine(family.data[finish].step);
        }
    }
}
