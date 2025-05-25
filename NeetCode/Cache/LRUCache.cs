namespace NeetCode.Lock;

public class LRUCache
{
    private readonly Dictionary<string, LinkedListNode<(string Key, string Value)>> _map = new();
    private readonly LinkedList<(string Key, string Value)> _linkedList = [];
    public int Capacity { get; }

    public LRUCache(int capacity)
    {
        Capacity = capacity;
    }
    
    public string? Get(string key)
    {
        if (!_map.TryGetValue(key, out var node))
        {
            return null;
        }

        _linkedList.Remove(node);
        _linkedList.AddFirst(node);
        return node.Value.Value;
    }

    public void Put(string key, string value)
    {
        if (_map.Remove(key, out var node))
        {
            _linkedList.Remove(node);
            _linkedList.AddFirst(node);
        }
        
        if (_linkedList.Count == Capacity)
        {
            var lastNode = _linkedList.Last;
            _linkedList.RemoveLast();
            _map.Remove(lastNode.Value.Key);
        }

        var newNode = new LinkedListNode<(string Key, string Value)>((key, value));
        _map.TryAdd(key, newNode);
        _linkedList.AddFirst(newNode);
    }
}