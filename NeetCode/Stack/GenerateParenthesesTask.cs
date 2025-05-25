namespace NeetCode;

/// <summary>
/// Вам дается целое число n. Верните все хорошо сформированные струны скобок, которые вы можете генерировать с помощью n
/// Пары скобок.
///
/// Input: n = 1
/// Output: ["()"]
///
/// Input: n = 3
/// Output: ["((()))","(()())","(())()","()(())","()()()"]
/// </summary>
public class GenerateParenthesesTask
{
    public static List<string> GenerateParenthesis(int n) {
        List<string> res = new List<string>();
        Dfs("", res, n);
        return res;
    }
    
    private static bool Valid(string s) {
        int open = 0;
        foreach (char c in s) {
            open += (c == '(') ? 1 : -1;
            if (open < 0) return false;
        }
        return open == 0;
    }

    private static void Dfs(string s, List<string> res, int n) {
        if (s.Length == 2 * n) {
            if (Valid(s))
            {
                res.Add(s);
            }
            return;
        }
        Dfs(s + '(', res, n); // ((((()))))
        Dfs(s + ')', res, n);
    }
}