using System;
namespace no2869try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 1;
            string[] nums = Console.ReadLine().Split(' ');

            int speed = int.Parse(nums[0]);
            int road = int.Parse(nums[2]) - speed;
            speed -= int.Parse(nums[1]);

            // 나눗셈 (버람 연산을 해야 함)
            result += (road / speed) + 1;
            if (road % speed == 0) --result;
            Console.WriteLine(result);
        }
    }
}
