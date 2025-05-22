namespace NeetCode;

/// <summary>
/// как GroupAnagramsTask только с числами
/// </summary>
public class DigitPermutationTask
{
    public static IEnumerable<IEnumerable<int>> DigitPermutation(IEnumerable<int> arr)
    {
        var frequencyNums = new Dictionary<string, List<int>>();
        foreach (var num in arr)
        {
            var s = GetFrequencyNums(num);
            if (!frequencyNums.TryAdd(s, [num]))
            {
                frequencyNums[s].Add(num);
            }
        }

        return frequencyNums.Values.ToList();
    }

    private static string GetFrequencyNums(int num)
    {
        var result = new int[10];

        foreach (var digit in num.ToString())
        {
            result[int.Parse(digit.ToString())]++;
        }

        return string.Join(',', result);
    }
}