namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/567/
/// </summary>
public class MoveZeroesTasks
{
    public void MoveZeroes(int[] nums) {
        var l = 0;
        for (var r = 0; r < nums.Length; r++) {
            if (nums[r] != 0) {
                (nums[l], nums[r]) = (nums[r], nums[l]);
                l++;
            }
        }
        

    }
}