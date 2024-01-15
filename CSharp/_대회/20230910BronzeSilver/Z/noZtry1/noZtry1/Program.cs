using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noZtry1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string[] quote = new string[]
            {
                "Never gonna give you up",
                "Never gonna let you down",
                "Never gonna run around and desert you",
                "Never gonna make you cry",
                "Never gonna say goodbye",
                "Never gonna tell a lie and hurt you",
                "Never gonna stop"
            };

            int count = int.Parse(Console.ReadLine());
            bool result = true;

            for (int i = 0; i < count; ++i)
            {
                bool one = true;
                string recvLine = Console.ReadLine();
                for (int index = 0; index < 7; ++index)
                {
                    one &= !quote[index].Equals(recvLine);
                }
                if (one)
                {
                    result = false;
                    break;
                }
            }

            if (result) Console.WriteLine("No");
            else Console.WriteLine("Yes");
        }
    }
}
