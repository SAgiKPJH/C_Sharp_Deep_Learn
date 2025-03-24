using BenchmarkDotNet.Attributes;

namespace Static_Test;

public class MethodBenchmarks
{
    private const int N = 10000;
    private const int Index = 100000;
    private readonly PublicClassMethodA _publicClassMethodA = new();

    #region 일반
    // 일반 호출
    [Benchmark]
    public long PublicClassMethodA_Factorial() => _publicClassMethodA.Factorial(N);

    [Benchmark]
    public long PublicClassMethodA_FactorialIterativeMethod() => _publicClassMethodA.FactorialIterativeMethod(N);

    // static 호출
    [Benchmark]
    public long StaticClassMethodA_Factorial() => StaticClassMethodA.Factorial(N);

    [Benchmark]
    public long StaticClassMethodA_FactorialIterativeMethod() => StaticClassMethodA.FactorialIterativeMethod(N);

    // 일반 new Class 호출
    [Benchmark]
    public long PublicClassMethodA_New_Factorial()
    {
        var method = new PublicClassMethodA();
        return method.Factorial(N);
    }

    [Benchmark]
    public long PublicClassMethodA_New_FactorialIterativeMethod()
    {
        var method = new PublicClassMethodA();
        return method.FactorialIterativeMethod(N);
    }
    #endregion

    #region Async
    // 일반 Async 호출
    [Benchmark]
    public async Task<long> PublicClassMethodA_Factorial_Async() => await _publicClassMethodA.FactorialAsync(N);

    [Benchmark]
    public async Task<long> PublicClassMethodA_FactorialIterativeMethod_Async() => await _publicClassMethodA.FactorialIterativeMethodAsync(N);

    // static Async 호출
    [Benchmark]
    public async Task<long> StaticClassMethodA_Factorial_Async() => await StaticClassMethodA.FactorialAsync(N);

    [Benchmark]
    public async Task<long> StaticClassMethodA_FactorialIterativeMethod_Async() => await StaticClassMethodA.FactorialIterativeMethodAsync(N);

    // 일반 new Class Async 호출
    [Benchmark]
    public async Task<long> PublicClassMethodA_NEW_Factorial_Async()
    {
        var method = new PublicClassMethodA();
        return await method.FactorialAsync(N);
    }

    [Benchmark]
    public async Task<long> PublicClassMethodA_NEW_FactorialIterativeMethod_Async()
    {
        var method = new PublicClassMethodA();
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
            tasks[i] = StaticClassMethodA.FactorialAsync(N);
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
            tasks[i] = _publicClassMethodA.FactorialAsync(N);
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
            var method = new PublicClassMethodA();
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
            if(cancellationToken.IsCancellationRequested)
                return;
            await StaticClassMethodA.FactorialAsync(N);
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
            await _publicClassMethodA.FactorialAsync(N);
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
            var method = new PublicClassMethodA();
            await method.FactorialAsync(N);
        });
        return long.MinValue;
    }
    #endregion
}