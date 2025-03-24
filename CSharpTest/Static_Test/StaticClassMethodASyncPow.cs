﻿namespace Static_Test;

internal static class StaticClassMethodASyncPow
{
    public static async Task<double> Pows(int n)
    {
        await Task.Yield();
        double result = 1;
        for (int i = 2; i <= n; i++)
        {
            result = Math.Pow(result, i);
        }
        return await Task.FromResult(result);
    }
}