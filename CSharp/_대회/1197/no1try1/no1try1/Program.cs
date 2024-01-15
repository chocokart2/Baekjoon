using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no1try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string candy = Console.ReadLine();

            int max = 0;
            // 임의의 두곳을 선택하여, 해당 구간이 두종류 이하인지 판단합니다. 만약 두종류 이하인 구간이라면 max와 비교하여 최댓값을 저장합니다.

            for (int start = 0; start < count; start++)
            {
                bool[] hashSet = new bool[9];
                int setCount = 0;
                int size = 0;

                for (int index = start; index < count; ++index)
                {
                    //Console.WriteLine($"start = {start}, index = {index}");
                    int one = candy[index * 2] - '1';
                    if (hashSet[one] == false)
                    {
                        hashSet[one] = true;
                        setCount++;
                        if (setCount > 2)
                        {
                            break;
                        }
                    }
                    size++;
                }

                max = Math.Max(max, size);

            }

            Console.WriteLine(max);
        }
    }
}

// -선택한 2개의 과일의 이름
// -과일의 종류수
// -가장 꼬리의 과일 위치(새로운 종류의 과일이 생길때마다 업데이트)
// -머리의 과일의 종류, 위치()
// -현재의 사이즈
//
//
//과일이 들어올때마다 과일의 종류를 파악

// 같은 과일이 들어온 경우
// 사이즈 증가
// 
// 같은 과일인데 해시셋에 있는 과일임
// 사이즈 증가
// 머리의 과일의 종류, 위치 설정
//
// 다른 과일이 들어온 경우
// 과일의 종류수 판단
//
// ㄴ만약 종류가 1개 이하
// ㄴ선택한 과일의 이름 추가
// ㄴ과일 종류수 증가
// ㄴ머리 과일 종류 설정
// ㄴ과일 사이즈 증가
// +만약 종류가 0개라면 꼬리의 과일 위치 설정
//
// ㄴ만약 종류가 2개
// 

// 각 과일을 같은것끼리 묶기
// 가장 마지막 A1 과일이름과 위치, 가장 가까운 A1 과일과 위치
// 가장 마지막 A2 과일이름과 위치, 가장 가까운 A2 과일과 위치
// 다른 과일 만난경우 : 현재까지의 기록과 맥스기록중 가장 큰것을 저장
// A1 과일은 A2과일로 바뀌고, 새로 만난 과일은 A2에 넣기
//