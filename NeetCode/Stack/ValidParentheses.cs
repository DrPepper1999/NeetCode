namespace NeetCode;

public class ValidParentheses
{
    private static readonly Dictionary<char, char> _closeToOpenBracket = new Dictionary<char, char>()
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