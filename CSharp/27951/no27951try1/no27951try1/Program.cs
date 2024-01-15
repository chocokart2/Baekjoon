using System;
using System.Text;

namespace no27951try1
{
    internal class Program
    {
        static void Main(string[] args) // O(2N) 알고리즘
        {
            StringBuilder result2 = new StringBuilder();
            Console.ReadLine();
            string[] hangers = Console.ReadLine().Split(' ');
            string[] clothes = Console.ReadLine().Split(' ');
            int upper = int.Parse(clothes[0]);
            int down = int.Parse(clothes[1]);
            
            bool isUnable = false;
            for (int index = 0; index < hangers.Length; ++index)
            {
                
                switch (hangers[index])
                {
                    case "1":
                        if (upper > 0)
                        {
                            --upper;
                            result2.Append("U");
                        }
                        else
                        {
                            result2.Clear();
                            isUnable = true;
                        }
                        break;
                    case "2":
                        if (down > 0)
                        {
                            --down;
                            result2.Append("D");
                        }
                        else
                        {
                            result2.Clear();
                            isUnable = true;
                        }
                        break;
                    case "3":
                        // 옷걸이의 갯수와 옷의 개수는 같다는것이 보장됨.
                        // 그러나 바로 옷을 걸어버리면 가능한 경우에도 불가능하게 됨
                        // 예를 들어 1 3 1임에도 두번째 옷걸이에 상의를 걸어버리면 하의를 못 걸게 됨.
                        // 따라서 옷을 거는 행위는 뒤로 미룸.
                        result2.Append("?");
                        break;
                    default: break;
                }
                if (isUnable) break;
            }

            if (isUnable)
            {
                Console.Write("NO");
            }
            else
            {
                // 나머지 ?를 상의와 하의로 채우기 시작합니다.
                // 상의 걸고 하의를 겁니다
                for (int index = 0; index < result2.Length; ++index)
                {
                    if (result2[index].Equals('?'))
                    {
                        result2.Remove(index, 1);

                        if (upper > 0)
                        {
                            result2.Insert(index, 'U');
                            --upper;
                        }
                        else
                        {
                            result2.Insert(index, 'D');
                        }
                    }
                }

                Console.WriteLine($"YES\n{result2}");
            }
        }
    }
}
