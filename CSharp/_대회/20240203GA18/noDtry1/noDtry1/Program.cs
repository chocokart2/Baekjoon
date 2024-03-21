using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace noDtry1
{
    internal class Program
    {
        class Folder
        {
            public int position; // 엄마 폴더가 날 봤읊때 나의 위치
            public Folder[] subFolder;
            public bool isOpened;
            public Folder prev; // move를 통해 이동할 폴더
            public Folder next; // move를 통해 이동할 폴더

            public Folder fellowNext;
            // 현재 폴더가 닫힌 경우 다음 폴더. 무슨 일이 있어도 연결이 보장됨. 만약 동시 형제가 없다면, 상위 폴더의 형제가 있을때까지 상위로 올라간다.
            // 노력했는데 없으면 null로 한다.

            public Folder subLast; // 가장 마지막 서브폴더를 계속해서 반복해서 연다. 서브폴더가 없거나, 혹은 
            public Folder mother;
            // 상위 폴더

        }

        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            Folder[] folders = new Folder[int.Parse(nums[0])];




            for (int index = 0; index < folders.Length; index++)
            {
                folders[index] = new Folder();
                folders[index].isOpened = false;
            }

            for (int index = 0; index < folders.Length; ++index) // 하위 폴더 구성
            {
                string[] info = Console.ReadLine().Split(' ');
                folders[index].subFolder = new Folder[info.Length - 1];

                for (int infoIndex = 1; infoIndex < info.Length; ++infoIndex)
                {
                    folders[index].subFolder[infoIndex] = folders[int.Parse(info[infoIndex]) - 1];
                    folders[index].subFolder[infoIndex].mother = folders[index];
                    folders[index].subFolder[infoIndex].position = infoIndex - 1;
                }
            }
            // fellowNext 폴더 찾기
            folders[0].position = -1;

            for (int index = 1; index < folders.Length; ++index)
            {
                // 자신의 형제 폴더가 있는경우 그곳을 참조

                Folder one = folders[index];
                for (int subIndex = 1; subIndex < folders[index].subFolder.Length; subIndex++)
                {
                    folders[index].subFolder[subIndex - 1].fellowNext = folders[index].subFolder[subIndex];
                }
                // 상위 폴더와 연결해야 하는 경우 : folders[index].subFolder[folders[index].subFolder.Length - 1]
                Folder upper = one.mother;
                int tempIndex = one.position;
                // upper 폴더는 언젠가는 다음 형제를 가지고 있는 폴더여야 한다.
                // ==> 포지션이 막내가 아니여야 함. 막내라면 또 상위 폴더를 부름
                bool isUpperFound = true;
                while (upper.position == upper.mother.subFolder.Length - 1 && upper.position != -1)
                {
                    tempIndex = upper.position;
                    upper = upper.mother; // 상위 폴더로 올라감.
                    if (upper == null)
                    {
                        isUpperFound = false;
                        break;
                    }
                }
                if (isUpperFound)
                {
                    one.subFolder[one.subFolder.Length - 1].fellowNext = upper.subFolder[tempIndex + 1];
                }
            }


            Folder selectedFolder = folders[0].subFolder[0];

            void M_Toggle()
            {
                // 현재의 폴더에 영향을 준다
                if (selectedFolder.subFolder.Length == 0)
                {
                    selectedFolder.isOpened = !selectedFolder.isOpened;
                }


                if (selectedFolder.isOpened) // 닫기
                {
                    // 주변의 폴더에 영향을 준다.
                    // 이 폴더가 품고 있는 

                    selectedFolder.isOpened = false;

                    // 주변의 폴더에 영향을 준다.
                    selectedFolder.next = selectedFolder.fellowNext;
                    selectedFolder.fellowNext.prev = selectedFolder;
                }
                else
                {
                    // 주변의 폴더에 영향을 준다.
                    selectedFolder.isOpened = true;

                    // 주변의 폴더에 영향을 준다.
                    Folder sub = selectedFolder.subFolder[selectedFolder.subFolder.Length - 1];
                    while (sub.isOpened && sub.subFolder.Length > 0)
                    {
                        sub = sub.subFolder[selectedFolder.subFolder.Length - 1];
                    }

                    selectedFolder.next.prev = sub; // 여기서 서브 폴더가 품은 것중에 가장 마지막 폴더
                    selectedFolder.next = selectedFolder.subFolder[0];

                    // 선택한 폴더의 가장 마지막 폴더를 구한다.
                }
            }
            void M_Move(int num)
            {
                if (num > 0)
                {

                }
                else if (num < 0)
                {

                }
            }

            // 명령어 입력을 받는다.
            for (int q = int.Parse())

        }
    }
}
