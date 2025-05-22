using System.Collections;

namespace NeetCode;
/// <summary>
/// Дан массив строк strs, сгруппируйте все анаграммы в подсписки. Вы можете вернуть вывод в любом порядке.
///
/// Анаграмма — это строка, которая содержит те же символы , что и другая строка, но порядок символов может быть другим.
///
/// Input: strs = ["act","pots","tops","cat","stop","hat"]
/// Output: [["hat"],["act", "cat"],["stop", "pots", "tops"]]
/// </summary>
public class GroupAnagramsTask
{
    public List<List<string>> GroupAnagrams1(string[] strs) {
        var res = new Dictionary<string, List<string>>();
        foreach (var s in strs) {
            var count = new int[26];
            foreach (var c in s) {
                count[c - 'a']++;
            }
            var key = string.Join(",", count);
            if (!res.TryGetValue(key, out var value)) {
                value = [];
                res[key] = value;
            }

            value.Add(s);
        }
        return res.Values.ToList();       
    }
    
    public List<List<string>> GroupAnagrams(string[] strs)
    {
        var result = strs.Select(str => (str, frequencyCharacter: GetFrequencyCharacter(str)))
            .GroupBy(x => x.frequencyCharacter,
                (key, value) =>
                { return value.Select(x => x.str).ToList(); },
                new FrequencyCharacterComparer())
            .ToList();

        return result;
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

public class FrequencyCharacterComparer : IEqualityComparer<Dictionary<char, int>>
{
    public bool Equals(Dictionary<char, int>? x, Dictionary<char, int>? y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (x is null) return false;
        if (y is null) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Comparer.Equals(y.Comparer) && x.Count == y.Count && IsEquals(x, y);
    }

    public int GetHashCode(Dictionary<char, int> obj)
    {
        unchecked
        {
            var hashCodes = 0;
            foreach (var x in obj) hashCodes += HashCode.Combine(x.Key, x.Value);

            return
                HashCode.Combine(obj.Comparer, obj.Count,
                    hashCodes);
        }
    }

    private static bool IsEquals(Dictionary<char, int> x, Dictionary<char, int> y)
    {
        foreach (var item in x)
        {
            if (y.TryGetValue(item.Key, out var yValue))
            {
                if (yValue != item.Value)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        return true;
    }
}