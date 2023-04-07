using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1181try1
{
    internal class Program
    {
        const int LEFT_IS_FIRST = -1;
        // 왼쪽 녀석이 오른쪽보다 먼저인지 체크합니다.
        // 1. 길이를 먼저 체크한다. 작은게 우선입니다.
        // 2. 길이가 같으면 사전 순으로.
        static bool CompareLeftIsFirst(string left, string right)
        {
            if(left.Length != right.Length) return left.Length < right.Length;
            return left.CompareTo(right) == LEFT_IS_FIRST;
        }
        static List<string> Merge(List<string> left, List<string> right)
        {
            int leftCursor = 0, rightCursor = 0;
            List<string> result = new List<string>();
            while ((leftCursor < left.Count) || (rightCursor < right.Count))
            {
                
                if (leftCursor == left.Count) // left 원소 접근 불가
                {
                    result.Add(right[rightCursor]);
                    ++rightCursor;
                }
                else if (rightCursor == right.Count) // right 원소 접근 불가
                {
                    result.Add(left[leftCursor]);
                    ++leftCursor;
                }
                else if (CompareLeftIsFirst(left[leftCursor], right[rightCursor])) // 인덱스 배열 밖을 벗어나지 않기 위해 아래에 배치.
                {
                    result.Add(left[leftCursor]);
                    ++leftCursor;
                }
                else
                {
                    result.Add(right[rightCursor]);
                    ++rightCursor;
                }
            }
            return result;
        }
        static List<string> MergeSort(List<string> target)
        {
            //1번 영역 --> 최소 수준이면 정렬을 시작합니다.
            if (target.Count == 1)
            {
                return target;
            }
            else if(target.Count == 2)
            {
                if (CompareLeftIsFirst(target[0], target[1])) return target;
                else return new List<string>() { target[1], target[0] };
            }
            //1번 영역 <-- 여기까지
            else
            {
                // 최대한 리스트를 쪼개고, 병합합니다.
                int middleIndex = target.Count / 2; //2로 나눌때 나머지는 버립니다.
                return Merge(MergeSort(target.GetRange(0, middleIndex)), MergeSort(target.GetRange(middleIndex, target.Count - middleIndex)));
            }
        }

        static void Main(string[] args)
        {
            // 메시지를 받음
            int count = int.Parse(Console.ReadLine());
            List<string> receivedStrings = new List<string>();
            HashSet<string> exists = new HashSet<string>();
            for(int i = 0; i < count; i++)
            {
                string receivedOne = Console.ReadLine();
                if (exists.Contains(receivedOne) == false) // 중복되는 것 제거
                {
                    receivedStrings.Add(receivedOne);
                    exists.Add(receivedOne);
                }
            }

            // 머지 소트 진행
            receivedStrings = MergeSort(receivedStrings);
            foreach(string one in receivedStrings)
            {
                Console.WriteLine(one);
            }
        }
    }
}
