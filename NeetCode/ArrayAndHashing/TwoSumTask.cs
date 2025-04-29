namespace NeetCode;

public class TwoSumTask
{
    public int[] TwoSum(int[] nums, int target)
    {
        var sortedNums = nums
            .Select((num, i) => (num, index: i))
            .OrderBy(x => x.num)
            .ToArray();

        var i = 0;
        var j = nums.Length - 1;

        while (j >= 0 || i <= nums.Length-1)
        {
            var sum = sortedNums[i].num + sortedNums[j].num;
            
            if (sum == target)
            {
                return new int[2]
                {
                    Math.Min(sortedNums[i].index, sortedNums[j].index),
                    Math.Max(sortedNums[i].index, sortedNums[j].index)
                };
            }

            if (sum < target)
            {
                i++;
            }
            else
            {
                j--;
            }
        }
 
        return new int[0];
    }
}