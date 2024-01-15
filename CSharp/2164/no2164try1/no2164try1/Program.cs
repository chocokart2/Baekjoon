using System;
using System.Collections.Generic;
// 몸이 모자라서 머리를 고생시키는 중
// 그렇다고 머리가 튼튼한건 아닙니다.

namespace no2164try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] myQueue = new int[500000];
            int cursor = 0;
            int rear = count - 1; // 이번 배열의 마지막 원소의 위치 
            int nextRear = -1; // 다음 배열의 마지막 원소의 위치, 큐의 숫자를 뒤로 보낼때마다 1씩 증가합니다.
            bool isRemoveTurn = true;
            for (int index = 0; index < count; ++index)
            {
                myQueue[index] = index + 1;
            }

            //Console.Write("start:\t\t");
            //for (int index = 0; index < count; ++index)
            //    Console.Write($"{myQueue[index]}\t");
            //Console.WriteLine($"cursor:{cursor}, rear:{rear}, nextRear:{nextRear}, isRemoveTurn:{isRemoveTurn}");

            while (rear > 0) // 큐의 갯수가 1개일때까지
            {
                // 이 루프문을 한번 돌 때
                // 입력 : a/b/c/d/e/.../?'/?''/?'''/?'''' (?'는 ?의 계승자)
                // 결과 : b/d/f/.../?''/?''''
                while (cursor <= rear)
                {
                    if (isRemoveTurn)
                    {
                        // 카드 더미에 한장 뽑기
                        myQueue[cursor] = -1;
                        ++cursor;
                        isRemoveTurn = false;

                        //Console.Write("in loop:\t");
                        //for (int index = 0; index < count; ++index)
                        //    Console.Write($"{myQueue[index]}\t");
                        //Console.WriteLine($"cursor:{cursor}, rear:{rear}, nextRear:{nextRear}, 다음은 제거할 시간인가요?:{isRemoveTurn}");
                    }
                    else
                    {
                        

                        // 카드 더미에 한장을 뒤로 넣기
                        ++nextRear;
                        if (cursor != nextRear)
                        {
                            myQueue[nextRear] = myQueue[cursor];
                            if (cursor != nextRear) myQueue[cursor] = -1;
                        }
                        ++cursor;
                        isRemoveTurn = true;

                        //Console.Write("in loop:\t");
                        //for (int index = 0; index < count; ++index)
                        //    Console.Write($"{myQueue[index]}\t");
                        //Console.WriteLine($"cursor:{cursor}, rear:{rear}, nextRear:{nextRear}, 다음은 제거할 시간인가요?:{isRemoveTurn}");
                    }
                }

                //Console.Write("out loop:\t");
                //for (int index = 0; index < count; ++index)
                //    Console.Write($"{myQueue[index]}\t");
                //Console.WriteLine($"cursor:{cursor}, rear:{rear}, nextRear:{nextRear}, 다음은 제거할 시간인가요?:{isRemoveTurn}");
                cursor = 0;
                rear = nextRear;
                nextRear = -1;
            }

            Console.WriteLine(myQueue[0]);
        }
    }
}
