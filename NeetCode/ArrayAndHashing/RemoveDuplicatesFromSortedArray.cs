namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/727/
/// </summary>
public class RemoveDuplicatesFromSortedArray
{
    public int RemoveDuplicates(int[] nums)
    {
        var left = nums.Length > 0 ? 1 : 0;
        foreach (var n in nums)
        {
            if (n > nums[left - 1])
            {
                nums[left++] = n;
            }
        }

        return left;
    }
}