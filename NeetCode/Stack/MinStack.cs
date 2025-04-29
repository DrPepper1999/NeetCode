using System.Collections;

namespace NeetCode;

public class MinStack
{
    private readonly Stack<int> _stack = new Stack<int>();
    private readonly Stack<int> _mins = new Stack<int>();
    
    public MinStack()
    {
    }
    
    public void Push(int val)
    {
        if (_mins.Count == 0)
        {
            _mins.Push(val);
        }
        else
        {
            if (val <= _mins.Peek())
            {
                _mins.Push(val);
            }
        }
        _stack.Push(val);
    }
    
    public void Pop()
    {
        var value = _stack.Pop();
        if (value == _mins.Peek())
        {
            _mins.Pop();
        }
    }
    
    public int Top()
    {
        return _stack.Peek();
    }
    
    public int GetMin()
    {
        return _mins.Peek();
    }
}