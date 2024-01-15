using System;

namespace no1978try1
{
    internal class Program
    {
        static bool IsPrimeNumber(int num)
        {
            if (num == 1) return false;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int result = 0;

            Console.ReadLine();
            string[] recvLine = Console.ReadLine().Split(' ');
            
            for (int index = 0; index < recvLine.Length; ++index)
            {
                if (IsPrimeNumber(int.Parse(recvLine[index]))) ++result;
            }

            Console.WriteLine(result);
        }
    }
}
