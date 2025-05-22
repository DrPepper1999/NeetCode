namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/549/
/// </summary>
public class SingleNumberTask
{
    public int SingleNumber(int[] nums)
    {
        var result = 0;

        foreach (var n in nums)
        {
            result ^= n;
        }

        return result;
    }
}