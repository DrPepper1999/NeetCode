namespace NeetCode;

/// <summary>
/// Оценить обратную польсную запись
/// </summary>
public class EvaluateReversePolishNotation
{
    private readonly Dictionary<char, Func<int, int, int>> _operations = new()
    {
        { '+', (a, b) =>  a + b},
        { '-', (a, b) =>  a - b},
        { '*', (a, b) =>  a * b},
        { '/', (a, b) =>  a / b},
    };

    public int EvalRPN(string[] tokens)
    {
        var stack = new Stack<int>();
        foreach (var token in tokens)
        {
            if (int.TryParse(token, out var num))
            {
                stack.Push(num);
                continue;
            }

            var firstToken = stack.Pop();
            var secondToken = stack.Pop();
            var result = _operations[char.Parse(token)](secondToken, firstToken);
            stack.Push(result);
        }

        return stack.Pop();
    }
}

