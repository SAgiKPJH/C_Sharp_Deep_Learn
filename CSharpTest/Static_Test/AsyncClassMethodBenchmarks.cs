using BenchmarkDotNet.Attributes;

namespace Static_Test;

public class AsyncClassMethodBenchmarks
{
    private const int N = 10;
    private const int Index = 10;
    private readonly PublicClassMethodASync _publicClassMethodASync = new();

    #region Async
    // 일반 Async 호출
    [Benchmark]
    public async Task<long> PublicClassMethodA_Factorial_Async() => await _publicClassMethodASync.FactorialAsync(N);

    [Benchmark]
    public async Task<long> PublicClassMethodA_FactorialIterativeMethod_Async() => await _publicClassMethodASync.FactorialIterativeMethodAsync(N);

    // static Async 호출
    [Benchmark]
    public async Task<long> StaticClassMethodA_Factorial_Async() => await StaticClassMethodASync.FactorialAsync(N);

    [Benchmark]
    public async Task<long> StaticClassMethodA_FactorialIterativeMethod_Async() => await StaticClassMethodASync.FactorialIterativeMethodAsync(N);

    // 일반 new Class Async 호출
    [Benchmark]
    public async Task<long> PublicClassMethodA_NEW_Factorial_Async()
    {
        var method = new PublicClassMethodASync();
        return await method.FactorialAsync(N);
    }

    [Benchmark]
    public async Task<long> PublicClassMethodA_NEW_FactorialIterativeMethod_Async()
    {
        var method = new PublicClassMethodASync();
        return await method.FactorialIterativeMethodAsync(N);
    }
    #endregion

    #region WhenAll
    // Static Async WhenAll
    [Benchmark]
    public async Task<long> RunStaticFactorialAsyncParallel()
    {
        var tasks = new Task<long>[Index];
        for (int i = 0; i < Index; i++)
        {
            tasks[i] = StaticClassMethodASync.FactorialAsync(N);
        }
        await Task.WhenAll(tasks);
        return long.MinValue;
    }

    // 일반 Async WhenAll
    [Benchmark]
    public async Task<long> RunPublicFactorialAsyncParallel()
    {
        var tasks = new Task<long>[Index];
        for (int i = 0; i < Index; i++)
        {
            tasks[i] = _publicClassMethodASync.FactorialAsync(N);
        }
        await Task.WhenAll(tasks);
        return long.MinValue;
    }

    // 일반 new Class Async WhenAll
    [Benchmark]
    public async Task<long> RunPublicFactorialAsyncParallel_NEW_CLASS()
    {
        var tasks = new Task<long>[Index];
        for (int i = 0; i < Index; i++)
        {
            var method = new PublicClassMethodASync();
            tasks[i] = method.FactorialAsync(N);
        }
        await Task.WhenAll(tasks);
        return long.MinValue;
    }
    #endregion

    #region Parallel.For
    // Static Async Parallel.ForAsync
    [Benchmark]
    public async Task<long> RunStaticFactorialAsyncParallel_ForAsync()
    {
        await Parallel.ForAsync(0, Index, async (i, cancellationToken) =>
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            await StaticClassMethodASync.FactorialAsync(N);
        });
        return long.MinValue;
    }

    // 일반 Async Parallel.ForAsync
    [Benchmark]
    public async Task<long> RunPublicFactorialAsyncParallel_ForAsync()
    {
        await Parallel.ForAsync(0, Index, async (i, cancellationToken) =>
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            await _publicClassMethodASync.FactorialAsync(N);
        });
        return long.MinValue;
    }

    // 일반 new Class Async Parallel.ForAsync
    [Benchmark]
    public async Task<long> RunPublicFactorialAsyncParallel_ForAsync_NEW_CLASS()
    {
        await Parallel.ForAsync(0, Index, async (i, cancellationToken) =>
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            var method = new PublicClassMethodASync();
            await method.FactorialAsync(N);
        });
        return long.MinValue;
    }
    #endregion
}