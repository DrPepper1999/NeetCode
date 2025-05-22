namespace NeetCode;

/// <summary>
/// Given an array of integers nums, return the length of the longest consecutive sequence of elements
/// that can be formed.
///
/// A consecutive sequence is a sequence of elements in which each element is exactly 1 greater than
/// the previous element. The elements do not have to be consecutive in the original array.
///
/// You must write an algorithm that runs in O(n) time.
///
/// Input: nums = [2,20,4,10,3,4,5]
/// Output: 4
///
/// Input: nums = [0,3,2,5,4,6,1,1]
/// Output: 7
/// </summary>
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
