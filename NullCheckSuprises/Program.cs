using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace NullCheckSuprises
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();
            Console.ReadLine();
        }
    }

    [MemoryDiagnoser]
    public class BenchmarkClass
    {
        object nullVariable = null;

        [Benchmark]
        public bool NullCheckIs()
        {
            return nullVariable is null;
        }

        [Benchmark]
        public bool NullCheckOperator()
        {
            return nullVariable == null;
        }

        [Benchmark]
        public bool NotNullCheckOperator()
        {
            return nullVariable != null;
        }

        [Benchmark]
        public bool NotNullCheckIs()
        {
            return nullVariable is { };
        }
        [Benchmark]
        public bool NotNullCheckIsNot()
        {
            return nullVariable is not null;
        }
    }
}
