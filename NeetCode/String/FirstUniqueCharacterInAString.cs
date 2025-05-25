namespace NeetCode.String;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/881/
/// Дана строка s, найти в ней первый неповторяющийся символ и вернуть его индекс. Если он не существует, вернуть -1.
/// </summary>
public class FirstUniqueCharacterInAString
{
    public int FirstUniqChar(string s) {
        var map = new Dictionary<char, int>();
        foreach (var c in s) {
            if (!map.TryAdd(c, 1)) {
                map[c]++;
            }
        }
        
        for(var i = 0; i < s.Length; i++) {
            if (map[s[i]] == 1) {
                return i;
            }
        }
        
        return -1;
    }
}