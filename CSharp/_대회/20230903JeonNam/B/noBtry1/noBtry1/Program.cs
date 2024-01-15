using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noBtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            Console.ReadLine();
            string[] line = Console.ReadLine().Split(' ');
            string[] friends = Console.ReadLine().Split(' ');
            HashSet<int> friendsList = new HashSet<int>();
            foreach (string one in friends)
            {
                friendsList.Add(int.Parse(one));
            }

            for (int index = 0; index < friends.Length; ++index)
            {
                if (friendsList.Contains(int.Parse(line[index])) == false)
                    result++;
            }

            Console.WriteLine(result);
        }
    }
}
