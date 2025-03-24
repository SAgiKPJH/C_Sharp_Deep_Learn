namespace Static_Test;

internal class PublicClassMethodA
{
    public long Factorial(int n)
    {
        if (n <= 1)
            return 1;
        return n * Factorial(n - 1);
    }

    public long FactorialIterativeMethod(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public async Task<long> FactorialAsync(int n)
    {
        if (n <= 1)
            return 1;
        return await Task.FromResult(n * Factorial(n - 1));
    }

    public async Task<long> FactorialIterativeMethodAsync(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return await Task.FromResult(result);
    }
}