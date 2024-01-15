using System;

namespace no2839try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int fiveKiloBag = N / 5;
            int result = fiveKiloBag;
            switch (N % 5)
            {
                case 0: break;
                case 1:
                    if (fiveKiloBag < 1) result = -1;
                    else result += 1;
                    break;
                case 2:
                    if (fiveKiloBag < 2) result = -1;
                    else result += 2;
                    break;
                case 3: result += 1;
                    break;
                case 4:
                    if (fiveKiloBag < 1) result = -1;
                    else result += 2;
                    break;
                default: break;
            }
            Console.WriteLine(result);
        }
    }
}
