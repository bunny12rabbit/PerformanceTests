using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Benchmarks
{
    public abstract class BenchmarkBase : MonoBehaviour
    {
        public string BenchmarkName { get; protected set; }

        public int MaxRecommendedIterations { get; protected set; } = int.MaxValue;

        protected readonly List<BenchmarkData> benchmarks = new();

        public IEnumerable<BenchmarkData> RunBenchmark(int iterations)
        {
            foreach (var benchmark in benchmarks)
                yield return Run(benchmark);

            BenchmarkData Run(BenchmarkData data)
            {
                var watch = Stopwatch.StartNew();

                for (var i = 0; i < iterations; i++)
                    data.Action();

                watch.Stop();
                data.Result = watch.ElapsedMilliseconds;
                return data;
            }
        }

        private void Awake() => Init();

        protected abstract void Init();
    }
}