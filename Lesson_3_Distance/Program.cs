using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson_3_Distance
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<MyDistanceBenchmark>();
        }
    }
}
