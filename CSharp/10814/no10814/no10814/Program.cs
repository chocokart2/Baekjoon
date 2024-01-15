using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no10814
{
    internal class Program
    {
        struct Member
        {
            public string name;
            public int age;

            public override string ToString()
            {
                return $"{age} {name}";
            }
        }

        static Member[] members;

        static int Compare(Member target, Member comparer)
        {
            if (target.age < comparer.age) return 1;
            else if (target.age > comparer.age) return -1;
            else return 0;
        }
        static Member[] MergeSort(Member[] target)
        {
            // 분할
            if (target.Length <= 1)
            {
                return target;
            }

            int middleIndex = target.Length / 2;
            Member[] result = new Member[target.Length];
            Member[] left = new Member[middleIndex];
            Member[] right = new Member[target.Length - middleIndex];
            for (int index = 0; index < middleIndex; ++index) left[index] = target[index];
            for (int index = 0; index < target.Length - middleIndex; ++index) right[index] = target[index + middleIndex];
            left = MergeSort(left);
            right = MergeSort(right);

            // 정복 및 합병
            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                switch (Compare(left[leftIndex], right[rightIndex]))
                {
                    case -1:
                        result[resultIndex] = right[rightIndex];
                        ++resultIndex;
                        ++rightIndex;
                        break;
                    case 1:
                    case 0:
                        result[resultIndex] = left[leftIndex];
                        ++resultIndex;
                        ++leftIndex;
                        break;
                    default:
                        break;
                }
            }
            while (leftIndex < left.Length)
            {
                result[resultIndex] = left[leftIndex];
                ++resultIndex;
                ++leftIndex;
            }
            while (rightIndex < right.Length)
            {
                result[resultIndex] = right[rightIndex];
                ++resultIndex;
                ++rightIndex;
            }
            return result;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            members = new Member[count];
            for (int index = 0; index < count; ++index)
            {
                string[] recvStrings = Console.ReadLine().Split(' ');
                members[index] = new Member()
                {
                    age = int.Parse(recvStrings[0]),
                    name = recvStrings[1]
                };
            }

            members = MergeSort(members);

            for (int index = 0; index < members.Length; ++index)
            {
                Console.WriteLine(members[index].ToString());
            }

        }
    }
}
