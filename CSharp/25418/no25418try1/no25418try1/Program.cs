using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no25418try1
{
    internal class Program
    {
        const int EMPTY = 0;
        static int[] steps = new int[1_000_001];
        // 인풋은 반드시 연산 가능하다는것으로 전제한다.

        static int[] queueArray = new int[1_000_001];
        static int rear = 0;
        static int head = 0;



        static void Add(int item)
        {
            queueArray[head] = item;
            head++;
        }

        static int Out()
        {
            return queueArray[rear++];
        }
        static void TryAdd(int start, int destination)
        {
            if (destination >= steps.Length) return;
            if (steps[destination] != EMPTY) return;

            Add(destination);
            steps[destination] = steps[start] + 1;
        }
        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split();
            int start = int.Parse(recvLine[0]);
            int end = int.Parse(recvLine[1]);
            Add(start); // start는 다시 접근하는 일이 없으므로 empty여도 상관없음

            while (rear < head)
            {
                int one = Out();

                TryAdd(one, one + 1);
                TryAdd(one, one * 2);                
            }

            Console.WriteLine(steps[end]);
        }
    }
}
