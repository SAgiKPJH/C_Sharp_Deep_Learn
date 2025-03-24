using BenchmarkDotNet.Running;
using Static_Test;

//var summary = BenchmarkRunner.Run<MethodBenchmarks>();
//var summary = BenchmarkRunner.Run<MethodSameClassBechmarks>();
//var summary = BenchmarkRunner.Run<MethodAsyncTestBenchmarks>();
//var summary = BenchmarkRunner.Run<AsyncClassMethodBenchmarks>();
var summary = BenchmarkRunner.Run<AsyncClassMethodPowBenchmarks>();