namespace NeetCode;

public class ShortestUnsortedSubArray
{
    public static (int, int)? GetShortestUnsortedSubArray(int[] array)
    {
        var left = 0;
        var right = 0;
        var max = array[0];
        for (var i = 1; i < array.Length; i++)
        {
            if (array[i] < max)
            {
                right = i;
                continue;
            }

            max = array[i];
            if (left == 0)
            {
                left = i;
            }
        }

        return left < right ? (left, right) : null;
    }
}