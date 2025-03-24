using BenchmarkDotNet.Attributes;

namespace Static_Test;

public class AsyncClassMethodPowBenchmarks
{
    private const int N = 10;
    private const int Index = 10;
    private readonly PublicClassMethodASyncPow _PublicClassMethodASyncPow = new();

    #region Async
    // 일반 Async 호출
    [Benchmark]
    public async Task<double> PublicClassMethodA_Factorial_Async() => await _PublicClassMethodASyncPow.Pows(N);

    [Benchmark]
    public async Task<double> PublicClassMethodA_FactorialIterativeMethod_Async() => await _PublicClassMethodASyncPow.Pows(N);

    // static Async 호출
    [Benchmark]
    public async Task<double> StaticClassMethodA_Factorial_Async() => await StaticClassMethodASyncPow.Pows(N);

    [Benchmark]
    public async Task<double> StaticClassMethodA_FactorialIterativeMethod_Async() => await StaticClassMethodASyncPow.Pows(N);

    // 일반 new Class Async 호출
    [Benchmark]
    public async Task<double> PublicClassMethodA_NEW_Factorial_Async()
    {
        var method = new PublicClassMethodASyncPow();
        return await method.Pows(N);
    }

    [Benchmark]
    public async Task<double> PublicClassMethodA_NEW_FactorialIterativeMethod_Async()
    {
        var method = new PublicClassMethodASyncPow();
        return await method.Pows(N);
    }
    #endregion

    #region WhenAll
    // Static Async WhenAll
    [Benchmark]
    public async Task<double> RunStaticPowsParallel()
    {
        var tasks = new Task<double>[Index];
        for (int i = 0; i < Index; i++)
        {
            tasks[i] = StaticClassMethodASyncPow.Pows(N);
        }
        await Task.WhenAll(tasks);
        return double.MinValue;
    }

    // 일반 Async WhenAll
    [Benchmark]
    public async Task<double> RunPublicPowsParallel()
    {
        var tasks = new Task<double>[Index];
        for (int i = 0; i < Index; i++)
        {
            tasks[i] = _PublicClassMethodASyncPow.Pows(N);
        }
        await Task.WhenAll(tasks);
        return double.MinValue;
    }

    // 일반 new Class Async WhenAll
    [Benchmark]
    public async Task<double> RunPublicPowsParallel_NEW_CLASS()
    {
        var tasks = new Task<double>[Index];
        for (int i = 0; i < Index; i++)
        {
            var method = new PublicClassMethodASyncPow();
            tasks[i] = method.Pows(N);
        }
        await Task.WhenAll(tasks);
        return double.MinValue;
    }
    #endregion

    #region Parallel.For
    // Static Async Parallel.ForAsync
    [Benchmark]
    public async Task<double> RunStaticPowsParallel_ForAsync()
    {
        await Parallel.ForAsync(0, Index, async (i, cancellationToken) =>
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            await StaticClassMethodASyncPow.Pows(N);
        });
        return double.MinValue;
    }

    // 일반 Async Parallel.ForAsync
    [Benchmark]
    public async Task<double> RunPublicPowsParallel_ForAsync()
    {
        await Parallel.ForAsync(0, Index, async (i, cancellationToken) =>
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            await _PublicClassMethodASyncPow.Pows(N);
        });
        return double.MinValue;
    }

    // 일반 new Class Async Parallel.ForAsync
    [Benchmark]
    public async Task<double> RunPublicPowsParallel_ForAsync_NEW_CLASS()
    {
        await Parallel.ForAsync(0, Index, async (i, cancellationToken) =>
        {
            if (cancellationToken.IsCancellationRequested)
                return;
            var method = new PublicClassMethodASyncPow();
            await method.Pows(N);
        });
        return double.MinValue;
    }
    #endregion
}