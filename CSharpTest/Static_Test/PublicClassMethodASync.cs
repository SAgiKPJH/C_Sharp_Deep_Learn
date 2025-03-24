namespace Static_Test;

internal class PublicClassMethodASync
{
    public async Task<long> FactorialAsync(int n)
    {
        await Task.Yield();
        if (n <= 1)
            return 1;
        return await Task.FromResult(n * await FactorialAsync(n - 1));
    }

    public async Task<long> FactorialIterativeMethodAsync(int n)
    {
        await Task.Yield();
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return await Task.FromResult(result);
    }
}