namespace NeetCode.String;

/// <summary>
/// https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/885/
/// </summary>
public class StrStrTask
{
    // haystack = "hello", needle = "m"
    public int StrStr(string haystack, string needle) {
        if (needle == "") {
            return 0;
        }
        
        for (var i = 0; i < haystack.Length + 1 - needle.Length; i++) {
            for (var j = 0; j < needle.Length; j++) {
                if (needle[j] != haystack[j+i]) {
                    break;
                }

                if (j == needle.Length - 1)
                {
                    return i;
                }
            }
        }
        
        return -1;
    }
}