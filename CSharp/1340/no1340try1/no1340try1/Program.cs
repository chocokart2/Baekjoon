using System;
using System.Text;

namespace no1340try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 천만개의 숫자
            // 숏 : 2바이트
            // 2천만 바이트

            // 4만바이트
            // 기수 정렬
            StringBuilder result = new StringBuilder();
            int[] nums = new int[10_001];

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; ++i)
            {
                nums[int.Parse(Console.ReadLine())]++;
            }

            for (int index = 1; index < nums.Length; ++index)
            {
                while (nums[index] > 0)
                {
                    if (nums[index] > 15)
                    {
                        result.Append($"{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n{index}\n");
                        if (result.Length > 1000)
                        {
                            Console.Write(result);
                            result.Clear();
                        }
                        nums[index] -= 16;
                    }
                    else
                    {
                        result.Append($"{index}\n");
                        if (result.Length > 1000)
                        {
                            Console.Write(result);
                            result.Clear();
                        }
                        nums[index]--;
                    }
                }
            }

            if (result.Length > 0) Console.Write(result);
        }
    }
}
