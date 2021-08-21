using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EnumToStringOptimizer.Common;

namespace EnumToStringOptimizer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }

    [MemoryDiagnoser]
    public class Benchmark
    {
        private readonly MediaType Type = MediaType.Video;
        [Benchmark]
        public string NativeToString() => Type.ToString();

        [Benchmark]
        public string FastToString() => Type.FastToString();
    }
}
