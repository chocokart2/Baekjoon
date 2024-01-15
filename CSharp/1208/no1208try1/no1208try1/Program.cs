using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace no1208try1
{
    internal class Program
    {
        static bool isDebugging = false;
        static int middleNum = 2_000_000;

        // 해당 부위의 모든 가능한 경우의 수를 구합니다.
        // 리턴값은 숫자 배열입니다.
        // 인덱스의 값은 해당 값의 sum + 2_000_000 이고, 해당 인덱스가 가리킨 원소의 값은 해당 합을 만들 수 있는 경우의 수입니다.
        static long[] GetCase(int[] array, int start, int end)
        {
            long[] result = new long[4_000_001]; // index = 2_000_001 + 해당 부분순열의 원소의 합
            result[middleNum] = 1;
            bool[] isNeedAdd = new bool[array.Length];
            while (true)
            {
                int cursor = start;
                int sum = middleNum;

                // 세팅
                // 가장 왼쪽에서 커서 출발,
                // 현재 커서가 1이라면 커서를 오른쪽으로 이동,
                // 현재 커서가 0이라면 현재 커서를 1으로 하고, 현재 커서의 왼쪽에 있는 대상을 전부 0으로 한다. 

                while (cursor < end)
                {
                    //Console.WriteLine(cursor);
                    if (isNeedAdd[cursor]) ++cursor;
                    else break;
                }
                if (cursor >= end) break;
                isNeedAdd[cursor] = true;
                for (int index = start; index < cursor; ++index)
                {
                    isNeedAdd[index] = false;
                }

                if (isDebugging)
                {
                    StringBuilder str = new StringBuilder();
                    for (int index = 0; index < isNeedAdd.Length; ++index)
                    {
                        str.Append($"{(isNeedAdd[index] ? "1" : "0")} ");
                    }
                    Console.WriteLine(str);
                }


                // 값 계산
                for (int index = start; index < end; ++index)
                {
                    if (isNeedAdd[index]) sum += array[index];
                }
                result[sum]++;
            }

            if (isDebugging)
            {
                StringBuilder builder = new StringBuilder();
                for (int index = 0; index < result.Length; ++index)
                {
                    if (result[index] > 0)
                    {
                        builder.AppendLine($">> DEBUG : [{index - middleNum}] = {result[index]}");
                    }
                }
                Console.WriteLine(builder);
                Console.WriteLine("===");
            }

            return result;
        }

        static void Main(string[] args)
        {
            int bufferSize = 512;

            //StreamReader readStream = new StreamReader(new BufferedStream(Console.OpenStandardInput(bufferSize)));
            StreamReader readStream = new StreamReader(Console.OpenStandardInput(bufferSize));


            string[] recvLineNS = readStream.ReadLine().Split(' ');
            int numCount = int.Parse(recvLineNS[0]);
            int[] nums = new int[numCount];

            int target = int.Parse(recvLineNS[1]);

            //StringBuilder gatheredChars = new StringBuilder();

            //byte[] receiveBytes = new byte[bufferSize];
            //int readLength = readStream.Read(receiveBytes, 0, bufferSize);

            // == 여기까지는 패스! ==
            //throw new OverflowException();

            //char[] chars = new char[bufferSize];
            //readStream.Read(chars, 0, bufferSize);
            //for (int index = 0; index < bufferSize; ++index)
            //{
            //    gatheredChars.Append(chars[index]);
            //}


            // == 여기까지는 패스! ==
            //throw new OverflowException();

            //Console.WriteLine(gatheredChars.ToString());
            //string[] splited = gatheredChars.ToString().Split(' ');
            string[] splited = readStream.ReadLine().Split(' ');
            //Console.WriteLine(splited[0]);


            // == 여기까지는 패스! ==
            //throw new OverflowException();

            // 에러 수집기.
            //if (splited[0].Length == 0) throw new ArgumentException();
            // == 여기까지는 패스! ==

            // 에러 수집기. 첫번째 숫자는 사용 불가능한 숫자인가? => 예외 발생. 네 그렇다고 합니다.
            //try
            //{
            //    int.Parse(splited[0]);
            //}
            //catch (Exception e)
            //{
            //    throw new InvalidOperationException();
            //}


            for (int index = 0; index < numCount; ++index)
            {
                // 해당 코드에 문제가 터짐!
                nums[index] = int.Parse(splited[index]);
            }

            // !!! 여기에 도달하지 못함!
            //throw new OverflowException();


            //foreach (char one in chars) Console.Write($"{one} ");


            //if (false)
            //{
            //    for (int i = 0; i < numCount; ++i)
            //    {
            //        while (true)
            //        {
            //            int one = readStream.Read();

            //            // 여기서 해당 구간이 작동하지 않음
            //            // -> 그렇다면 readstream으로 문자를 read() 하였으나 첫 글자부터 -1을 리턴했다는 것임.
            //            if (one != -1) throw new OverflowException();
            //            if (one == ' ') throw new OverflowException("BBBBB");
            //            if (one == -1 || one == '\\') break;
            //            gatheredChars.Append((char)one);
            //        }

            //        // 여기서 이 구간이 작동되었습니다.
            //        if (gatheredChars.Length == 0) throw new PlatformNotSupportedException();
            //        nums[i] = int.Parse(gatheredChars.ToString());
            //        gatheredChars.Clear();
            //    }
            //}


            //while (false)
            //{
            //    int one = readStream.Read();
            //    if (one == ' ') throw new OverflowException("BBBBB");
            //    if (one == -1 || one == '\\') break;
            //    gatheredChars.Append((char)one);
            //}


            //// nums를 초기화하는 옛날 버전 구간입니다.
            //if (false)
            //{
            //    string streamReturnValue = gatheredChars.ToString();



            //    // 문제 해결됨
            //    // 체크 완료 : 해당 객체는 스트림이 끝에 도달하여 널 값을 리턴했습니다. 왜 스트링이 아닐까요?
            //    // 해당 객체가 넗 값인경우를 체크
            //    //if (streamReturnValue == null) throw new OverflowException("AAAAAA");
            //    // 입력 데이터 값은 한 줄에 반드시 입력의 끝이 들어있습니다. 따라서 한번에 한 문장을 읽는다면, 반드시 널 값을 리턴하게 됩니다.
            //    // -> Read 함수를 사용하여 한 글자씩 읽어둔 다음. 마지막 입력의 끝 값인 -1을 떼어둡니다. 즉 꼬리의 이전 부분을 남겨둡니다.

            //    string[] recvLine = streamReturnValue.Split(' ');
            //    // 여기서 Split 함수가 작동한 것 같지 않습니다.
            //    if (recvLine.Length == 1) throw new PlatformNotSupportedException("AAAAAA");

            //    for (int index = 0; index < recvLine.Length; ++index)
            //    {
            //        nums[index] = int.Parse(recvLine[index]);
            //    }
            //}



            long result = 0;
            int middle = nums.Length / 2;

            long[] leftCase = GetCase(nums, 0, middle);
            long[] rightCase = GetCase(nums, middle, nums.Length);
            if (isDebugging)
            {
                Console.WriteLine($">> zero : {leftCase[middleNum]}");
                Console.WriteLine($">> zero : {rightCase[middleNum]}");
            }

            // b = target + (2_000_001 * 2) - a

            for (int leftIndex = 0; leftIndex < leftCase.Length; ++leftIndex)
            {
                int rightIndex = target + middleNum * 2 - leftIndex;
                if (rightIndex < 0 || rightIndex >= rightCase.Length) continue;

                result += leftCase[leftIndex] * rightCase[rightIndex];
            }

            if (target == 0) result--;
            Console.WriteLine(result);
            readStream.Close();

            //Console.ReadLine();
        }
    }
}
