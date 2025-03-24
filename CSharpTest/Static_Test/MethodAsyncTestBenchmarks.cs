using BenchmarkDotNet.Attributes;

namespace Static_Test;

public class MethodAsyncTestBenchmarks
{
    private const int N = 10000;
    private const int Index = 100000;
    private List<PublicClassMethodA> _publicClassMethodAs = new();
    private readonly Task<long>[] staticTasks = new Task<long>[Index];
    private readonly Task<long>[] publicTasks = new Task<long>[Index];
    private readonly Task<long>[] newClassTasks = new Task<long>[Index];


    public MethodAsyncTestBenchmarks()
    {
        for(int i = 0; i < Index; i++)
        {
            _publicClassMethodAs.Add(new PublicClassMethodA());
            staticTasks[i] = Static_Factorial_Async(N);
            publicTasks[i] = Public_Factorial_Async(N);
            newClassTasks[i] = _publicClassMethodAs[i].FactorialIterativeMethodAsync(N);
        }

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

    [Benchmark]
    public async Task<long> RunStaticFactorialAsyncParallel()
    {
        await Task.WhenAll(staticTasks);
        return long.MinValue;
    }

    [Benchmark]
    public async Task<long> RunPublicFactorialAsyncParallel()
    {
        await Task.WhenAll(publicTasks);
        return long.MinValue;
    }

    [Benchmark]
    public async Task<long> RunPublicFactorialAsyncParallel_NewClass()
    {
        await Task.WhenAll(newClassTasks);
        return long.MinValue;
    }
}
