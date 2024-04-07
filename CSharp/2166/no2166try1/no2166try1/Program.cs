using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no2166try1
{
    internal class Program
    {
        struct Point
        {
            public double x;
            public double y;
        }

        static void Main(string[] args)
        {
            Point[] dots = new Point[int.Parse(Console.ReadLine()) + 1];

            for (int index = 0; index < dots.Length - 1; index++)
            {
                string[] nums = Console.ReadLine().Split(' ');

                dots[index] = new Point()
                {
                    x = double.Parse(nums[0]),
                    y = double.Parse(nums[1]),
                };
            }
            dots[dots.Length - 1] = dots[0];

            double sum = 0.0f;

            for (int index = 0; index < dots.Length - 1; ++index)
            {
                sum += (dots[index].x + dots[index + 1].x) * (dots[index].y - dots[index + 1].y);
            }

            sum = Math.Abs(sum) / 2;
            Console.WriteLine("{0:F1}", sum);
        }
    }
}
