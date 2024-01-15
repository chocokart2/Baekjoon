using System;

namespace no1931try1
{
    internal class Program
    {
        delegate int MeetingComparerer(Meeting left, Meeting right);

        struct Meeting
        {
            public int start;
            public int end;

            public Meeting(int _start, int _end)
            {
                this.start = _start;
                this.end = _end;
            }
        }
        static int CompareTime(Meeting left, Meeting right)
        {
            if (left.end != right.end) return left.end.CompareTo(right.end);
            return left.start.CompareTo(right.start);
        }

        static Meeting[] MergeSort(Meeting[] target)
        {
            if (target.Length < 2) return target;

            Meeting[] result = new Meeting[target.Length];
            int middleIndex = target.Length >> 1;
            Meeting[] left = new Meeting[middleIndex];
            Meeting[] right = new Meeting[target.Length - middleIndex];
            for (int index = 0; index < middleIndex; ++index) left[index] = target[index];
            for (int index = 0; index < target.Length - middleIndex; ++index) right[index] = target[index + middleIndex];
            left = MergeSort(left);
            right = MergeSort(right);

            int resultIndex = 0;
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (CompareTime(right[rightIndex], left[leftIndex]) < 0)
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
            int count = int.Parse(Console.ReadLine());
            Meeting[] plans = new Meeting[count];

            for (int index = 0; index < count; ++index)
            {
                string[] nums = Console.ReadLine().Split(' ');

                plans[index] = new Meeting(int.Parse(nums[0]), int.Parse(nums[1]));
            }
            plans = MergeSort(plans);

            Meeting lastMeeting = plans[0];
            int result = 1;
            
            for (int index = 1; index < plans.Length; ++index)
            {
                if (plans[index].start >= lastMeeting.end)
                {
                    lastMeeting = plans[index];
                    ++result;
                }

            }

            Console.WriteLine(result);
        }
    }
}
