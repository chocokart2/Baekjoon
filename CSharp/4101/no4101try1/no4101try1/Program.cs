using System;
namespace no4101try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] nums = Console.ReadLine().Split(' ');
                if (nums[0].Equals("0") && nums[1].Equals("0")) break;
                Console.WriteLine((int.Parse(nums[0]) > int.Parse(nums[1])) ? "Yes" : "No");
            }
        }
    }
}
