using System;

namespace no2754try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string score = Console.ReadLine();
            float result = 0.0f;
            switch (score[0])
            {
                case 'A': result = 4.0f; break;
                case 'B': result = 3.0f; break;
                case 'C': result = 2.0f; break;
                case 'D': result = 1.0f; break;
                default: break;
            }
            if (score.Length == 2)
            {
                switch (score[1])
                {
                    case '+': result += 0.3f; break;
                    case '-': result -= 0.3f; break;
                    default: break;
                }
            }
            Console.WriteLine("{0:F1}", result);
        }
    }
}
