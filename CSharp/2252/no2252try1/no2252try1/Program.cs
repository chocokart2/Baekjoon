using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace no2252try1
{
    internal class Program
    {
        class NodePtr
        {
            public int num;
            public List<NodePtr> next;
            public HashSet<int> nextContainsNum; // 중복을 무효화시켜서 큐에 값이 중복해서 들어가는것을 막습니다.
            public int countOfEnterence;
            public bool hasVisited;
        }

        class Heap
        {
            // 숫자 : 작은 값일수록 우선순위가 높습니다.
            private Comparison<NodePtr> IsLeftPrecedence; // 왼쪽이 우선이면 함수의 리턴값은 양수가 아님.
            private NodePtr[] data;
            private int count;
            private Dictionary<int, int> key2index;


            private const bool M_IS_DEBUGGING = false;
            const int NOT_FOUND = -1;

            /// <summary>
            ///     배열 기반 Heap을 초기화합니다.
            /// </summary>
            /// <param name="size"></param>
            /// <param name="function">
            ///     (왼쪽 변수의 우선순위 - 오른쪽 변수의 우선순위)이며, 우선순위 값이 낮을수록 힙에 먼저 빠져나갑니다
            /// </param>
            public Heap(int size)
            {
                data = new NodePtr[size + 1];
                count = 0;
                IsLeftPrecedence = delegate (NodePtr left, NodePtr right)
                { return left.countOfEnterence - right.countOfEnterence; };
                key2index = new Dictionary<int, int>();
            }
            public void Push(NodePtr item)
            {
                if (M_IS_DEBUGGING)
                {
                    Console.WriteLine($"HEAP.Push() >> 입력됨 {item.num}");
                }
                ++count;
                data[count] = item;
                key2index.Add(item.num, count);
                M_Heapify(count);                
            }
            public NodePtr Peek()
            {
                if (count < 1) return default;
                return data[1];
            }
            public NodePtr Pop()
            {
                if (M_IS_DEBUGGING)
                {
                    Console.WriteLine($"HEAP.Pop() 호출됨");
                }
                if (count < 1) return default;
                key2index[data[count].num] = 1;

                NodePtr result = data[1];
                data[1] = data[count];
                count--;
                if (M_IS_DEBUGGING)
                {
                    Console.WriteLine($"HEAP.Pop() >> Key2Index의 값 제거 {result.num}");
                }
                key2index.Remove(result.num);
                M_Heapify(1);
                // 힙정렬 이후의 결과
                if (M_IS_DEBUGGING)
                {
                    Console.WriteLine($"HEAP.Pop() : 정렬 결과 >> {ForceGetString(GetStr)}");
                    if (Peek() != null) Console.WriteLine($"HEAP.Pop() : 첫째 >> {Peek().num}");
                }
                return result;
            }
            public void Refresh()
            {
                Heap result = new Heap(data.Length);
                while (count > 0)
                {
                    result.Push(Pop());
                }
                count = result.count;
                data = result.data;
            }
            public int Count => count;
            public void Heapify(int key)
            {
                if (M_IS_DEBUGGING)
                {
                    Console.WriteLine($"HEAP.Heapify() >> 키 값이 {key}인 원소 => {key2index[key]}번째 원소를 재배열합니다.");
                }
                M_Heapify(key2index[key]);
            }
            public string ForceGetString(Func<NodePtr, string> GetString)
            {
                StringBuilder answer = new StringBuilder();
                if (count < 1) return "EMPTY";
                for (int index = 1; index <= count; index++)
                {
                    answer.Append($"{GetString(data[index])} ");
                }
                answer.Remove(answer.Length - 1, 1);
                return answer.ToString();
            }

            protected void M_Swap(int leftIndex, int rightIndex)
            {
                // key2index[data[leftIndex].num] = rightIndex;
                // key2index[data[rightIndex].num] = leftIndex;

                NodePtr temp = data[leftIndex];
                data[leftIndex] = data[rightIndex];
                data[rightIndex] = temp;


                key2index[data[leftIndex].num] = leftIndex;
                key2index[data[rightIndex].num] = rightIndex;
            }

            protected void M_Heapify(int targetIndex)
            {
                if (M_IS_DEBUGGING)
                {
                    Console.WriteLine($"HEAP.M_Heapify({targetIndex})");
                }
                bool hasChanged = false;
                for (int currentIndex = targetIndex, daughterIndex = M_FindDaughterIndex(targetIndex);
                    daughterIndex != NOT_FOUND;
                    currentIndex = daughterIndex, daughterIndex = M_FindDaughterIndex(daughterIndex))
                {
                    if (M_IsLeftPriority(data[currentIndex], data[daughterIndex])) break; // 정상화가 된 상태입니다.
                    M_Swap(currentIndex, daughterIndex);
                    hasChanged = true;
                }
                for (int currentIndex = targetIndex, motherIndex = M_FindMotherIndex(targetIndex);
                    motherIndex != NOT_FOUND;
                    currentIndex = motherIndex, motherIndex = M_FindMotherIndex(motherIndex))
                {
                    if (M_IsLeftPriority(data[motherIndex], data[currentIndex])) break; // 정상화가 된 상태입니다.
                    M_Swap(motherIndex, currentIndex);
                    hasChanged = true;
                }
                if (M_IS_DEBUGGING)
                {
                    Console.WriteLine($"HEAP.M_Heapify() >> hasChanged = {(hasChanged ? "변경됨!" : "변경되지 않음!")}");
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
            protected bool M_IsLeftPriority(NodePtr left, NodePtr right)
                => IsLeftPrecedence(left, right) <= 0;
        }
        static string GetStr(NodePtr item) => item.num.ToString();


        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            bool isDebugging = false;
            string[] nums = Console.ReadLine().Split(' ');
            NodePtr[] peoples = new NodePtr[int.Parse(nums[0])];
            for (int index = 0; index < peoples.Length; ++index)
            {
                peoples[index] = new NodePtr();
                peoples[index].num = index + 1;
                peoples[index].next = new List<NodePtr>();
                peoples[index].nextContainsNum = new HashSet<int>();
            }
            if (peoples.Length == 1)
            {
                Console.WriteLine(1);
                return;
            }
            int visitedLeft = peoples.Length;
            for (int t = int.Parse(nums[1]); t > 0; --t)
            {
                string[] points = Console.ReadLine().Split(' ');
                int leftIndex = int.Parse(points[0]) - 1;
                int rightIndex = int.Parse(points[1]) - 1;

                if (peoples[leftIndex].nextContainsNum.Contains(rightIndex)) // 입력이 중복인가?
                {
                    Console.WriteLine("!!!");
                    throw new InvalidOperationException(); // 여기 작동 안함!!
                    continue;
                }
                peoples[rightIndex].countOfEnterence++;
                peoples[leftIndex].next.Add(peoples[rightIndex]);
                peoples[leftIndex].nextContainsNum.Add(rightIndex);

            }
            if (isDebugging)
            {
                foreach (NodePtr one in peoples)
                {
                    Console.WriteLine($"{one.num}번째 사람 / 입장 경로 수 : {one.countOfEnterence}");
                }
            }


            // 진입차수가 0인 정점을 꺼내 큐에 삽입
            Queue<NodePtr> queue = new Queue<NodePtr>();
            Heap lowAccessPeoples = new Heap(peoples.Length * 4);

            // 9 8
            // 6 7
            // 7 8
            // 8 9
            // 5 6
            // 1 2
            // 2 3
            // 3 4
            // 4 5

            for (int index = 0; index < peoples.Length; ++index)
            {
                if (peoples[index].countOfEnterence > 0)
                {
                    lowAccessPeoples.Push(peoples[index]);
                }
                else
                {
                    // 여기서 문제가 없다는것을 바로 알 수 있었음
                    if (isDebugging)
                    {
                        Console.WriteLine($">> 큐에 들어간 것 : {peoples[index].num} / 입장 경로 수 : {peoples[index].countOfEnterence}");
                    }
                    queue.Enqueue(peoples[index]);
                    peoples[index].hasVisited = true;
                    visitedLeft--;
                }
            }

            HashSet<int> footSteps = new HashSet<int>();


            // lowAccessPeoples에서 문제가 발생!
            while (queue.Count > 0)
            {
                if (isDebugging)
                {
                    Console.WriteLine("== 큐 루프 시작 ==");
                }
                //Console.WriteLine($">> {queue.Count}");
                // 큐에서 원소를 꺼내 연결된 모든 간선을 제거
                NodePtr one = queue.Dequeue(); // 같은 포인터가 다시 참조되선 안됩니다!
                if (isDebugging)
                {
                    Console.WriteLine($"큐에서 나온 것 : {one.num} / 입장 : {one.countOfEnterence}");
                }

                // 어썰트문
                if (one.countOfEnterence > 0)
                {
                    // 절대 실행되선 안되는 코드
                    throw new OverflowException(); // 안전
                }
                if (visitedLeft < 0)
                {
                    // 절대 실행되선 안되는 코드
                    throw new OverflowException(); // 안전
                }
                if (footSteps.Add(one.num) == false)
                {
                    throw new PlatformNotSupportedException();
                }

                //Console.WriteLine($"++ {one.num}");
                result.Append($"{one.num} ");
                //
                if (isDebugging)
                {
                    Console.WriteLine("간선 제거 시작");
                }

                for (int index = 0; index < one.next.Count; ++index)
                {
                    //if (one.next[index].hasVisited) continue;

                    one.next[index].countOfEnterence--;

                    if (one.next[index].countOfEnterence < 0)
                    {
                        Console.WriteLine("FATAL ERROR");
                        throw new ArgumentNullException(); // 여기 작동함
                    }
                    lowAccessPeoples.Heapify(one.next[index].num);
                }
                if (isDebugging)
                {
                    Console.WriteLine($"간선 제거 종료 : 힙 값 : {lowAccessPeoples.ForceGetString(GetStr)}");
                }
                // 간선 제거 이후에 진입차수가 0이 된 정점을 큐에 "전부" 삽입
                //Console.WriteLine($">>>> selecter.Count = {lowAccessPeoples.Count}");

                while (lowAccessPeoples.Count > 0)
                {
                    if (isDebugging)
                    {
                        Console.WriteLine($"HEAP 내용 >> {lowAccessPeoples.ForceGetString(GetStr)}");
                    }
                    if (lowAccessPeoples.Peek().countOfEnterence > 0) break;
                    //if (lowAccessPeoples.Peek().countOfEnterence < -1)
                    if (lowAccessPeoples.Peek().hasVisited)
                    {
                        // !! 6
                        Console.WriteLine($"오류!! {lowAccessPeoples.Peek().num}번째 객체가 Heap 내부에 중복되어 있습니다.");

                        lowAccessPeoples.Pop();
                        //Console.WriteLine("!!!!!");
                        continue;
                    }
                    //if (lowAccessPeoples.Peek().hasVisited == true) // 방문했던 노드는 전부 무시합니다.
                    //{
                    //    lowAccessPeoples.Pop();
                    //    continue;
                    //}

                    NodePtr nextOne = lowAccessPeoples.Pop();
                    //Console.WriteLine($"하나 빠져나감. selecter.Count = {lowAccessPeoples.Count}");
                    //Console.WriteLine($"이때 현재의 NEXT nextOne.hasVisited = {nextOne.hasVisited}");

                    // 힙에 같은 원소가 동시에 들어갔습니다!\
                    if (isDebugging)
                    {
                        Console.WriteLine($">> 큐로 등록되었습니다 : {nextOne.num}");
                    }

                    queue.Enqueue(nextOne);
                    nextOne.hasVisited = true;
                    // 정리 -> 자신에게 접근헐 수 있는 객체가 없어야지만 true로 변경된다고 가정
                    visitedLeft--;
                }
            }
            result.Remove(result.Length - 1, 1);
            Console.WriteLine(result.ToString());
        }
    }
}
