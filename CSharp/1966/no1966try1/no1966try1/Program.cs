using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace no1966try1
{
    internal class Program
    {
        //현재 Queue의 가장 앞에 있는 문서의 ‘중요도’를 확인한다.
        // > 1. Queue가 바뀔때마다 확인한다.
        // > 2. 혹은 DocumentPtr을 확인할때마다 확인한다.
        // 1번과 2번은 둘다 해당 사건이 일어날 갯수가 동일하다고 볼 수 있음
        // 최적화 불가능

        class DocumentPtr
        {
            public int index;
            public int primary;
            public DocumentPtr next;
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            for (int testCaseLeftCount = int.Parse(Console.ReadLine()); testCaseLeftCount > 0; testCaseLeftCount--)
            {
                string[] nums = Console.ReadLine().Split(' ');
                int size = int.Parse(nums[0]);
                int search = int.Parse(nums[1]);
                string[] primary = Console.ReadLine().Split(' ');

                DocumentPtr begin = new DocumentPtr();
                DocumentPtr end;
                DocumentPtr loopOne = begin;
                for (int index = 0; index < size; ++index)
                {
                    loopOne.index = index;
                    loopOne.primary = int.Parse(primary[index]);

                    if (index < size - 1)
                    {
                        loopOne.next = new DocumentPtr();
                        loopOne = loopOne.next;
                        //Console.WriteLine($"is LoopOne and Begin RefEqual : {ReferenceEquals(loopOne, begin)}");
                    }
                }
                end = loopOne;

                int oneResult = 1;
                for (int i = 0; i < size;)
                {
                    // 문서가 제거될때마다 루프가 하나씩 돈다.

                    // 해당 문서가 제거되어야 하는지 체크합니다.
                    // begin부터 시작하여 end까지 루프를 돕니다.
                    while (true) // 가장 중요도가 높은 문서가 begin이 될때까지 루프를 돕니다.
                    {
                        bool isThisFirst = true;
                        loopOne = begin;
                        for (int k = 0; k < size - 1; ++k)
                        {
                            loopOne = loopOne.next;
                            if (loopOne.primary > begin.primary)
                            {
                                isThisFirst = false;
                                break;
                            }
                        }

                        if (isThisFirst)
                        {
                            break;
                        }

                        end.next = begin;

                        end = end.next;

                        begin = begin.next;

                        end.next = null;
                    }

                    //Console.WriteLine($"Printed [index : {begin.index}, primary : {begin.primary}]");

                    if (search == begin.index)
                    {
                        break;
                    }
                    begin = begin.next;
                    oneResult++;
                    size--;
                }
                //Console.WriteLine($">> {oneResult.ToString()}");
                result.AppendLine($"{oneResult.ToString()}");
            }
            Console.Write(result);
        }
    }
}
