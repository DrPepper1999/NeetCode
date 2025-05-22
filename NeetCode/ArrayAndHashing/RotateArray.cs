namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/646/
/// </summary>
public class RotateArray
{
    public void Rotate(int[] nums, int k) 
    {
        int n = nums.Length;
        k %= nums.Length;
        Reverse(nums, 0, n-1);
        Reverse(nums, 0, k-1);
        Reverse(nums, k, n-1);
    }
    
    private void Reverse(int[] nums, int l, int r)
    {
        while (l < r)
        {
            (nums[l], nums[r]) = (nums[r], nums[l]);
            l++;
            r--;
        }
    }
}