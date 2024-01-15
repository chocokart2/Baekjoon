using System;

namespace no17362try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;
            switch(int.Parse(Console.ReadLine()) % 8)
            {
                case 1: result = 1; break;
                case 2: result = 2; break;
                case 3: result = 3; break;
                case 4: result = 4; break;
                case 5: result = 5; break;
                case 6: result = 4; break;
                case 7: result = 3; break;
                case 0: result = 2; break;
                default: break;
            }
            Console.WriteLine(result);
        }
    }
}
