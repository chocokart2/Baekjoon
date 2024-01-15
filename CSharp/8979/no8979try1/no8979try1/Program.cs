using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace no8979try1
{
    internal class Program
    {
        class Country
        {
            int gold;
            int silver;
            int bronze;
            public bool isTargeted { get; private set; }

            public Country(int g, int s, int b, bool _isTargeted)
            {
                gold = g;
                silver = s;
                bronze = b;
                this.isTargeted = _isTargeted;
            }

            public bool IsBiggerThen(Country target)
            {
                if (gold != target.gold) return gold > target.gold;
                if (silver != target.silver) return silver > target.silver;
                return bronze > target.bronze;
            }
        }

        static Country[] MergeSort(Country[] target)
        {
            if (target.Length < 2) return target;

            Country[] result = new Country[target.Length];
            int middleIndex = target.Length >> 1;
            Country[] left = new Country[middleIndex];
            Country[] right = new Country[target.Length - middleIndex];
            for (int index = 0; index < middleIndex; ++index) left[index] = target[index];
            for (int index = 0; index < target.Length - middleIndex; ++index) right[index] = target[index + middleIndex];
            left = MergeSort(left);
            right = MergeSort(right);
            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (right[rightIndex].IsBiggerThen(left[leftIndex]))
                {
                    result[resultIndex] = right[rightIndex];
                    ++resultIndex;
                    ++rightIndex;
                }
                else
                {
                    result[resultIndex] = left[leftIndex];
                    ++resultIndex;
                    ++leftIndex;
                }
            }
            while (leftIndex < left.Length)
            {
                result[resultIndex] = left[leftIndex];
                ++resultIndex;
                ++leftIndex;
            }
            while (rightIndex < right.Length)
            {
                result[resultIndex] = right[rightIndex];
                ++resultIndex;
                ++rightIndex;
            }
            return result;
        }


        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ');

            int count = int.Parse(nums[0]);
            int targetID = int.Parse(nums[1]);
            Country[] countries = new Country[count];

            for (int index = 0; index < count; ++index)
            {
                string[] medals = Console.ReadLine().Split(' ');

                countries[index] = new Country(int.Parse(medals[1]), int.Parse(medals[2]), int.Parse(medals[3]), int.Parse(medals[0]) == targetID);
            }

            countries = MergeSort(countries);

            

            int targetIndex = -1;
            for (int index = 0; index < countries.Length; ++index)
            {
                //Console.WriteLine($"DEBUG: {index}");
                if (countries[index].isTargeted)
                {
                    targetIndex = index;
                    break;
                }
            }
            //Console.WriteLine($"DEBUG : targetIndex = {targetIndex}");    

            int result = targetIndex;
            for (int index = targetIndex; index >= 0; --index)
            {
                //Console.WriteLine($"DEBUG : 2nd Loop : index = {index}");

                if (countries[index].IsBiggerThen(countries[targetIndex]))
                {
                    //Console.WriteLine($"I found Bigger! : {index}");
                    result = index;
                    break;
                }
            }
            result += 2;
            Console.WriteLine(result);
        }
    }
}
