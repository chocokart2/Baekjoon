using System;

namespace no1427try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            int[] nums = new int[line.Length];
            for (int index = 0; index < nums.Length; ++index)
            {
                nums[index] = int.Parse(line[index].ToString());
            }
            // 삽입 정렬 최악이
            for (int keyIndex = 1; keyIndex < nums.Length; ++keyIndex) // key index의 왼편은 정렬된 곳입니다
            {
                for (int index = 0; index < keyIndex; ++index)
                {
                    if (nums[index] < nums[keyIndex])
                    {
                        int temp = nums[index];
                        nums[index] = nums[keyIndex];
                        nums[keyIndex] = temp;
                    }
                }
            }
            for (int index = 0; index < nums.Length; ++index)
            {
                Console.Write(nums[index]);
            }
        }
    }
}
