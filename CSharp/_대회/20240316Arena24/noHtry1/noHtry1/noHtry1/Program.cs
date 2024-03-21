using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace noHtry1
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

        static int Search()
        {
            Console.Out.WriteLine("maze");
            Console.Out.Flush();
            return int.Parse(Console.ReadLine());
        }
        static void Run(int position)
        {
            Console.Out.WriteLine($"gaji {position}");
            Console.Out.Flush();
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            // 솔직히 한별이 이쁘다



            // 깊이 우선 탐색 활용하기
            // 너비 우선 탐색을 사용할 수 없습니다. 탐색자는 단 한명으로만 제한된 경우입니다.
            StringBuilder result = new StringBuilder();
            result.AppendLine("answer");
            int size = int.Parse(Console.ReadLine());

            bool[] hasVisited = new bool[size];
            int visitedCount = 1;

            // 만약 maze를 썼는데, 방문한 노드에 다시 방문하게 된다면, 해당체크포인트까지 회귀합니다.

            Stack<int> visitedHistory = new Stack<int>(); // maze를 할때마다 쌓입니다.
            visitedHistory.Push(1);
            hasVisited[0] = true;

            while (visitedCount < size)
            {
                int currentPos = visitedHistory.Peek();

                int nextPos = Search();

                if (hasVisited[nextPos - 1])
                {
                    // old
                    Run(currentPos);
                    visitedHistory.Pop();
                    Run(visitedHistory.Peek());
                }
                else
                {
                    // new
                    result.AppendLine($"{currentPos} {nextPos}");
                    hasVisited[nextPos - 1] = true;
                    visitedCount++;
                    visitedHistory.Push(nextPos);
                }

            }


            Console.Write(result);
            // 말단 회전에 대한 연산을 해야 한다.
            // 한걸음 더 내딛기()
            // 현재의 위치 x를 기억한다.
            // maze를 한다 해당 값은 y다.
            // - 만약 방문한 가지라면?
            // - - Run(x)
            // - - 스택을 이용하여 이전 위치로 이동 및 팝
            // - - 한걸음 더 내딛기()를 반복
            // - 아니요
            // - - 간선을 기억한다.
            // - - 방문 횟수를 1씩 증가한다.
            // - - 스택에 y값을 저장한다.
            // - - 방문 기록을 추가한다.
            // - - 한걸음 더 내딛기()를 반복



        }
    }
}
