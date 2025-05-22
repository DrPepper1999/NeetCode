namespace NeetCode;

/// <summary>
/// Given an array of integers nums and an integer target, return the indices i and j such that nums[i] + nums[j] == target and i != j.
/// You may assume that every input has exactly one pair of indices i and j that satisfy the condition.
/// Return the answer with the smaller index first.
///
/// Input:
/// nums = [3,4,5,6], target = 7
///
/// Output: [0,1]
/// </summary>
public class ThreeSumSumTask
{
    public static List<List<int>> ThreeSum(int[] nums)
    {
        var sortNums = nums.Order().ToArray();

        var result = new List<List<int>>();
        
        for (var i = 0; i < sortNums.Length - 1; i++)
        {
            if (sortNums[i] > 0)
            {
                break;
            }

            if (i > 0 && sortNums[i] == sortNums[i - 1])
            {
                continue;
            }
            
            var left = i + 1;
            var right = nums.Length - 1;
            while (left < right)
            {
                var sum = sortNums[left] + sortNums[right] + sortNums[i];

                if (sum > 0)
                {
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    result.Add(new List<int>() {sortNums[i], sortNums[left], sortNums[right]});
                    left++;
                    right--;
                    while (left < right && sortNums[left] == sortNums[left -1])
                    {
                        left++;
                    }
                }
            }
        }

        return result;
    }
}