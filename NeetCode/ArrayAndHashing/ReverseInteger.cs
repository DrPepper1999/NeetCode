namespace NeetCode;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/880/
/// </summary>
public class ReverseInteger
{
    public int Reverse(int x)
    {
        long result = 0;
        while (x != 0)
        {
            result *= 10;
            result += x % 10;
            x = x / 10;
        }
        return (result > Int32.MaxValue || result < Int32.MinValue) ? 0 : (int)result;
    }
}