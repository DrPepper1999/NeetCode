namespace NeetCode;

public class LongestConsecutiveSequence
{
    public int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        
        var hashNums = nums.ToHashSet();

        var starts = nums.Where(num => !hashNums.Contains(num - 1));

        var result = starts.Select(num =>
        {
            var result = 0;
            while (hashNums.Contains(num + result))
            {
                result++;
            }

            return result;
        })
        .Max();

        return result;
    }
}
