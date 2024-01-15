using System;
using System.Runtime.Remoting.Lifetime;

namespace testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = a = 4;


            int[] origin = new int[3] { 1, 2, 3 };
            Console.WriteLine("=== 복사 전 origin 값 ===");
            foreach (int i in origin)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=== copied로 복사 및 copied 값 변경 ===");
            int[] copied = origin;
            copied[0] = 4;
            copied[1] = 5;
            copied[2] = 6;
            Console.WriteLine("=== 복사 후 origin 값 ===");
            foreach (int i in origin)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=== 복사 후 copied 값 ===");
            foreach (int i in copied)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine($"copied와 origin은 같은 곳을 참조하는가? : ReferenceEquals(origin, copied) = {ReferenceEquals(origin, copied)}");

            int value = int.Parse(Console.ReadLine());

            if (value >= 620) Console.WriteLine("Red");
            else if (value >= 590) Console.WriteLine("Orange");
            else if (value >= 570) Console.WriteLine("Yellow");
            else if (value >= 495) Console.WriteLine("Green");
            else if (value >= 450) Console.WriteLine("Blue");
            else if (value >= 425) Console.WriteLine("Indigo");
            else Console.WriteLine("Violet");


            Console.WriteLine();


        }
    }
}
