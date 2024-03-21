using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no30087try1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder result = new StringBuilder();
            //for (int i = int.Parse(Console.ReadLine()); i > 0; --i)
            //{
            //    switch (Console.ReadLine())
            //    {
            //        case "Algorithm": result.AppendLine("204"); break;
            //        case "DataAnalysis": result.AppendLine("207"); break;
            //        case "ArtificialIntelligence": result.AppendLine("302"); break;
            //        case "CyberSecurity": result.AppendLine("B101"); break;
            //        case "Network": result.AppendLine("303"); break;
            //        case "Startup": result.AppendLine("501"); break;
            //        case "TestStrategy": result.AppendLine("105"); break;
            //        default: break;
            //    }
            //}
            //Console.Write(result);


            string[] a = Console.ReadLine().Split(' ');
            int x = int.Parse(a[0]);
            int y = int.Parse(a[1]);
            Console.WriteLine((x % y == 0) ? "Yes" : "No");
        }
    }
}
