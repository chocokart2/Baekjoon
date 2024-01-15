using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noDtry1
{
    internal class Program
    {

        int ConvertToInt(string strFormat)
        {
            string[] recvLine = strFormat.Split(':');
            return int.Parse(recvLine[0]) * 60 + int.Parse(recvLine[1]);
        }

        class Vtuber
        {
            public string name;
            public bool isReal = true;
            public int time = 0;
        }

        static void Main(string[] args)
        {
            int weekCount = 0;
            int dataCount = 0;
            Dictionary<string, int> GetIndex = new Dictionary<string, int>();





        }
    }
}
