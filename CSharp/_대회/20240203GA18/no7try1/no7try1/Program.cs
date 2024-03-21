
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no7try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 그런거 쓰지 말고, 핸들의 첫글자를 
            List<string>[] handles = new List<string>[26]; // 인덱스에 들어갈 글자는, 핸들의 첫글자.
            // 핸들을 집어넣으면, 최대로 연결 할 수 있는 끝말잇기를 완성한다

            while (true)
            {
                string recvLine = Console.ReadLine();
                if (recvLine.Length < 1) return;

                // 브루트포스로 최대한 연결할 수 있는
            }




        }
    }
}
