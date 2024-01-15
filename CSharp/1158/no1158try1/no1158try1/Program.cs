using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1158try1
{
    internal class Program
    {
        class CircleQueuePtr
        {
            public int data;
            public CircleQueuePtr next;
            public CircleQueuePtr prev;
        }

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int size = int.Parse(nums[0]);
            int step = int.Parse(nums[1]);
            CircleQueuePtr[] circle = new CircleQueuePtr[size];
            for (int index = 0; index < size; ++index)
            {
                circle[index] = new CircleQueuePtr();
                circle[index].data = index + 1;
            }
            for (int index = 0; index < size; ++index)
            {
                if (index > 0)
                {
                    circle[index].prev = circle[index - 1];
                }
                else
                {
                    circle[index].prev = circle[size - 1];
                }
                if (index < size - 1)
                {
                    circle[index].next = circle[index + 1];
                }
                else
                {
                    circle[index].next = circle[0];
                }
            }


            CircleQueuePtr current = circle[size - 1];

            CircleQueuePtr M_GetNext()
            {
                CircleQueuePtr result = current;
                for (int i = 0; i < step; ++i)
                {
                    result = result.next;
                }
                return result;
            }
            

            StringBuilder printResult = new StringBuilder();
            printResult.Append("<");
            for (int i = 1; i < size; ++i)
            {
                current = M_GetNext();
                printResult.Append($"{current.data}, ");

                current.next.prev = current.prev;
                current.prev.next = current.next;
                // 제거하는 과정 추가.
            }
            current = M_GetNext();
            printResult.Append($"{current.data}>");
            Console.WriteLine(printResult);
        }
    }
}
