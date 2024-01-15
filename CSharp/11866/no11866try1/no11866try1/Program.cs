using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no11866try1
{
    internal class Program
    {
        class Queue
        {
            int[] numbers;
            int size = 0;

            public Queue(int number)
            {
                numbers = new int[number];
                size = number;
                for (int index = 0; index < number; ++index)
                    numbers[index] = index + 1;
            }

            public int Pop(int targetPosition) // postion은 인덱스 숫자 + 1한 값입니다.
            {
                int result;

                while (targetPosition > size) targetPosition -= size;
                result = numbers[targetPosition - 1];

                // targetPosition보다 앞에 있는 원소는 뒤로 보내버립니다.
                int[] temp = new int[targetPosition - 1];
                for (int index = 0; index < targetPosition - 1; ++index)
                {
                    temp[index] = numbers[index];
                }
                for (int index = targetPosition; index < size; ++index)
                {
                    numbers[index - targetPosition] = numbers[index];
                }
                for (int index = 0; index < temp.Length; ++index)
                {
                    numbers[index + size - targetPosition] = temp[index];
                }
                --size;
                numbers[size] = -1;

                return result;
            }
        }

        static void Main(string[] args)
        {
            string[] recvLine = Console.ReadLine().Split(' ');
            int count = int.Parse(recvLine[0]);
            int target = int.Parse(recvLine[1]);
            int[] resultArray = new int[count];
            Queue queue = new Queue(count);
            StringBuilder result = new StringBuilder();
            for (int index = 0; index < count; ++index)
                resultArray[index] = queue.Pop(target);
            result.Append("<");
            for(int index = 0; index < resultArray.Length; ++index)
            {
                if (index == resultArray.Length - 1)
                {
                    result.Append($"{resultArray[index]}");
                }
                else
                {
                    result.Append($"{resultArray[index]}, ");
                }
            }
            result.Append(">");
            Console.Write(result);
        }
    }
}
