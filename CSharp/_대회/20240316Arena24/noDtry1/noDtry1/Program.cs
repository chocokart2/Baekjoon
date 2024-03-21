using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noDtry1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            List<int> forward = new List<int>(5000);
            List<int> prev = new List<int>(5000);
            
            int n = int.Parse(Console.ReadLine());
            int phase = 0; // 0 1 2 3까지만

            for (int x = n; x > 1; --x)
            {
                switch (phase)
                {
                    case 0:
                    case 3:
                        forward.Add(x);
                        break;
                    case 1:
                    case 2:
                        prev.Add(x);
                        break;
                    default: break;
                }
                phase++;
                if (phase == 4) phase = 0;
            }

            for (int index = 0; index < prev.Count; ++index)
            {
                result.Append($"{prev[index]} ");
            }
            result.Append("1");
            for (int index = forward.Count - 1; index > -1; --index)
            {
                result.Append($" {forward[index]}");
            }
            Console.WriteLine(result);
        }
    }
}
