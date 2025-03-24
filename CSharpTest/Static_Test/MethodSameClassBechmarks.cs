using BenchmarkDotNet.Attributes;

namespace Static_Test;

public class MethodSameClassBechmarks
{
    private const int N = 10000;
    private const int Index = 10000;
    public long Public_Factorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public static long Static_Factorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public async Task<long> Public_Factorial_Async(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return await Task.FromResult(result);
    }

    public static async Task<long> Static_Factorial_Async(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return await Task.FromResult(result);
    }

    #region 일반
    // 일반 호출
    [Benchmark]
    public long PublicClassMethodA_Factorial() => Public_Factorial(N);

    // static 호출
    [Benchmark]
    public long StaticClassMethodA_Factorial() => Static_Factorial(N);
    #endregion

    #region Async
    // 일반 Async 호출
    [Benchmark]
    public async Task<long> PublicClassMethodA_Factorial_Async() => await Public_Factorial_Async(N);

    // static Async 호출
    [Benchmark]
    public async Task<long> StaticClassMethodA_Factorial_Async() => await Static_Factorial_Async(N);
    #endregion

    #region WhenAll
    // Static Async WhenAll
    [Benchmark]
    public async Task<long> RunStaticFactorialAsyncParallel()
    {
        var tasks = new Task<long>[Index];
        for (int i = 0; i < Index; i++)
        {
            tasks[i] = Static_Factorial_Async(N);
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
            tasks[i] = Public_Factorial_Async(N);
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
            await Static_Factorial_Async(N);
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
            await Public_Factorial_Async(N);
        });
        return long.MinValue;
    }
    #endregion
}