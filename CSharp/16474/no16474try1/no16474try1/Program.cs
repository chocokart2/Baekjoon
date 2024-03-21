using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no16474try1
{
    internal class Program
    {
        class Vector2
        {
            public int x;
            public int y;
            public Vector2() { }
            public Vector2(int _x, int _y) { x = _x; y = _y; }
        }

        static void Main(string[] args)
        {
            // 숫자를 재배멸하는 과정이 필요하다.

            Console.ReadLine();
            string[] leftString = Console.ReadLine().Split(' ');
            string[] rightString = Console.ReadLine().Split(' ');
            
            

            // 전봇대의 입력된 숫자를 입력된 순서에 따라서 바꿔주는 map 객체입니다.
            Dictionary<int, int> convertNumOrder1 = new Dictionary<int, int>(leftString.Length);
            Dictionary<int, int> convertNumOrder2 = new Dictionary<int, int>(rightString.Length);

            int count = int.Parse(Console.ReadLine());

            Vector2[] originSequence = new Vector2[count];
            // x = 왼쪽, y = 오른쪽





        }
    }
}
