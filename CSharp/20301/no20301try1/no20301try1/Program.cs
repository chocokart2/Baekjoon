using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no20301try1
{
    internal class Program
    {
        class ValuePtr
        {
            public int value;
            public ValuePtr next;
            public ValuePtr prev;
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            string[] recvLine = Console.ReadLine().Split(' ');
            int size = int.Parse(recvLine[0]);
            int step = int.Parse(recvLine[1]);
            int reverseLimit = int.Parse(recvLine[2]);
                        ValuePtr[] circle = new ValuePtr[size];
            ValuePtr current;

            for (int index = 0; index < size; index++)
            {
                circle[index] = new ValuePtr();
                circle[index].value = index + 1;
            }
            for (int index = 0; index < size; index++)
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
            current = circle[step - 1];
            
            for (int removedPeople = 0; removedPeople < size;) //  / limit % 2 == 0이면 정방향 제거, 그렇지 않으면 역방향 제거
            {
                // 뽑기
                result.Append($"{current.value}\n");
                ++removedPeople;

                // 해당 위치 제거
                current.prev.next = current.next;
                current.next.prev = current.prev;

                // 이동
                if (removedPeople / reverseLimit % 2 == 0)
                {
                    for (int i = 0; i < step; ++i)
                    {
                        current = current.next;
                    }
                }
                else
                {
                    for (int i = 0; i < step; ++i)
                    {
                        current = current.prev;
                    }
                }
            }

            Console.WriteLine(result);

        }
    }
}
