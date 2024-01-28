using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no7656try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 원하는 버퍼의 사이즈를 매개변수로 입력할 것
            int bufferSize = 2000;
            StreamReader reader = new StreamReader(Console.OpenStandardInput(bufferSize));

            // 입력을 받을때마다 호출합니다. 해당 함수의 리턴값은 String입니다.
            string recvLine = reader.ReadLine();


            // 코드가 종료되기 전에 미리 호출하여 리소스를 회수합니다.
            reader.Close();



            bool isFoundWhat = false;
            string what = "What is";
            int whatIndex = 0;
            StringBuilder result = new StringBuilder();
            StringBuilder line = new StringBuilder();

            for (int index = 0; index < recvLine.Length; index++)
            {
                if (whatIndex > 0)
                {
                    if (recvLine[index] == what[whatIndex])
                    {
                        whatIndex++;
                    }
                    else
                    {
                        whatIndex = 0;
                        // whaWhat도 판단할것. 이것은 아래 코드로 내려가서 체크할 것.
                    }
                    if (whatIndex == 7)
                    {
                        whatIndex = 0;
                        line.Append("Forty-two is");
                        isFoundWhat = true;
                        index++;
                    }
                }
                if (whatIndex == 0)
                {
                    // what의 w 판정
                    if (index == recvLine.Length) break;
                    if ((recvLine[index] == 'W' || recvLine[index] == 'w') && (isFoundWhat == false))
                    {
                        whatIndex++;
                        continue;
                    }


                    if (isFoundWhat)
                    {
                        if (recvLine[index] == '.')
                        {
                            line.Clear();
                            isFoundWhat = false;
                            continue;
                        }
                        if (recvLine[index] == '?')
                        {
                            result.AppendLine($"{line}.");
                            line.Clear();
                            isFoundWhat = false;
                        }
                        else
                        {
                            line.Append(recvLine[index]);
                        }
                    }
                }
            }
            Console.Write(result);

        }
    }
}
