namespace NeetCode;

public class TwoIntegerSum2
{
    public int[] TwoSum(int[] numbers, int target)
    {
        var left = 0;
        var right = numbers.Length-1;

        while (left < right)
        {
            var sum = numbers[left] + numbers[right];
            if (sum == target)
            {
                return new int[] { left+1, right+1 };
            }

            if (sum < target)
            {
                left++;
            }

            if (sum > target)
            {
                right--;
            }
        }

        return new int[] {};
    }
}