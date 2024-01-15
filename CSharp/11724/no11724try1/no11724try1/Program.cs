using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11724try1
{
    internal class Program
    {
        // 뭐 아래 세 변수는 class로 묶어두면 훌륭하긴 합니다. 전부 같은 index로 접근하니까...
        static bool[] isReachedNode;
        static int[,] connectedNodeIndex; // 연결된 노드의 인덱스 값입니다.
        static int[] connectedNodeSize; // 해당 노드가 몇개의 노드와 연결되었는지를 표시합니다.

        static void Init(int nodeCount)
        {
            isReachedNode = new bool[nodeCount];
            connectedNodeIndex = new int[nodeCount, nodeCount];
            connectedNodeSize = new int[nodeCount];
        }

        static void SetConnect(int indexA, int indexB) // 번호와 인덱스는 다름에 주의
        {
            connectedNodeIndex[indexA, connectedNodeSize[indexA]] = indexB;
            connectedNodeSize[indexA]++;
            connectedNodeIndex[indexB, connectedNodeSize[indexB]] = indexA;
            connectedNodeSize[indexB]++;
        }

        static void Spread(int targetNodeIndex)
        {
            // 너비 우선 탐색을 진행한다.
            // 지역 변수
            int[] searchQueue = new int[isReachedNode.Length];
            int queueRear = 0;
            int queueNewElement = 0;

            // 지역 함수
            int Pop()
            {
                if (queueNewElement - queueRear == 0) return -1;
                ++queueRear;
                return searchQueue[queueRear - 1];
            }
            void Push(int data)
            {
                searchQueue[queueNewElement] = data;
                ++queueNewElement;
            }

            // 실행 코드
            Push(targetNodeIndex);
            isReachedNode[targetNodeIndex] = true;
            while (queueNewElement - queueRear > 0)
            {
                int oneIndex = Pop();

                
                for (int index = 0; index < connectedNodeSize[oneIndex]; ++index)
                {
                    int connectedNode = connectedNodeIndex[oneIndex, index];
                    if (isReachedNode[connectedNode] == false)
                    {
                        isReachedNode[connectedNode] = true;
                        Push(connectedNode);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int result = 0;

            string[] nums = Console.ReadLine().Split(' ');
            Init(int.Parse(nums[0]));
            int connectCount = int.Parse(nums[1]);

            // 간선 Init
            for (int i = 0; i < connectCount; ++i)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                SetConnect(int.Parse(recvLine[0]) - 1, int.Parse(recvLine[1]) - 1);
            }

            // 탐색 작업
            // 1회 탐색마다 isReachedNode배열의 일부가 true로 변함. 그렇게 되면 다음 원소들 중 가장 처음 원소가 false인것을 찾고, 그 인덱스에 탐색을 다시 하며 result를 1 추가.
            for (int index = 0; index < isReachedNode.Length; ++index)
            {
                if (isReachedNode[index] == false)
                {
                    // 닿지 않은 대상이 있네요.
                    // -> 탐색 시작
                    // + result 추가

                    Spread(index);
                    ++result;
                }
            }

            Console.WriteLine(result);
        }
    }
}
