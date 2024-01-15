using System;

namespace no27294try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');
            int time = int.Parse(nums[0]);
            if ((time > 11) && (time < 17) && (nums[1][0] == '0')) Console.WriteLine(320);
            else Console.WriteLine(280);
        }
    }
}
