﻿using System.Collections;

namespace NeetCode;

/// <summary>
/// Реалезовать стек с возможностью получить минимального чилса в стеке
/// </summary>
public class MinStack
{
    private readonly Stack<int> _stack = new();
    private readonly Stack<int> _mins = new();

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