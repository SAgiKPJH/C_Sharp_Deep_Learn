# CSharp Test

### Static method는 async가 될까?
- Static Method는 Async에서 별반 차이가 없을까?
- nuget package
  ```
  BenchmarkDotNet
  ```

N=10, Index = 100
| Method                                   | Mean         | Error       | StdDev      |
|----------------------------------------- |-------------:|------------:|------------:|
| PublicClassMethodA_Factorial             |     3.248 ns |   0.0237 ns |   0.0222 ns |
| StaticClassMethodA_Factorial             |     3.228 ns |   0.0180 ns |   0.0168 ns |
| PublicClassMethodA_Factorial_Async       |    22.162 ns |   0.4681 ns |   0.8560 ns |
| StaticClassMethodA_Factorial_Async       |    21.630 ns |   0.4463 ns |   0.6109 ns |
| RunStaticFactorialAsyncParallel          | 2,463.669 ns |  46.7150 ns |  47.9728 ns |
| RunPublicFactorialAsyncParallel          | 2,425.257 ns |  38.6934 ns |  32.3107 ns |
| RunStaticFactorialAsyncParallel_ForAsync | 8,367.144 ns | 135.3081 ns | 288.3526 ns |
| RunPublicFactorialAsyncParallel_ForAsync | 8,451.553 ns | 166.3909 ns | 170.8712 ns |

N=100, Index = 1,000
| Method                                   | Mean         | Error        | StdDev       |
|----------------------------------------- |-------------:|-------------:|-------------:|
| PublicClassMethodA_Factorial             |     40.45 ns |     0.645 ns |     0.603 ns |
| StaticClassMethodA_Factorial             |     40.08 ns |     0.494 ns |     0.463 ns |
| PublicClassMethodA_Factorial_Async       |     52.90 ns |     0.357 ns |     0.317 ns |
| StaticClassMethodA_Factorial_Async       |     52.69 ns |     0.243 ns |     0.227 ns |
| RunStaticFactorialAsyncParallel          | 53,631.09 ns |   691.704 ns |   647.021 ns |
| RunPublicFactorialAsyncParallel          | 55,302.81 ns |   239.253 ns |   223.798 ns |
| RunStaticFactorialAsyncParallel_ForAsync | 88,954.98 ns | 1,732.279 ns | 2,539.153 ns |
| RunPublicFactorialAsyncParallel_ForAsync | 89,654.65 ns |   348.531 ns |   291.039 ns |

N = 10,000, Index = 100,000
| Method                                   | Mean           | Error         | StdDev        |
|----------------------------------------- |---------------:|--------------:|--------------:|
| PublicClassMethodA_Factorial             |       6.704 us |     0.0392 us |     0.0347 us |
| StaticClassMethodA_Factorial             |       6.644 us |     0.0323 us |     0.0286 us |
| PublicClassMethodA_Factorial_Async       |       6.701 us |     0.0429 us |     0.0401 us |
| StaticClassMethodA_Factorial_Async       |       6.699 us |     0.0309 us |     0.0289 us |
| RunStaticFactorialAsyncParallel          | 677,888.043 us | 2,497.4276 us | 2,213.9045 us |
| RunPublicFactorialAsyncParallel          | 672,216.787 us | 6,153.2068 us | 5,755.7135 us |
| RunStaticFactorialAsyncParallel_ForAsync |  39,171.231 us |   109.0195 us |    91.0362 us |
| RunPublicFactorialAsyncParallel_ForAsync |  39,359.250 us |   728.4490 us |   608.2879 us |


N=10, Index = 100
| Method                                                | Mean         | Error       | StdDev        | Median       |
|------------------------------------------------------ |-------------:|------------:|--------------:|-------------:|
| PublicClassMethodA_Factorial                          |     5.649 ns |   0.0446 ns |     0.0417 ns |     5.636 ns |
| PublicClassMethodA_FactorialIterativeMethod           |     3.524 ns |   0.0339 ns |     0.0301 ns |     3.524 ns |
| StaticClassMethodA_Factorial                          |     6.085 ns |   0.0437 ns |     0.0408 ns |     6.080 ns |
| StaticClassMethodA_FactorialIterativeMethod           |     3.364 ns |   0.0282 ns |     0.0264 ns |     3.367 ns |
| PublicClassMethodA_New_Factorial                      |     7.534 ns |   0.0767 ns |     0.0717 ns |     7.537 ns |
| PublicClassMethodA_New_FactorialIterativeMethod       |     5.455 ns |   0.1043 ns |     0.0976 ns |     5.448 ns |
| PublicClassMethodA_Factorial_Async                    |    26.210 ns |   0.5408 ns |     0.6840 ns |    26.297 ns |
| PublicClassMethodA_FactorialIterativeMethod_Async     |    22.538 ns |   0.4765 ns |     0.8713 ns |    22.367 ns |
| StaticClassMethodA_Factorial_Async                    |    25.722 ns |   0.5395 ns |     1.3030 ns |    25.493 ns |
| StaticClassMethodA_FactorialIterativeMethod_Async     |    22.720 ns |   0.4789 ns |     0.9891 ns |    22.714 ns |
| PublicClassMethodA_NEW_Factorial_Async                |    27.904 ns |   0.5718 ns |     0.7231 ns |    27.984 ns |
| PublicClassMethodA_NEW_FactorialIterativeMethod_Async |    22.947 ns |   0.4832 ns |     0.7379 ns |    22.714 ns |
| RunStaticFactorialAsyncParallel                       | 2,674.028 ns |  50.1877 ns |    82.4598 ns | 2,641.803 ns |
| RunPublicFactorialAsyncParallel                       | 2,856.045 ns |  56.3855 ns |   128.4182 ns | 2,789.947 ns |
| RunPublicFactorialAsyncParallel_NEW_CLASS             | 3,123.280 ns |  43.2288 ns |    38.3212 ns | 3,117.605 ns |
| RunStaticFactorialAsyncParallel_ForAsync              | 9,151.463 ns | 474.2978 ns | 1,398.4777 ns | 8,216.326 ns |
| RunPublicFactorialAsyncParallel_ForAsync              | 8,087.079 ns | 155.7040 ns |   179.3090 ns | 8,172.051 ns |
| RunPublicFactorialAsyncParallel_ForAsync_NEW_CLASS    | 8,345.532 ns | 163.9259 ns |   201.3158 ns | 8,251.301 ns |

N=100, Index = 1000
| Method                                                | Mean          | Error        | StdDev       | Median        |
|------------------------------------------------------ |--------------:|-------------:|-------------:|--------------:|
| PublicClassMethodA_Factorial                          |      84.99 ns |     0.441 ns |     0.413 ns |      84.81 ns |
| PublicClassMethodA_FactorialIterativeMethod           |      40.53 ns |     0.541 ns |     0.506 ns |      40.63 ns |
| StaticClassMethodA_Factorial                          |      84.66 ns |     0.434 ns |     0.339 ns |      84.65 ns |
| StaticClassMethodA_FactorialIterativeMethod           |      40.03 ns |     0.627 ns |     0.671 ns |      39.83 ns |
| PublicClassMethodA_New_Factorial                      |      88.11 ns |     0.437 ns |     0.387 ns |      88.18 ns |
| PublicClassMethodA_New_FactorialIterativeMethod       |      43.06 ns |     0.404 ns |     0.358 ns |      43.05 ns |
| PublicClassMethodA_Factorial_Async                    |      95.24 ns |     1.041 ns |     0.974 ns |      95.03 ns |
| PublicClassMethodA_FactorialIterativeMethod_Async     |      53.46 ns |     0.260 ns |     0.243 ns |      53.53 ns |
| StaticClassMethodA_Factorial_Async                    |      96.85 ns |     0.697 ns |     0.652 ns |      96.55 ns |
| StaticClassMethodA_FactorialIterativeMethod_Async     |      53.84 ns |     0.444 ns |     0.415 ns |      53.78 ns |
| PublicClassMethodA_NEW_Factorial_Async                |      93.43 ns |     0.486 ns |     0.454 ns |      93.25 ns |
| PublicClassMethodA_NEW_FactorialIterativeMethod_Async |      53.67 ns |     0.350 ns |     0.310 ns |      53.62 ns |
| RunStaticFactorialAsyncParallel                       | 103,748.62 ns |   267.564 ns |   237.188 ns | 103,784.85 ns |
| RunPublicFactorialAsyncParallel                       |  97,402.99 ns |   845.646 ns |   791.017 ns |  97,101.72 ns |
| RunPublicFactorialAsyncParallel_NEW_CLASS             | 100,095.00 ns |   336.603 ns |   314.859 ns |  99,976.00 ns |
| RunStaticFactorialAsyncParallel_ForAsync              |  93,825.10 ns | 1,852.547 ns | 3,656.748 ns |  95,670.72 ns |
| RunPublicFactorialAsyncParallel_ForAsync              |  90,936.83 ns | 1,404.341 ns | 1,313.621 ns |  91,210.52 ns |
| RunPublicFactorialAsyncParallel_ForAsync_NEW_CLASS    |  91,910.63 ns | 1,441.400 ns | 1,277.763 ns |  92,170.53 ns |


| Method                                                | Mean             | Error         | StdDev        |
|------------------------------------------------------ |-----------------:|--------------:|--------------:|
| StaticClassMethodA_Factorial                          |        11.030 us |     0.0717 us |     0.0671 us |
| PublicClassMethodA_Factorial                          |        11.051 us |     0.0852 us |     0.0797 us |
| PublicClassMethodA_New_Factorial                      |        10.958 us |     0.0431 us |     0.0404 us |

| StaticClassMethodA_FactorialIterativeMethod           |         6.632 us |     0.0442 us |     0.0392 us |
| PublicClassMethodA_FactorialIterativeMethod           |         6.578 us |     0.0187 us |     0.0166 us |
| PublicClassMethodA_New_FactorialIterativeMethod       |         6.617 us |     0.0126 us |     0.0105 us |

| StaticClassMethodA_Factorial_Async                    |        11.162 us |     0.0601 us |     0.0562 us |
| PublicClassMethodA_Factorial_Async                    |        11.015 us |     0.0531 us |     0.0497 us |
| PublicClassMethodA_NEW_Factorial_Async                |        11.041 us |     0.0373 us |     0.0330 us |

| StaticClassMethodA_FactorialIterativeMethod_Async     |         6.663 us |     0.0125 us |     0.0117 us |
| PublicClassMethodA_FactorialIterativeMethod_Async     |         6.640 us |     0.0299 us |     0.0280 us |
| PublicClassMethodA_NEW_FactorialIterativeMethod_Async |         6.654 us |     0.0334 us |     0.0313 us |

| RunStaticFactorialAsyncParallel                       | 1,101,712.847 us | 3,500.7774 us | 3,274.6294 us |
| RunPublicFactorialAsyncParallel                       | 1,096,660.273 us | 9,872.9780 us | 9,235.1897 us |
| RunPublicFactorialAsyncParallel_NEW_CLASS             | 1,086,249.367 us | 3,856.0715 us | 3,606.9717 us |

| RunStaticFactorialAsyncParallel_ForAsync              |    76,487.788 us |   280.2108 us |   233.9887 us |
| RunPublicFactorialAsyncParallel_ForAsync              |    78,388.172 us |   321.9885 us |   301.1882 us |
| RunPublicFactorialAsyncParallel_ForAsync_NEW_CLASS    |    84,992.928 us | 1,611.1888 us | 1,582.4028 us |



| Method                                   | Mean     | Error     | StdDev    |
|----------------------------------------- |---------:|----------:|----------:|
| RunStaticFactorialAsyncParallel          | 9.165 us | 0.0578 us | 0.0541 us |
| RunPublicFactorialAsyncParallel          | 9.190 us | 0.0565 us | 0.0472 us |
| RunPublicFactorialAsyncParallel_NewClass | 9.230 us | 0.0678 us | 0.0634 us |


| Method                                   | Mean     | Error    | StdDev   |
|----------------------------------------- |---------:|---------:|---------:|
| RunStaticFactorialAsyncParallel          | 91.92 us | 0.919 us | 0.815 us |
| RunPublicFactorialAsyncParallel          | 91.85 us | 0.747 us | 0.699 us |
| RunPublicFactorialAsyncParallel_NewClass | 91.69 us | 0.731 us | 0.648 us |

| Method                                   | Mean     | Error     | StdDev    |
|----------------------------------------- |---------:|----------:|----------:|
| RunStaticFactorialAsyncParallel          | 1.047 ms | 0.0162 ms | 0.0144 ms |
| RunPublicFactorialAsyncParallel          | 1.057 ms | 0.0202 ms | 0.0207 ms |
| RunPublicFactorialAsyncParallel_NewClass | 1.196 ms | 0.0232 ms | 0.0228 ms |



- 메서드 미복잡, 반복횟수 적음 N=10, Index=10
| Method                                                | Mean        | Error     | StdDev    |
|------------------------------------------------------ |------------:|----------:|----------:|
| StaticClassMethodA_Factorial_Async                    |  3,447.4 ns |  68.88 ns | 142.26 ns |
| PublicClassMethodA_Factorial_Async                    |  3,460.7 ns |  68.56 ns | 120.07 ns |
| PublicClassMethodA_NEW_Factorial_Async                |  3,589.3 ns |  68.23 ns | 178.54 ns |

| StaticClassMethodA_FactorialIterativeMethod_Async     |    615.9 ns |  12.10 ns |  24.73 ns |
| PublicClassMethodA_FactorialIterativeMethod_Async     |    576.3 ns |   9.65 ns |   9.03 ns |
| PublicClassMethodA_NEW_FactorialIterativeMethod_Async |    620.2 ns |  12.20 ns |  24.65 ns |

| RunStaticFactorialAsyncParallel                       | 24,003.3 ns | 479.90 ns | 552.65 ns |
| RunPublicFactorialAsyncParallel                       | 24,540.3 ns | 369.85 ns | 345.96 ns |
| RunPublicFactorialAsyncParallel_NEW_CLASS             | 24,731.9 ns | 318.53 ns | 282.37 ns |

| RunStaticFactorialAsyncParallel_ForAsync              | 27,794.9 ns | 442.31 ns | 392.09 ns |
| RunPublicFactorialAsyncParallel_ForAsync              | 28,746.7 ns | 538.53 ns | 503.74 ns |
| RunPublicFactorialAsyncParallel_ForAsync_NEW_CLASS    | 27,512.5 ns | 228.42 ns | 213.66 ns |

- N=100, Index=1000

| Method                                                | Mean            | Error         | StdDev        | Median          |
|------------------------------------------------------ |----------------:|--------------:|--------------:|----------------:|
| StaticClassMethodA_Factorial_Async                    |     32,871.7 ns |     652.97 ns |     610.79 ns |     32,903.1 ns |
| PublicClassMethodA_Factorial_Async                    |     33,337.4 ns |     650.08 ns |   1,031.09 ns |     33,158.1 ns |
| PublicClassMethodA_NEW_Factorial_Async                |     33,961.4 ns |     678.25 ns |   1,750.79 ns |     33,835.7 ns |

| StaticClassMethodA_FactorialIterativeMethod_Async     |        604.0 ns |      11.85 ns |      18.10 ns |        606.4 ns |
| PublicClassMethodA_FactorialIterativeMethod_Async     |        675.1 ns |      14.60 ns |      43.04 ns |        681.6 ns |
| PublicClassMethodA_NEW_FactorialIterativeMethod_Async |        573.1 ns |      11.35 ns |      10.06 ns |        575.8 ns |

| RunStaticFactorialAsyncParallel                       | 24,615,783.2 ns | 475,883.46 ns | 740,893.27 ns | 24,558,815.6 ns |
| RunPublicFactorialAsyncParallel                       | 25,288,072.2 ns | 504,835.15 ns | 673,940.48 ns | 25,266,271.9 ns |
| RunPublicFactorialAsyncParallel_NEW_CLASS             | 26,020,018.3 ns | 419,293.09 ns | 392,207.02 ns | 26,079,840.6 ns |

| RunStaticFactorialAsyncParallel_ForAsync              | 18,495,831.2 ns | 366,561.92 ns | 501,754.13 ns | 18,810,890.6 ns |
| RunPublicFactorialAsyncParallel_ForAsync              | 18,480,048.3 ns | 258,256.97 ns | 241,573.73 ns | 18,569,762.5 ns |
| RunPublicFactorialAsyncParallel_ForAsync_NEW_CLASS    | 18,522,272.1 ns | 252,704.57 ns | 224,016.02 ns | 18,489,600.0 ns |



| Method                                                | Mean       | Error    | StdDev    |
|------------------------------------------------------ |-----------:|---------:|----------:|
| StaticClassMethodA_Factorial_Async                    |   716.0 ns | 14.21 ns |  25.25 ns |
| PublicClassMethodA_Factorial_Async                    |   734.8 ns | 14.69 ns |  42.16 ns |
| PublicClassMethodA_NEW_Factorial_Async                |   781.1 ns | 15.37 ns |  26.93 ns |

| StaticClassMethodA_FactorialIterativeMethod_Async     |   777.9 ns | 15.37 ns |  28.48 ns |
| PublicClassMethodA_FactorialIterativeMethod_Async     |   706.3 ns | 13.89 ns |  16.53 ns |
| PublicClassMethodA_NEW_FactorialIterativeMethod_Async |   728.0 ns | 13.36 ns |  11.84 ns |

| RunStaticPowsParallel                                 | 3,101.5 ns | 27.70 ns |  25.91 ns |
| RunPublicPowsParallel                                 | 3,117.0 ns | 59.10 ns | 123.36 ns |
| RunPublicPowsParallel_NEW_CLASS                       | 2,975.3 ns | 59.18 ns |  79.01 ns |

| RunStaticPowsParallel_ForAsync                        | 4,761.4 ns | 77.59 ns |  68.79 ns |
| RunPublicPowsParallel_ForAsync                        | 4,686.4 ns | 62.41 ns |  55.32 ns |
| RunPublicPowsParallel_ForAsync_NEW_CLASS              | 4,620.2 ns | 46.27 ns |  51.43 ns |