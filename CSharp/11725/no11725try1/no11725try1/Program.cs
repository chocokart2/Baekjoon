using System;
using System.Collections.Generic;
using System.Text;

namespace no11725try1
{
    internal class Program
    {
        static int size;
        static List<int>[] connected;


        //static bool[,] graph;

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            size = int.Parse(Console.ReadLine());
            connected = new List<int>[size];
            for (int index = 0; index < size; ++index) connected[index] = new List<int>();
            //graph = new bool[size, size];// 공간(N ^ 2)
            int[] motherNodeIndex = new int[size]; // 공간 (N * 4)
            int[] nextVisitQueueData = new int[size];
            int nextVisitQueueRear = 0;
            int nextVisitQueueHead = 0;

            //Queue<int> nextSteps = new Queue<int>(capacity: size + 1);

            for (int i = 0; i < size - 1; ++i)
            {
                string[] recvNums = Console.ReadLine().Split(' ');

                int node1 = int.Parse(recvNums[0]) - 1;
                int node2 = int.Parse(recvNums[1]) - 1;

                //graph[node1, node2] = true;
                connected[node1].Add(node2);
                connected[node2].Add(node1);
                //graph[node2, node1] = true;
            }

            //nextSteps.Enqueue(0);
            nextVisitQueueData[nextVisitQueueHead] = 0;
            nextVisitQueueHead = 1;

            //while(nextSteps.Count > 0)
            while(nextVisitQueueHead - nextVisitQueueRear > 0)
            {
                //int currentNodeIndex = nextSteps.Dequeue();
                int currentNodeIndex = nextVisitQueueData[nextVisitQueueRear];
                //Console.WriteLine($"While Loop : currentNodeIndex = {currentNodeIndex}");
                ++nextVisitQueueRear;

                //for (int index = 0; index < connected[currentNodeIndex].Count; ++index)
                //{
                //    Console.WriteLine($"While Loop : 이 노드의 주변 노드 : {connected[currentNodeIndex][index]}");
                //}

                for (int index = 0; index < connected[currentNodeIndex].Count; ++index)
                {
                    if (connected[currentNodeIndex][index] == motherNodeIndex[currentNodeIndex]) continue;
                    //Console.WriteLine($"추가하려는 노드 : {currentNodeIndex}");
                    
                    motherNodeIndex[connected[currentNodeIndex][index]] = currentNodeIndex;

                    nextVisitQueueData[nextVisitQueueHead] = connected[currentNodeIndex][index];
                    ++nextVisitQueueHead;
                }
            }

            for (int index = 1; index < size; ++index)
            {
                result.Append($"{motherNodeIndex[index] + 1}\n");
            }
            Console.WriteLine(result);
        }
    }
}
