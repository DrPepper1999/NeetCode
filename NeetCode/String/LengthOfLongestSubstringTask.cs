namespace NeetCode.SlidingWindow;

/// <summary>
/// Для заданной строки s найдите длину самой длинной подстроки без повторяющихся символов.
/// Подстрока — это непрерывная последовательность символов внутри строки.
///
/// Input: s = "zxyzxyz"
/// Output: 3
/// </summary>
public class LengthOfLongestSubstringTask
{
    public static int LengthOfLongestSubstring(string s)
    {
        var symbols = new HashSet<char>();
        var maxSubstring = 0;
        var left = 0;
        
        for (var right = 0; right < s.Length; right++)
        {
            if (symbols.Contains(s[right]))
            {
                while (symbols.Contains(s[right]))
                {
                    symbols.Remove(s[left]);
                    left++;
                }
            }
            
            symbols.Add(s[right]);
            maxSubstring = Math.Max(maxSubstring, right - left + 1);
        }

        return maxSubstring;
    }
}