using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace no9466try1
{
    internal class Program
    {
        public enum EStatus
        {
            unknown,
            enlisted,
            outSide
        }
        class Node
        {
            public int key;
            public Node mate;
            public EStatus status;
        }

        static void Main(string[] args)
        {
            // 1. 그래프 구성 이때 s1 -> s2이면 s2의 멤버 변수에 s1을 추가
            // 1.2. 만약 자신을 참조하는 경우, isSolo값을 true로 설정
            // 2. 자신을 참조하는 각 노드들 선택
            // 2.1. 각 노드마다 그래프 탐색을 해서 자신을 참조했던 다른 노드들을 찾음
            StringBuilder result = new StringBuilder();
            for (int t = int.Parse(Console.ReadLine()); t > 0; --t)
            {
                int oneResult = 0;

                Node[] graph = new Node[int.Parse(Console.ReadLine())];
                for (int index = 0; index < graph.Length; ++index)
                {
                    graph[index] = new Node()
                    {
                        key = index,
                        status = EStatus.unknown
                    };
                }
                string[] edges = Console.ReadLine().Split(' ');
                for (int index = 0; index < edges.Length; ++index)
                {
                    int one = int.Parse(edges[index]) - 1;
                    if (index == one)
                    {
                        graph[index].status = EStatus.enlisted;
                    }
                    graph[index].mate = graph[one];
                }
                // 그래프 탐색
                // 깊이 우선 탐색
                // 각 탐색
                // 찾은 팀의 목록
                // 순환하기 시작한 사람
                // -> 순환하기 시작한 사람부터 팀에 합류했다는 표시
                // -> 시작지점부터 순환하기 시작한 사람 이전의 사람까지는 팀에 합류하지 못했다는 표시
                for (int index = 0; index < graph.Length; ++index)
                {
                    Node start = graph[index];
                    if (start.status != EStatus.unknown) continue;
                    HashSet<Node> foundElements = new HashSet<Node>();
                    foundElements.Add(start);
                    Node loopStart;
                    Node current = start;
                    bool isReachOtherGraph = false;
                    // 깊이 우선 탐색 시작
                    while (true)
                    {
                        current = current.mate;
                        if (current.status != EStatus.unknown)
                        {
                            isReachOtherGraph = true;
                        }
                        if (foundElements.Contains(current) || 
                            (current.status != EStatus.unknown))
                        {
                            // 루프를 중단합니다.
                            loopStart = current;
                            break;
                        }
                        foundElements.Add(current);
                    }

                    // 팀에 합류하지 못한 사람 추가
                    current = start;
                    while (current.key != loopStart.key)
                    {
                        oneResult++;
                        current.status = EStatus.outSide;
                        current = current.mate;
                    }

                    if (isReachOtherGraph == false)
                    {
                        // loopStart 값 바꾸기
                        current.status = EStatus.enlisted;
                        current = current.mate;

                        while (current.key != loopStart.key)
                        {
                            current.status = EStatus.enlisted;
                            current = current.mate;
                        }
                    }
                }

                result.AppendLine(oneResult.ToString());
            }
            Console.Write(result);
        }
    }
}
