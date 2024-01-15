using System;

namespace no28290try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string recvLine = Console.ReadLine();

            if (recvLine.Equals("fdsajkl;") || recvLine.Equals("jkl;fdsa"))
            {
                Console.WriteLine("in-out");
                return;
            }
            if (recvLine.Equals("asdf;lkj") || recvLine.Equals(";lkjasdf"))
            {
                Console.WriteLine("out-in");
                return;
            }
            if (recvLine.Equals("asdfjkl;"))
            {
                Console.WriteLine("stairs");
                return;
            }
            if (recvLine.Equals(";lkjfdsa"))
            {
                Console.WriteLine("reverse");
                return;
            }
            Console.WriteLine("molu");
        }
    }
}
