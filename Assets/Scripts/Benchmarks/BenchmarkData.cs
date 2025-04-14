using System;

namespace Benchmarks
{
    public struct BenchmarkData
    {
        public readonly string Name;

        public readonly Action Action;

        public long Result;
        public int AllocCount;


        public BenchmarkData(string name, Action action) : this()
        {
            Name = name;
            Action = action;
            Result = 0;
            AllocCount = 0;
        }
    }
}