using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2121try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // O (N (log 2 N) ^ 2)

            // X값 => 해싱,
            // Y값 => 해싱
            // Map<X, HashSet<Y>>

            int result = 0;
            (int x, int y)[] dots = new (int x, int y)[int.Parse(Console.ReadLine())];
            Dictionary<int, HashSet<int>> hash = new Dictionary<int, HashSet<int>>();
            string[] sizeString = Console.ReadLine().Split(' ');
            int termX = int.Parse(sizeString[0]);
            int termY = int.Parse(sizeString[1]);
            
            bool isExist(int _x, int _y)
            {
                if (!hash.ContainsKey(_x)) return false;
                if (!hash[_x].Contains(_y)) return false;
                return true;
            }


            for (int index = 0; index < dots.Length; index++)
            {
                string[] recvLine = Console.ReadLine().Split(' ');

                int oneX = int.Parse(recvLine[0]);
                int oneY = int.Parse(recvLine[1]);

                dots[index] = (oneX, oneY);
                if (!hash.ContainsKey(oneX))
                {
                    hash.Add(oneX, new HashSet<int>());
                }
                hash[oneX].Add(oneY);
            }

            for (int index = 0; index < dots.Length; ++index)
            {
                (int x, int y) one = dots[index];

                // +x
                if (!isExist(one.x + termX, one.y)) continue;
                // +y
                if (!isExist(one.x, one.y + termY)) continue;
                // +x, +y
                if (!isExist(one.x + termX, one.y + termY)) continue;
                result++;
            }

            Console.WriteLine(result);



        }
    }
}
