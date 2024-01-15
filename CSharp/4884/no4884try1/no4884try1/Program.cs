using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no4884try1
{
    internal class Program
    {
        static long GetGroupGameCount(long n) => (n * (n - 1)) / 2;
        static long GetTournamentTeamCount(long rawTeamCount)
        {
            long result = 1;
            while (result < rawTeamCount) { result *= 2; }
            return result;
        }

        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();

            while (true)
            {
                string[] nums = Console.ReadLine().Split(' ');
                if (nums[0].Equals("-1"))
                {
                    break;
                }
                long groupCount = long.Parse(nums[0]);
                long teamCountPerGroup = long.Parse(nums[1]);
                long advancingTeamCount = long.Parse(nums[2]);
                long walkoverCount = long.Parse(nums[3]);
                long sum = groupCount * advancingTeamCount + walkoverCount;
                long teamCount = GetTournamentTeamCount(sum);

                result.Append($"{groupCount}*{advancingTeamCount}/{teamCountPerGroup}+{walkoverCount}=");
                result.Append($"{teamCount - 1 + groupCount * GetGroupGameCount(teamCountPerGroup)}+");
                result.AppendLine($"{teamCount - sum}");
            }
            Console.Write(result);
        }
    }
}
