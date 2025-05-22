namespace NeetCode.Lock;

public class ParallelRedis
{
    private readonly Dictionary<string, string> _storage = new();
    private readonly ReaderWriterLockSlim _rwLock = new();
    
    public string? Get(string key)
    {
        _rwLock.EnterReadLock();
        try
        {
            _storage.TryGetValue(key, out var value);
            return value;
        }
        finally
        {
            _rwLock.ExitReadLock();
        }
    }

    public void Put(string key, string value)
    {
        _rwLock.EnterWriteLock();
        try
        {
            if (!_storage.TryAdd(key, value))
            {
                _storage[key] = value;
            }
        }
        finally
        {
            _rwLock.ExitWriteLock();
        }
    }
}