namespace NeetCode;

/// <summary>
/// You are given a string s consisting of the following characters: '(', ')', '{', '}', '[' and ']'.
/// The input string s is valid if and only if:
/// 1. Every open bracket is closed by the same type of close bracket.
/// 2. Open brackets are closed in the correct order.
/// 3. Every close bracket has a corresponding open bracket of the same type.
///
/// Return true if s is a valid string, and false otherwise.
/// </summary>
public class ValidParentheses
{
    private static readonly Dictionary<char, char> _closeToOpenBracket = new()
    {
        { ')', '(' },
        { '}', '{' },
        { ']', '[' },
    };
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();
        foreach (var bracket in s)
        {
            if (!_closeToOpenBracket.TryGetValue(bracket, out var closeBracket))
            {
                stack.Push(bracket);
            }
            else
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                var currentBracket = stack.Pop();
                if (currentBracket != closeBracket)
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}