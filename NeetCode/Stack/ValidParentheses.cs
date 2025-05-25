namespace NeetCode;

/// <summary>
/// Вам дают строку, состоящую из следующих символов: '(', ')', '{', '}', '' 'и'] '.
/// Входная строка s действительна тогда и только тогда, когда:
/// 1. Каждый открытый кронштейн закрыт одним и тем же типом близкого кронштейна.
/// 2. Открытые кронштейны закрыты в правильном порядке.
/// 3. Каждый закрытый кронштейн имеет соответствующий открытый кронштейн того же типа.
////
/// Вернуть True, если S является действительной строкой, и false в противном случае.
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