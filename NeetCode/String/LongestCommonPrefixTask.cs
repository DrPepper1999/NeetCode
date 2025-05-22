namespace NeetCode.String;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/887/
/// </summary>
public class LongestCommonPrefixTask
{
    // ["flower","flow","flight"]
    public string LongestCommonPrefix(string[] strs)
    {
        var minLength = strs.Min(str => str.Length);

        for (var i = 0; i < minLength; i++)
        {
            for (var j = 1; j < strs.Length; j++)
            {
                if (strs[j][i] != strs[j - 1][i])
                {
                    return strs[j].Substring(0, i);
                }
            }
        }

        return "";
    }
}