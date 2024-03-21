using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noHtry1
{
    internal class Program
    {
        class Name
        {
            public int index;
            public string value;
            public List<Name> next;
        }
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Name[] nameArray = new Name[count];
            int startIndex = 0;
            for (int index = 0; index < count; index++)
            {
                nameArray[index] = new Name();
                nameArray[index].index = index;
                nameArray[index].value = Console.ReadLine();
                nameArray[index].next = new List<Name>();
            }
            for (int i = 1; i < count; i++)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int start = int.Parse(nums[0]) - 1;
                int end = int.Parse(nums[1]) - 1;

                //nameArray[start].next.Add(nameArray[end]);
                nameArray[start].next.Add(nameArray[end]);
                startIndex = start;
            }

            StringBuilder result = new StringBuilder();

            // 깊이 우선 탐색 진행
            Name current = nameArray[startIndex];
            Stack<Name> stack = new Stack<Name>();
            stack.Push(nameArray[startIndex]);
            bool[] hasVisited = new bool[count];
            hasVisited[startIndex] = true;
            while (stack.Count > 0)
            {
                Name one = stack.Pop();

                result.Append(one.value);

                for (int index = one.next.Count - 1; index> -1; --index)
                {
                    stack.Push(one.next[index]);
                }
            }

            Console.WriteLine(result);

        }
    }
}
