using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace no1021try2
{
    internal class Program
    {
        class CircleQueue
        {
            public ElementPtr[] items;
            public ElementPtr currentCursor;

            public CircleQueue(int size)
            {
                items = new ElementPtr[size];
                for (int index = 0; index < size; ++index)
                {
                    items[index] = new ElementPtr();
                    items[index].value = index + 1;
                }
                if (size == 1)
                {
                    items[0].next = items[0];
                    items[0].prev = items[0];
                }
                else
                {
                    items[0].next = items[1];
                    items[0].prev = items[size - 1];
                    items[size - 1].next = items[0];
                    items[size - 1].prev = items[size - 2];
                    for (int index = 1; index < size - 1; ++index)
                    {
                        items[index].prev = items[index - 1];
                        items[index].next = items[index + 1];
                    }
                }
                currentCursor = items[0];
            }
            public void PopCurrent()
            {
                currentCursor.prev.next = currentCursor.next;
                currentCursor.next.prev = currentCursor.prev;
                currentCursor = currentCursor.next;
            }

            public int JumpAndGetMoveCount(int val)
            {
                int moveNext = 0;
                int movePrev = 0;
                ElementPtr currentPos = currentCursor;
                while (currentPos.value != val)
                {
                    currentPos = currentPos.next;
                    moveNext++;
                }
                currentPos = currentCursor;
                while (currentPos.value != val)
                {
                    currentPos = currentPos.prev;
                    movePrev++;
                }
                currentCursor = currentPos;
                return Math.Min(moveNext, movePrev);
            }
        }

        class ElementPtr
        {
            public int value;
            public ElementPtr next;
            public ElementPtr prev;

            public ElementPtr() { }
            static public bool operator==(ElementPtr left, ElementPtr right)
                => left.value == right.value;
            static public bool operator!=(ElementPtr left, ElementPtr right)
                => left.value != right.value;
        }

        static void Main(string[] args)
        {
            int result = 0;

            string[] numsNM = Console.ReadLine().Split(' ');
            int size = int.Parse(numsNM[0]);
            CircleQueue queue = new CircleQueue(size);
            string[] nums = Console.ReadLine().Split(' ');

            //queue.JumpAndGetMoveCount(int.Parse(nums[0]));
            //queue.PopCurrent();

            //for (int index = 1; index < nums.Length; ++index)
            for (int index = 0; index < nums.Length; ++index)
            {
                int one = queue.JumpAndGetMoveCount(int.Parse(nums[index]));
                //Console.WriteLine($">> DEBUG : one = {one}");
                result += one;
                queue.PopCurrent();
            }

            Console.WriteLine(result);
        }
    }
}
