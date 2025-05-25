// See https://aka.ms/new-console-template for more information

using System.Collections.Concurrent;

public class Response
{
}

public class Client : IClient
{
    public async Task<Response> GetAsync(long id)
    {
        await Task.Delay(1000);

        return new Response();
    }
}

public interface IClient
{
    Task<Response> GetAsync(long id);
}

public static class ClientExtensions
{
    public static Task<Response[]> GetArrayAsync2(this IClient client, long[] ids, int maxDegreeOfParallelism)
    {
        var tasks = ids
            .AsParallel()
            .WithDegreeOfParallelism(maxDegreeOfParallelism)
            .Select(client.GetAsync)
            .ToArray();

        return Task.WhenAll(tasks);
    }
    
    public static async Task<Response[]> GetArrayAsync1(this IClient client, long[] ids, int maxDegreeOfParallelism)
    {
        var bag = new ConcurrentBag<Response>();

        var options = new ParallelOptions()
        {
            MaxDegreeOfParallelism = maxDegreeOfParallelism
        };
        await Parallel.ForEachAsync(ids, options, async (id, ct) =>
        {
            var response = await client.GetAsync(id);
            bag.Add(response);
        });

        return bag.ToArray();
    }
    
    public static async Task<Response[]> GetArrayAsync3(this IClient client, long[] ids, int maxDegreeOfParallelism)
    {
        var sem = new SemaphoreSlim(maxDegreeOfParallelism, maxDegreeOfParallelism);
        var tasks = new Task<Response>[ids.Length];

        for (var i = 0; i < ids.Length; i++)
        {
            tasks[i] = ProccessTaskAsync(ids[i], client, sem);
        }

        return await Task.WhenAll(tasks);
    }

    private static async Task<Response> ProccessTaskAsync(long id, IClient client, SemaphoreSlim semaphore)
    {
        await semaphore.WaitAsync();

        try
        {
            Console.WriteLine($"Задача {id} начата в потоке {Environment.CurrentManagedThreadId}");
            var response = await client.GetAsync(id);
            Console.WriteLine($"Задача {id} завершена");

            return response;
        }
        finally
        {
            semaphore.Release();
        }
    }
}