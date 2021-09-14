``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 7 SP1 (6.1.7601.0)
Intel Core i7-3770K CPU 3.50GHz (Ivy Bridge), 1 CPU, 8 logical and 4 physical cores
Frequency=3410273 Hz, Resolution=293.2317 ns, Timer=TSC
.NET SDK=5.0.301
  [Host]     : .NET Core 3.1.16 (CoreCLR 4.700.21.26205, CoreFX 4.700.21.26205), X64 RyuJIT
  DefaultJob : .NET Core 3.1.16 (CoreCLR 4.700.21.26205, CoreFX 4.700.21.26205), X64 RyuJIT


```
|                            Method |      Mean |     Error |    StdDev | Rank | Allocated |
|---------------------------------- |----------:|----------:|----------:|-----:|----------:|
|       PointDistanceClassFloatTest | 0.7010 ns | 0.0058 ns | 0.0054 ns |    4 |         - |
|      PointDistanceStructFloatTest | 0.3290 ns | 0.0193 ns | 0.0180 ns |    2 |         - |
|     PointDistanceStructDoubleTest | 0.2902 ns | 0.0067 ns | 0.0059 ns |    1 |         - |
| PointDistanceStructFloatShortTest | 0.3453 ns | 0.0050 ns | 0.0044 ns |    3 |         - |
