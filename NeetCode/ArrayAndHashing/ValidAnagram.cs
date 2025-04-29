namespace NeetCode;

public class ValidAnagram
{
    public bool IsAnagram(string s, string t)
    {
        var sFrequencyCharacter = GetFrequencyCharacter(s);
        var tFrequencyCharacter = GetFrequencyCharacter(t);

        if (sFrequencyCharacter.Count != tFrequencyCharacter.Count)
        {
            return false;
        }

        return sFrequencyCharacter.All(x =>
        {
            if (tFrequencyCharacter.TryGetValue(x.Key, out var result))
            {
                return x.Value == result;
            }

            return false;
        });
    }

    private Dictionary<char, int> GetFrequencyCharacter(string str)
    {
        var result = new Dictionary<char, int>();

        foreach (var c in str)
        {
            if (!result.TryAdd(c, 1))
            {
                result[c] += 1;
            }
        }

        return result;
    }
}