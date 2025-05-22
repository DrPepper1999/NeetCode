using System.Security.Cryptography;

namespace NeetCode.SlidingWindow;

/// <summary>
/// Вам дана строка, s состоящая только из заглавных английских символов и целого числа k.
/// Вы можете выбрать до k символов строки и заменить их любыми другими заглавными английскими символами.
/// После выполнения максимального количества k замен вернуть длину самой длинной подстроки,
/// содержащей только один отличный символ.
///
/// Input: s = "XYYX", k = 2
/// Output: 4
///
/// Input: s = "AAABABB", k = 1
/// Output: 5
/// </summary>
public class LongestRepeatingCharacterReplacementTask
{
    public static int CharacterReplacement(string s, int k)
    {
        var frequencyCharacter = new Dictionary<char, int>();
        var result = 0;
        var left = 0;

        for (var right = 0; right < s.Length; right++)
        {
            if (!frequencyCharacter.TryAdd(s[right], 1))
            {
                frequencyCharacter[s[right]] += 1;
            }

            while (GetReplaceCount(left, right, frequencyCharacter) > k)
            {
                frequencyCharacter[s[left]]--;
                left++;
            }

            result = Math.Max(result, right - left + 1);
        }

        return result;
    }

    private static int GetReplaceCount(int left, int right, Dictionary<char, int> frequencyCharacter)
        => (right - left + 1) - frequencyCharacter.Max(kv => kv.Value);
    
}