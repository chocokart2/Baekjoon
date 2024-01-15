using System;

namespace no25285try1
{
    internal class Program
    {
        static int GetGrade(string data)
        {
            string[] nums = data.Split(' ');

            float ki = float.Parse(nums[0]);
            float bmi = float.Parse(nums[1]) * 10000 / (ki * ki);

            if (ki < 140.1) return 6;
            if (ki < 146) return 5;
            if (ki >= 204 || ki < 159) return 4;
            if (bmi >= 35 || bmi < 16) return 4;
            if (ki < 161) return 3;
            // 여기 아래부터 : bmi = [16, 35), ki = [161, 204)
            if (bmi >= 30 || bmi < 18.5) return 3;
            if (bmi >= 25 || bmi < 20) return 2;
            return 1;
        }

        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; ++i)
                Console.WriteLine(GetGrade(Console.ReadLine()));
        }
    }
}
