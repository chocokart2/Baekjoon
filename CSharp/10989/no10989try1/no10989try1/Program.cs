using System;
using System.IO;
using System.Text;
// 기수 정렬을 이용합니다.
// 빠른 입력과 빠른 출력을 이용합니다.
// 메모리 관리를 위해 버퍼 제한을 두었습니다. 백만 아래면 괜찮겠죠?
// 천만개의 숫자를 고르게 나눠줘도 원소당 1000개의 숫자네요.
namespace no10989try1
{
    internal class Program
    {
        static int[] numbers = new int[10001];
        static StreamReader reader = new StreamReader(Console.OpenStandardInput());
        static StringBuilder result = new StringBuilder();
        static StringBuilder temp = new StringBuilder();
        static int resultSize = 0;
        static int tempSize = 0;
        const int MAX_BUFFER_LEGTH = 262_144;

        static void Flush()
        {
            result.Append(temp);
            Console.Write(result);
            result.Clear();
            temp.Clear();
        }
        static void ReadyTemp()
        {

        }
        static void ExpandTemporary() // number[index]이 tempsize * 2보다 크고, tempSize
        {
            tempSize <<= 1;
            temp.Append(temp);
        }

        static void Main(string[] args)
        {
            int count = int.Parse(reader.ReadLine());
            for(int i = 0; i < count; ++i)
            {
                ++numbers[int.Parse(reader.ReadLine())];
            }
            for (int index = 1; index < numbers.Length;) // 1부터 10000까지 숫자를 돕니다.
            {
                if (numbers[index].Equals(0))
                {
                    ++index; continue;
                }

                // 해야 할 일 : numbers[index].Equals(0)일때 다음 숫자로 패스해야 하는데 언제가 적절한가
                // ㄴtemp의 사이즈가 0일 때.
                // ㄴnumbers[index].Equals(0)이고 temp 아니라면 temp를 늘리는 방향으로 가야 합니다.
                // result + temp할 시기인지 판단하기
                // 넣어도 됩니다! => 다음으로 이동
                // ㄴtemp를 확장해도 될 시기인지 판단하기
                // ㄴ확장해도 됩니다! => 확장하고 다시 판단
                // ㄴ지금은 괜찮은데(상위 조건에 의해) 확장하면 터질 것 같아요! => 얌전히 넣기
                // ㄴtempSize * 2가 배열의 숫자보다 더 커져요 => 얌전히 넣기
                // 넣으면 가득차요! => 방출




                // 간단히 말해, result에 숫자 정보를 집어넣습니다.
                // 1부터 10000까지 인덱스를 돕니다.
                // number[index] > 0이면 활성화합니다. 아니면 패스!
                // result에 temp의 숫자를 넣을 때
                // ㄴ (>)resultSize + tempSize =< MAX_BUFFER_LEGTH일 때 숫자를 넣습니다.
                // ㄴ resultSize + tempSize > MAX_BUFFER_LEGTH 일 때, result의 숫자를 전부 출력합니다.
                // ㄴㄴ 이때 tempSize의 숫자가 MAX_BUFFER_LEGTH을 넘을 때는 해결책이 없습니다
                // ㄴㄴㄴ 따라서 tempSize * 2 > MAX_BUFFER_LEGTH일 때 확장을 금지하고 resultSize에 추가하기를 시도합니다.
                // ㄴㄴㄴㄴ 이때 tempSize * 2 + resultSize > MAX_BUFFER_LEGTH일 때, 숫자를 넣을 수 없습니다
                // ㄴㄴㄴㄴ (>)(따라서 resultSize + tempSize * 2 > MAX_BUFFER_LEGTH일 때, 확장을 금지하고 resultSize에 추가하기를 시도합니다.
                // numbers[현재번호] > 0 일때는 temp를 추가한다.
                // (>) 처음 temp는 append(현재번호)로 설정하며, tempSize = 1로 합니다.
                // ㄴ 이때는 tempSize == 0이여야 한다
                // temp에 숫자를 확장시킬때는
                // ㄴ temp.Append(temp)하여 두배로 확장하며, tempSize도 <<= 1하여 두배로 늘립니다.
                // ㄴ tempSize * 2 > numbers[현재번호]일때는 중지합니다.
                // 숫자를 넣을 때, 처음에는 temp에 해당 인덱스의 숫자를 넣습니다.
                // 


                // Cursor + TempSize * 2 > max || 루프 종료 이면 짜르기
                // -> result + temp 하고,
                // 그렇지 않으면
                // TempSize를 키운다.
                // 만약 


                --numbers[index];
                --index;


            }
        }
    }
}
