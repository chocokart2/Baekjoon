using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace no2467try1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] numString = Console.ReadLine().Split(' ');
            int[] nums = new int[numString.Length];
            for (int index = 0; index < numString.Length; index++)
            {
                nums[index] = int.Parse(numString[index]);
            }
            int bottom = nums[0];
            int top = nums[1];
            int delta = Math.Abs(bottom + top);

            for (int bottomIndex = 0; bottomIndex < nums.Length - 1; bottomIndex++)
            {
                //Console.WriteLine($">> {bottomIndex}");
                // 이분 탐색 시작
                int topStart = bottomIndex + 1;
                int topEnd = nums.Length - 1;

                int middle;

                while (topStart <= topEnd)
                {
                    
                    middle = (topStart + topEnd) / 2;

                    int oneDelta = nums[bottomIndex] + nums[middle];
                    //Console.WriteLine($">>>> middle = {middle}, oneDelta = {oneDelta}");

                    if (delta > Math.Abs(oneDelta))
                    {
                        //Console.WriteLine($"! delta = {delta}, Math.Abs(oneDelta) = {Math.Abs(oneDelta)}, bottom = {nums[bottomIndex]}, top = {nums[middle]}");
                        bottom = nums[bottomIndex];
                        top = nums[middle];
                        delta = Math.Abs(bottom + top);
                    }

                    if (oneDelta == 0)
                    {
                        Console.WriteLine($"{nums[bottomIndex]} {nums[middle]}");
                        return;
                    }
                    else if (oneDelta > 0)
                    {
                        topEnd = middle - 1;
                    }
                    else
                    {
                        topStart = middle + 1;
                    }
                }
            }

            Console.WriteLine($"{bottom} {top}");
        }
    }
}
