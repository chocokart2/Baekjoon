using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace no31406try1
{
    internal class Program
    {
        class Folder
        {
            public int id;
            public Folder parent;
            public Folder[] child;
            public bool isOpened = false;
        }

        static int Clamp(int value, int max, int min)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        static void Main(string[] args)
        {
            StringBuilder answer = new StringBuilder();
            string[] nums = Console.ReadLine().Split(' ');
            Folder[] folders = new Folder[int.Parse(nums[0])];
            Folder current;
            for (int index = 0; index < folders.Length; ++index)
            {
                folders[index] = new Folder();
                folders[index].id = index + 1;
            }
            for (int index = 0; index < folders.Length; ++index)
            {
                string[] one = Console.ReadLine().Split(' ');
                folders[index].child = new Folder[one.Length - 1];
                for (int oneIndex = 1; oneIndex < one.Length; ++oneIndex)
                {
                    int next = int.Parse(one[oneIndex]) - 1;
                    folders[index].child[oneIndex - 1] = folders[next];
                    folders[next].parent = folders[index];
                }
            }
            current = folders[0];
            current.isOpened = true;
            current = current.child[0];

            for (int q = int.Parse(nums[1]); q > 0; q--)
            {
                string[] recvLine = Console.ReadLine().Split(' ');
                switch (recvLine[0])
                {
                    case "toggle":
                        current.isOpened = !current.isOpened;
                        //Console.WriteLine($"폴더 {current.id}가 {(current.isOpened ? "열렸" : "닫혔")}습니다.");
                        break;
                    case "move":
                        // 깊이 우선 탐색 진행
                        List<Folder> list = new List<Folder>();
                        Folder[] stack = new Folder[folders.Length];
                        int top = -1;
                        int currentIndex = -1; // 나중에 초기화됨
                        for (int subIndex = folders[0].child.Length - 1; subIndex >= 0; --subIndex)
                        {
                            stack[top + 1] = folders[0].child[subIndex];
                            top++;
                        }
                        for (int index = 0; top > -1; ++index)
                        {
                            Folder one = stack[top];
                            top--;
                            list.Add(one);
                            if (current.id == one.id)
                            {
                                currentIndex = index;
                            }

                            if (one.isOpened == false) continue;
                            for (int subIndex = one.child.Length - 1; subIndex >= 0; --subIndex)
                            {
                                stack[top + 1] = one.child[subIndex];
                                top++;
                            }
                        }
                        current = list[Clamp(currentIndex + int.Parse(recvLine[1]), list.Count - 1, 0)];
                        //Console.WriteLine($"폴더 {current.id}로 이동, 탐색 리스트 결과 : {list.Count}");
                        answer.AppendLine($"{current.id}");
                        break;
                    default:
                        break;
                }
            }
            Console.Write(answer);
        }
    }
}
