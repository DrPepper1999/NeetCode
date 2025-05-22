using System.Text;

namespace NeetCode;

/// <summary>
/// Найти длину самой длинной уникальной последовательности
/// </summary>
public class LengthLongStr
{
    public static int GetMaxLength(string str)
    {
        // a b c a b c b b
        
        var window = new HashSet<char>();

        var l = 0;
        var result = 0;
        for (var r = 0; r < str.Length; r++)
        {
            if (!window.Add(str[r]))
            {
                result = Math.Max(result, window.Count);
                while (str[l] != str[r])
                {
                    window.Remove(str[l]);
                    l++;
                }
                l++;
            }
            r++;
        }

        return result;
    }
}