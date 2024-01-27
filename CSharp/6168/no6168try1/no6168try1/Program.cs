using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace no6168try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cowCount = int.Parse(Console.ReadLine());
            int[] sumsOne = new int[cowCount + 1];
            for (int index = 0; index < cowCount; index++)
            {
                bool isOne = Console.ReadLine()[0] == '1';
                sumsOne[index + 1] = sumsOne[index] + (isOne ? 1 : 0);
            }
            // 기준점을 잡고 해당 기준점의 뒷부분의 2의 갯수, 앞부분의 1의 갯수를 전부 체크한다.
            // 두개의 합이 가장 작은 상태를 체크한다.
            int result = int.MaxValue;
            for (int index = 0; index < sumsOne.Length - 1; ++index)
            {
                // 0부터 index까지 2의 갯수, index + 1부터 cowCount까지 1의 갯수
                int one = (index - sumsOne[index]) + (sumsOne[cowCount] - sumsOne[index + 1]);
                result = (one < result) ? one : result;
            }
            Console.WriteLine(result);
        }
    }
}
