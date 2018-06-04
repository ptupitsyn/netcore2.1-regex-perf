using BenchmarkDotNet.Running;

namespace regex_test
{
    class Program
    {
        static void Main()
        {
            // BenchmarkRunner.Run<RegexBenchmark>();
            RegexBenchmark.Test();
        }
    }
}
